import config from '../../../config';
import axios from 'axios';
import halson from 'halson';

const getAcceptedLeadsResponse = async () => {
    return await axios.get(`${config.apiBaseUrl}/leads/accepted`);
};

const getAcceptedLeads = async () => {
    var response = await getAcceptedLeadsResponse();
    var leads = halson(response.data);
    return leads.getEmbeds('leads');
};

export default getAcceptedLeads;