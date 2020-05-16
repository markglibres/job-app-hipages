import { connect } from 'react-redux';
import Invited from './invited';
import { 
    executeInvitedAction
} from '../redux/actions';

const mapStateToProps = (state) => ({
    invitedLeads: state.leads ? state.leads.invited : null
});

const mapDispatchToProps = (dispatch) => ({
    executeAction: (options) => dispatch(executeInvitedAction(options)),
});

const enhance = connect(mapStateToProps, mapDispatchToProps);
export default enhance(Invited);

