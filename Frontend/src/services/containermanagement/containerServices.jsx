import api from '../../api/config'
import Router from 'next/router';
import 'react-toastify/dist/ReactToastify.css';

export async function getContainer() {
    const response = await api.get('/container')
        .then((response) => {
            return response.data
        })
        .catch((err) => {
            return console.log(err)
        })
    return response;
}

export async function postContainer(values) {
    const response = await api.post('/container', values)
        .then(() => {
            Router.push('/containermanagement')
        })
        .catch((err) => {
            return console.log(err.response.status)
        })
    return response;
}

export async function getContainerId(id) {
    const response = await api.get('/container/' + id)
        .then((response) => {
            return response.data
        })
        .catch((err) => {
            return console.log(err.response.status)
        })
    return response;
}

export async function putContainer(id, values) {
    const response = await api.put('/container/' + id, values)
        .then(() => {
            Router.push('/containermanagement')
        })
        .catch((err) => {
            return console.log(err.response.status)
        })
    return response;
}

export async function deleteContainer(id) {
    const response = await api.delete('/container/' + id)
        .then(() => {
            Router.push('/containermanagement')
        })
        .catch((err) => {
            return console.log(err.response.status)
        })
    return response;
}


