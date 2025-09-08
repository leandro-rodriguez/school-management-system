import { defineConfig } from 'vite';
import react from '@vitejs/plugin-react';
import path from 'path';

// https://vitejs.dev/config/
export default defineConfig({
  plugins: [react()],
  // This is important: it tells Vite to put the final built files
  // into a folder named 'build', just like Create React App did.
  // This ensures your existing Express server.js will work without changes.
  build: {
    outDir: 'build',
  },
  server: {
    // This sets the development server port.
    // You can change this to another port if needed.
    port: 3000,
  },
  // Add this section to resolve CSS preprocessor issues
  css: {
    preprocessorOptions: {
      less: {
        // This is the crucial setting to fix the antd build error
        javascriptEnabled: true,
      },
    },
  },
  // Add this section to fix the '~' import alias from older projects
  resolve: {
    alias: [
      // This will find any import starting with `~` and replace it with an empty string,
      // allowing Vite to resolve the path from the node_modules directory.
      { find: /^~/, replacement: '' },
    ],
  },
});

