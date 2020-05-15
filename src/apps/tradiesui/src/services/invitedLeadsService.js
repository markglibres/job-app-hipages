import config from '../config';
import axios from 'axios';

const getInvitedLeadsResponse = async () => {
    return await axios.get(`${config.apiBaseUrl}/leads/invited`);
};

const getInvitedLeads = async () => {
    var response = await getInvitedLeadsResponse();
    return response.data;
};

export default getInvitedLeads;