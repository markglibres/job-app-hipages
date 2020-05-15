import { SET_INVITED_LEADS  } from './actions';
const initialState = null;

const invitedLeads = (state = initialState, action) => {
  switch (action.type) {
    case SET_INVITED_LEADS: {
      return {
          ...state,
          data: action.payload
      };
    }
    default: {
      return state;
    }
  }
};

export default invitedLeads;