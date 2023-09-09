const worker = new Worker('./main.js', { type: 'module' });
worker.onmessage = (e) => {
  console.log(e.data);
  const { type, payload } = e.data;
  switch (type) {
    case 'progress':
      document.getElementById('progress').innerText = payload;
      break;
    case 'report':
      document.getElementById('out').innerText += payload;
      break;
    default:
      console.error('Unknown message type', type);
      break;
  }
};
worker.onerror = (e) => {
  console.error('Worker error:', e);
  document.getElementById('errors').innerText += `Worker error: ${e}\n`;
};
worker.onmessageerror = (e) => {
  console.error('Worker message error', e);
  document.getElementById('errors').innerText += `Worker message error: ${e}\n`;
};

document.getElementById("filepicker").addEventListener(
  "change",
  (event) => {
    worker.postMessage({ type: 'files', payload: event.target.files });
  },
  false,
);
