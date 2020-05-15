import config from '../../../config';
import axios from 'axios';

const getAcceptedLeadsResponse = async () => {
    return await axios.get(`${config.apiBaseUrl}/leads/accepted`);
};

const getAcceptedLeads = async () => {
    var response = await getAcceptedLeadsResponse();
    return response.data;
};

export default getAcceptedLeads;