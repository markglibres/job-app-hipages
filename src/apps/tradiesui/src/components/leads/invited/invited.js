import React from 'react';
import { Container, Typography } from '@material-ui/core';
import InvitedItem from './invited.item';
import { v4 as uuidv4 } from 'uuid';

const Invited = (props) => {

    const {
        show,
        invitedLeads,
        executeAction,
    } = props;

    return (
        show &&
        <Container>
           
            {invitedLeads && invitedLeads.map(lead => (
                 <InvitedItem 
                    key={uuidv4()}
                    executeAction={executeAction}
                    {...lead}
                 />
            ))}
            {!invitedLeads && <Typography>Sorry, nothing to show</Typography>}
        </Container>
    );
};

export default Invited;