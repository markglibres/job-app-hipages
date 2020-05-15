import { connect } from 'react-redux';
import Invited from './invited';

const mapStateToProps = (state) => ({
    invitedLeads: state.leads ? state.leads.invited : null
});

const enhance = connect(mapStateToProps);
export default enhance(Invited);

