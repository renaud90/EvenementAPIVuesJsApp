import axios from 'axios'

const httpCLient = axios.create({
    baseURL: 'http://localhost:5000/api',
    timeout: 3000
  });

  httpCLient.defaults.headers.post['Content-Type'] = 'application/json';
  export default httpCLient;