import { call, put, takeLatest } from 'redux-saga/effects';
import services from '../services';
import { 
    GET_INVITED_LEADS_REQUESTED,
    setInvitedLeads,
    GET_ACCEPTED_LEADS_REQUESTED,
    setAcceptedLeads,
    EXECUTE_INVITED_ACTION,
    getInvitedLeadsRequested,
} from './actions';

function* getInvitedLeadsWorker() {
    try {
        var response = yield call(services.getInvitedLeads);
        yield put(setInvitedLeads(response));
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
        yield put(setAcceptedLeads(response));
    } catch(e) {
        console.log('error', e);
    }
}

export function* acceptedLeadsSaga (){
    yield takeLatest(GET_ACCEPTED_LEADS_REQUESTED, getAcceptedLeadsWorker);
}

function* executeInvitedActionWorker(params) {
    try {
        yield call(services.executeInvitedAction, params.payload);
        yield put(getInvitedLeadsRequested());
    } catch(e) {
        console.log('error', e);
    }
}

export function* executeInvitedActionSaga (){
    yield takeLatest(EXECUTE_INVITED_ACTION, executeInvitedActionWorker);
}