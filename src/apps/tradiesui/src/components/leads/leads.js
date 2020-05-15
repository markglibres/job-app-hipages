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
        getInvitedLeads
    } = props;

    const classes = useStyles();
    
    useEffect(() => {
        if(value === 0) getInvitedLeads();
    },[value, getInvitedLeads]);

    return (
        <Grid classes={{root: classes.root }}>
            <Tabs
                classes={{root: classes.tabs }}
                value={value}
                onChange={handleChange}
                indicatorColor="primary"
                textColor="primary"
                variant="fullWidth"
            >
                <Tab label="Invited" />
                <Tab label="Accepted" />
            </Tabs>
            <Paper classes={{root: classes.tabContent}} >
                <Invited show={value === 0}/>
            </Paper> 
            <Paper classes={{root: classes.tabContent}} >
                <Accepted show={value === 1}/>
            </Paper>
        </Grid>
    );
};

export default Leads;