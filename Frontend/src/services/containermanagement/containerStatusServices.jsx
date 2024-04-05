import api from '../../api/config'
import 'react-toastify/dist/ReactToastify.css';

export async function getStatus() {
    const response = await api.get('/containerstatus')
        .then((response) => {
            return response.data
        })
        .catch((err) => {
            return console.log(err)
        })
    return response;
}


