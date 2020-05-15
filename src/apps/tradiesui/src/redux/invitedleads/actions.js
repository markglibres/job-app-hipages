export const GET_INVITED_LEADS_REQUESTED = 'GET_INVITED_LEADS_REQUESTED';
export const SET_INVITED_LEADS = 'SET_INVITED_LEADS';

export const getInvitedLeadsRequested = () => {
    return { type: GET_INVITED_LEADS_REQUESTED, payload: {} };
}; 

export const setInvitedLeads = (payload) => {
    return { type: SET_INVITED_LEADS, payload };
};