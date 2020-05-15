import { 
  SET_INVITED_LEADS,
  SET_ACCEPTED_LEADS,
} from './actions';
const initialState = null;

const leads = (state = initialState, action) => {
  switch (action.type) {
    case SET_INVITED_LEADS: {
      return {
          ...state,
          invited: action.payload
      };
    }
    case SET_ACCEPTED_LEADS: {
      return {
          ...state,
          accepted: action.payload
      };
    }
    default: {
      return state;
    }
  }
};

export default leads;