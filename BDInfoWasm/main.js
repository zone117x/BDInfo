// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

import { dotnet } from './dotnet.js'

const { setModuleImports, getAssemblyExports, getConfig } = await dotnet
  .withDiagnosticTracing(false)
  .create();

setModuleImports('main.js', {
  getTestValue,
  readFile,
  logProgress,
});

const config = getConfig();
const exports = await getAssemblyExports(config.mainAssemblyName);
const text = exports.MyClass.Greeting();
self.postMessage({ type: 'progress', payload: `C# Message ${text}` });

/** @type {File[]} */
let fileMap = null;
let fileTree = null;

self.onmessage = async (e) => {
  console.log(e.data);
  handleMessage(e.data);
};

async function handleMessage({ type, payload }) {
  switch (type) {
    case 'files':
      ({ fileTree, fileMap } = createDirectoryTree(payload));
      const result = await exports.MyClass.SetFiles(JSON.stringify(fileTree));
      console.log('Response from C#:', result);
      self.postMessage({ type: 'report', payload: result });
      break;
    default:
      console.error('Unknown message type', type);
      break;
  }
}

function logProgress(message) {
  self.postMessage({ type: 'progress', payload: message });
}

function getTestValue() {
  return "return working 2";
}

async function readFile(fileID, offset, length) {
  const chunk = fileMap[fileID].slice(offset, offset + length);
  const buffer = await chunk.arrayBuffer();
  return new Uint8Array(buffer);
}

function createDirectoryTree(files) {
  if (!files.length) return null;
  const fileMap = [];
  const fileTree = [{
    type: 'dir',
    name: files[0].webkitRelativePath.split('/')[0],
    children: [],
  }];
  let fileID = 0;
  Array.from(files).forEach(file => {
    const parts = (file.webkitRelativePath ?? file.relativePath).split('/').slice(1);
    let [cursor] = fileTree;
    let accumulatedPath = cursor.name;
    parts.forEach((part, i) => {
      accumulatedPath = `${accumulatedPath}/${part}`;
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
          child.path = accumulatedPath;
        }
        cursor.children.push(child);
      }
      cursor = child;
    });
  });
  console.log('Input files:', fileTree);
  return { fileTree, fileMap };
}

await dotnet.run();
