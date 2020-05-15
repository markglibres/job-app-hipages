import { all, fork } from 'redux-saga/effects';
import { 
    invitedLeadsSaga,
    acceptedLeadsSaga,
} from '../components/leads/redux/sagas';

export default function* rootSaga(){
    yield all ([
        fork(invitedLeadsSaga),
        fork(acceptedLeadsSaga),
    ]);
};
