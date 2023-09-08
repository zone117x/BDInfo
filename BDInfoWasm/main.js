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
  }
});

const config = getConfig();
const exports = await getAssemblyExports(config.mainAssemblyName);
const text = exports.MyClass.Greeting();
console.log(text);

document.getElementById('out').innerHTML = text;

document.getElementById("filepicker").addEventListener(
  "change",
  (event) => {
    let output = document.getElementById("listing");
    createDirectoryTree(event.target.files);
    for (const file of event.target.files) {
      let item = document.createElement("li");
      item.textContent = file.webkitRelativePath;
      output.appendChild(item);
    }
  },
  false,
);

function createDirectoryTree(files) {
  if (!files.length) return null;
  const root = { type: 'dir', name: files[0].webkitRelativePath.split('/')[0], children: [] };
  Array.from(files).forEach(file => {
    const parts = (file.webkitRelativePath ?? file.relativePath).split('/').slice(1);
    let cursor = root;
    parts.forEach((part, i) => {
      let child = cursor.children.find(c => c.name === part);
      if (!child) {
        child = { type: i === parts.length - 1 ? 'file' : 'dir', name: part, children: [] };
        if (child.type === 'file') child.file = file;
        cursor.children.push(child);
      }
      cursor = child;
    });
  });
  console.log('Input files:', root);
  return root;
}

await dotnet.run();
