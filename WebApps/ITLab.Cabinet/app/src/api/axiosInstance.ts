import axios from 'axios';

const instance = axios.create({
    baseURL: 'https://localhost:5000/api/Student/'
});

export default instance;