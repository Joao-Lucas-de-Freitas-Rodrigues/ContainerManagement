import axios from 'axios';

const api = axios.create({
    baseURL: 'https://localhost:7061/api/',
    headers: {
        'Content-Type': 'application/json',
        'Accept': 'application/json'
    },
})

api.interceptors.request.use(
    config => {
        const token = localStorage.getItem('token'); // Aqui você obtém o token JWT do armazenamento local (ou de onde quer que esteja armazenado)
        if (token) {
            config.headers.Authorization = `Bearer ${token}`; // Adicione o token JWT como parte da autenticação Bearer
        }
        return config;
    },
    error => {
        return Promise.reject(error);
    }
);


export default api