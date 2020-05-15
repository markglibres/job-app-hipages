import { connect } from 'react-redux';
import Accepted from './accepted';

const mapStateToProps = (state) => ({
    acceptedLeads: state.leads ? state.leads.accepted : null
});

const enhance = connect(mapStateToProps);
export default enhance(Accepted);

