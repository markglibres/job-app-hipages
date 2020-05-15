export const GET_INVITED_LEADS_REQUESTED = 'GET_INVITED_LEADS_REQUESTED';
export const SET_INVITED_LEADS = 'SET_INVITED_LEADS';
export const GET_ACCEPTED_LEADS_REQUESTED = 'GET_ACCEPTED_LEADS_REQUESTED';
export const SET_ACCEPTED_LEADS = 'SET_ACCEPTED_LEADS';


export const getInvitedLeadsRequested = () => {
    return { type: GET_INVITED_LEADS_REQUESTED, payload: {} };
}; 

export const setInvitedLeads = (payload) => {
    return { type: SET_INVITED_LEADS, payload };
};

export const getAcceptedLeadsRequested = () => {
    return { type: GET_ACCEPTED_LEADS_REQUESTED, payload: {} };
}; 

export const setAcceptedLeads = (payload) => {
    return { type: SET_ACCEPTED_LEADS, payload };
};