import { call, put, takeLatest } from 'redux-saga/effects';
import services from '../services';
import { 
    GET_INVITED_LEADS_REQUESTED,
    setInvitedLeads,
    GET_ACCEPTED_LEADS_REQUESTED,
    setAcceptedLeads,
} from './actions';

function* getInvitedLeadsWorker() {
    try {
        var response = yield call(services.getInvitedLeads);
        yield put(setInvitedLeads(response.data));
    } catch(e) {
        console.log('error', e);
    }
}

export function* invitedLeadsSaga (){
    yield takeLatest(GET_INVITED_LEADS_REQUESTED, getInvitedLeadsWorker);
}

function* getAcceptedLeadsWorker() {
    try {
        var response = yield call(services.getAcceptedLeads);
        yield put(setAcceptedLeads(response.data));
    } catch(e) {
        console.log('error', e);
    }
}

export function* acceptedLeadsSaga (){
    yield takeLatest(GET_ACCEPTED_LEADS_REQUESTED, getAcceptedLeadsWorker);
}