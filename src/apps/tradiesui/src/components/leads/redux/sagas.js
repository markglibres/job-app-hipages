import { call, put, takeLatest } from 'redux-saga/effects';
import services from '../services';
import { 
    GET_INVITED_LEADS_REQUESTED,
    setInvitedLeads
} from './actions';

function* getInvitedLeadsWorker() {
    try {
        var response = yield call(services.getInvitedLeads);
        yield put(setInvitedLeads(response.data));
    } catch(e) {
        
    }
}

function* invitedLeadsSaga (){
    yield takeLatest(GET_INVITED_LEADS_REQUESTED, getInvitedLeadsWorker);
}

export default invitedLeadsSaga;