import { defineConfig } from 'vite'
import react from '@vitejs/plugin-react-swc'
// eslint-disable-next-line @typescript-eslint/no-var-requires
// https://vitejs.dev/config/
export default defineConfig({
  plugins: [react()],
  server:{
    port:3001
  }
})
