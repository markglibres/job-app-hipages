import { connect } from 'react-redux';
import Leads from './leads';
import { getInvitedLeadsRequested } from '../../redux/invitedleads/actions';


const mapDispatchToProps = (dispatch) => ({
    getInvitedLeads: () => dispatch(getInvitedLeadsRequested())
});

const enhance = connect(null, mapDispatchToProps);
export default enhance(Leads);

