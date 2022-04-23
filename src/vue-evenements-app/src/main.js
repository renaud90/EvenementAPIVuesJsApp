import { createApp } from 'vue'
import App from './App.vue'
import router from './router'
import store from './store'
import BaseLayout from './layouts/BaseLayout.vue'
import mainOidc from './api/authClient.js'

mainOidc.startup().then(ok => {
    if (ok) {
    const app = createApp(App).use(store).use(router).component('BaseLayout', BaseLayout).mount('#app')
    app.config.globalProperties.$oidc = mainOidc;
    }
   })


