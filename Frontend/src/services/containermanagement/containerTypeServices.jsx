import api from '../../api/config'
import 'react-toastify/dist/ReactToastify.css';

export async function getType() {
    const response = await api.get('/containertype')
        .then((response) => {
            return response.data
        })
        .catch((err) => {
            return console.log(err)
        })
    return response;
}