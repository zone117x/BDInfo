// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

import { dotnet } from './dotnet.js'

const { setModuleImports, getAssemblyExports, getConfig } = await dotnet
  .withDiagnosticTracing(false)
  .withApplicationArgumentsFromQuery()
  .create();

setModuleImports('main.js', {
  window: {
    location: {
      href: () => globalThis.window.location.href
    }
  },
  getTestValue,
  readFile,
});

const config = getConfig();
const exports = await getAssemblyExports(config.mainAssemblyName);
const text = exports.MyClass.Greeting();
console.log(text);

document.getElementById('out').innerHTML = text;

let fileTree = null;

/** @type {File[]} */
let fileMap = null;

document.getElementById("filepicker").addEventListener(
  "change",
  async (event) => {
    ({ fileTree, fileMap } = createDirectoryTree(event.target.files));
    const result = await exports.MyClass.SetFiles(JSON.stringify(fileTree));
    console.log('Response from C#:', result);
    document.getElementById('filetree').textContent = JSON.stringify(JSON.parse(result), null, 2);
  },
  false,
);

function createDirectoryTree(files) {
  if (!files.length) return null;
  const fileMap = [];
  const fileTree = [{ type: 'dir', name: files[0].webkitRelativePath.split('/')[0], children: [] }];
  let fileID = 0;
  Array.from(files).forEach(file => {
    const parts = (file.webkitRelativePath ?? file.relativePath).split('/').slice(1);
    let [cursor] = fileTree;
    parts.forEach((part, i) => {
      let child = cursor.children.find(c => c.name === part);
      if (!child) {
        child = { name: part, type: i === parts.length - 1 ? 'file' : 'dir' };
        if (child.type === 'file') {
          // child.file = file;
          child.size = file.size;
          child.path = file.webkitRelativePath ?? file.relativePath;
          child.fileID = fileID++;
          fileMap[child.fileID] = file;
        } else {
          child.children = [];
        }
        cursor.children.push(child);
      }
      cursor = child;
    });
  });
  console.log('Input files:', fileTree);
  return { fileTree, fileMap };
}

function getTestValue() {
  return "return working 2";
}

async function readFile(fileID, offset, length) {
  const chunk = fileMap[fileID].slice(offset, offset + length);
  const buffer = await chunk.arrayBuffer();
  return new Uint8Array(buffer);
}

await dotnet.run();
