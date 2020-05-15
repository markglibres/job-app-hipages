import React from 'react';
import { Grid } from '@material-ui/core';
import Leads from '../../components/leads';

const Home = () => (
    <Grid
        container
        justify="center"
        alignItems="flex-start">
        <Leads />
    </Grid>
);

export default Home;