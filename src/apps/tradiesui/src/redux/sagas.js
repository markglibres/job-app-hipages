import { all, fork } from 'redux-saga/effects';
import invitedLeadsSaga from './invitedleads/sagas';

export default function* rootSaga(){
    yield all ([
        fork(invitedLeadsSaga),
    ]);
};
