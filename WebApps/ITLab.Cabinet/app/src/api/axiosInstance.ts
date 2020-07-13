import axios from 'axios';

const instance = axios.create({
    baseURL: 'http://25.42.18.21:82/api/'
});

export default instance;