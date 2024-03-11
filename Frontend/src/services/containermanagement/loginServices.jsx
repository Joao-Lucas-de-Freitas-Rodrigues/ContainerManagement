import api from '../../api/config'
import Router from 'next/router';

export async function validateUser(user) {
    try {
        const response = await api.post(`auth?username=${user.username}&password=${user.password}`)
        .then((response) => {
            Router.push("/containermanagement")
            const token = response.data.token;
            localStorage.setItem('token', token);
            return response.data
        });
        return response.data;
    } catch (error) {
        console.log(error);
        throw error; 
    }
}