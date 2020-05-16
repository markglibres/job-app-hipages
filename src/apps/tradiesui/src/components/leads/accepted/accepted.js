import React from 'react';
import { Container, Typography } from '@material-ui/core';
import AcceptedItem from './accepted.item';

const Accepted = (props) => {

    const {
        show,
        acceptedLeads
    } = props;

    return (
        show &&
        <Container>
           
            {acceptedLeads && acceptedLeads.map((lead, index) => (
                 <AcceptedItem key={`invited-${index}`} 
                    {...lead}
                 />
            ))}
            {!acceptedLeads && <Typography>Sorry, nothing to show</Typography>}
        </Container>
    );
};

export default Accepted;