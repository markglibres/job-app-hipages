import config from '../../../config';
import axios from 'axios';
import halson from 'halson';

const getInvitedLeadsResponse = async () => {
    return await axios.get(`${config.apiBaseUrl}/leads/invited`);
};

export const getInvitedLeads = async () => {
    var response = await getInvitedLeadsResponse();

    var leads = halson(response.data);
    return leads.getEmbeds('leads');
};

export const executeInvitedAction = async (options) => {

    var config = {
        method: options.method,
        url: options.href,
    };
    return await axios(config);
};
