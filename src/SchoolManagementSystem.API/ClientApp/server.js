import express from 'express';
import path from 'path';
import { fileURLToPath } from 'url';

// Since we are using ES modules, __dirname is not available directly.
// This is the standard way to get the directory name.
const __filename = fileURLToPath(import.meta.url);
const __dirname = path.dirname(__filename);

const app = express();
const port = process.env.PORT || 8080;

// This tells Express to serve all static files (JS, CSS, images, etc.)
// from the 'build' directory.
app.use(express.static(path.join(__dirname, 'build')));

// This is the fallback route. This middleware will only run for requests
// that did not match a static file in the 'build' directory above.
// It sends the main index.html file, which is crucial for single-page applications.
app.use((req, res) => {
  res.sendFile(path.join(__dirname, 'build', 'index.html'));
});

app.listen(port, () => {
  console.log(`Server is listening on port ${port}`);
});

