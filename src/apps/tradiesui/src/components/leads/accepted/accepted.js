import React from 'react';
import { Container, Typography } from '@material-ui/core';

const Accepted = (props) => {

    const {
        show
    } = props;

    return (
        show && <Container>
            <Typography>This is Accepted tab</Typography>
        </Container>
    );
};

export default Accepted;