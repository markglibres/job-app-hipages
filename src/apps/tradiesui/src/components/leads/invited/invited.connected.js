import { connect } from 'react-redux';
import Invited from './invited';

const mapStateToProps = (state) => ({
    invitedLeads: state.invitedLeads ? state.invitedLeads.data : null
});

const enhance = connect(mapStateToProps);
export default enhance(Invited);

