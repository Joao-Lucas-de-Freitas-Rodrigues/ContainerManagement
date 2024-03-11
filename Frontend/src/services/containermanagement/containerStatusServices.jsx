import api from '../../api/config'
import Router from 'next/router';
import 'react-toastify/dist/ReactToastify.css';

export async function getStatus() {
    var response = await api.get('/containerstatus')
        .then((response) => {
            return response.data
        })
        .catch((err) => {
            return console.log(err)
        })
    return response;
}


