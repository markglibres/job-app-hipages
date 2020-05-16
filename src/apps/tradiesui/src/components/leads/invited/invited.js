import React from 'react';
import { Container, Typography } from '@material-ui/core';
import InvitedItem from './invited.item';

const Invited = (props) => {

    const {
        show,
        invitedLeads,
        executeAction,
    } = props;

    return (
        show &&
        <Container>
           
            {invitedLeads && invitedLeads.map((lead, index) => (
                 <InvitedItem 
                    key={`invited-${index}`}
                    executeAction={executeAction}
                    {...lead}
                 />
            ))}
            {!invitedLeads && <Typography>Sorry, nothing to show</Typography>}
        </Container>
    );
};

export default Invited;