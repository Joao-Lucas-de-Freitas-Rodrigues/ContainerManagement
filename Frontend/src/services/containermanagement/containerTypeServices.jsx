import api from '../../api/config'
import Router from 'next/router';
import 'react-toastify/dist/ReactToastify.css';

export async function getType() {
    var response = await api.get('/containertype')
        .then((response) => {
            return response.data
        })
        .catch((err) => {
            return console.log(err)
        })
    return response;
}