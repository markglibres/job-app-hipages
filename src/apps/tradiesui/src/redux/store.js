import { createStore, applyMiddleware, compose } from "redux";
import rootReducer from "./reducers";
import createSagaMiddleware from 'redux-saga';
import rootSaga from './sagas';
import { composeWithDevTools } from 'redux-devtools-extension';

const sagaMiddleware = createSagaMiddleware();

const initialState = {};

const createStoreWithMiddleware = compose(
    composeWithDevTools(
        applyMiddleware(sagaMiddleware)
    ),
)(createStore);

const store = createStoreWithMiddleware(rootReducer, initialState);

sagaMiddleware.run(rootSaga);

export default store;