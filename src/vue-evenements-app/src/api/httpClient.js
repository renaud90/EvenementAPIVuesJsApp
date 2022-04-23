import axios from 'axios'
import mainOidc from './authClient.js'

const httpCLient = axios.create({
    baseURL: 'http://localhost:5000/api',
    timeout: 3000
  });

  httpCLient.defaults.headers.post['Content-Type'] = 'application/json';
  httpCLient.interceptors.request.use(request => {
      // add auth header with jwt if account is logged in and request is to the api url
      const isLoggedIn = mainOidc.isAuthenticated;
      const isApiUrl = request.url.startsWith('/api')//prefix de votre api
      if (isLoggedIn && isApiUrl) {
      request.headers.common.Authorization = `Bearer ${mainOidc.accessToken}`;
    }
    return request;
   });
  export default httpCLient;
