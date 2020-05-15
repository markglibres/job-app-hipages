import React, { useState, useEffect } from 'react'
import { Tabs, Tab, Grid, Paper } from '@material-ui/core';
import Invited from './invited';
import Accepted from  './accepted';
import useStyles from './styles';

const Leads = (props) => {

    const [value, setValue] = useState(0);

    const handleChange = (event, newValue) => {
        setValue(newValue);
    };

    const {
        getInvitedLeads,
        getAcceptedLeads,
    } = props;

    const classes = useStyles();
    
    useEffect(() => {
        if(value === 0) getInvitedLeads();
        if(value === 1) getAcceptedLeads();
    },[value, getInvitedLeads, getAcceptedLeads]);

    return (
        <Grid className={classes.root}>
            <Tabs
                className={classes.tabs}
                value={value}
                onChange={handleChange}
                indicatorColor="primary"
                textColor="primary"
                variant="fullWidth"
            >
                <Tab label="Invited" className={classes.bold}/>
                <Tab label="Accepted" className={classes.bold}/>
            </Tabs>
            <Paper className={classes.tabContent} >
                <Invited show={value === 0}/>
            </Paper> 
            <Paper className={classes.tabContent} >
                <Accepted show={value === 1}/>
            </Paper>
        </Grid>
    );
};

export default Leads;