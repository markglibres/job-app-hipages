import { connect } from 'react-redux';
import Leads from './leads';
import { 
    getInvitedLeadsRequested,
    getAcceptedLeadsRequested, 
} from './redux/actions';


const mapDispatchToProps = (dispatch) => ({
    getInvitedLeads: () => dispatch(getInvitedLeadsRequested()),
    getAcceptedLeads: () => dispatch(getAcceptedLeadsRequested()),
});

const enhance = connect(null, mapDispatchToProps);
export default enhance(Leads);

