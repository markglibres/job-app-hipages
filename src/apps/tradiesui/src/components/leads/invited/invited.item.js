import React from 'react';
import { Grid, Typography, Button, Box } from '@material-ui/core';
import useStyles from '../styles';
import Avatar from '@material-ui/core/Avatar';
import Moment from 'react-moment';
import RoomOutlinedIcon from '@material-ui/icons/RoomOutlined';
import ClassOutlinedIcon from '@material-ui/icons/ClassOutlined';
import List from '@material-ui/core/List';
import ListItem from '@material-ui/core/ListItem';
import Divider from '@material-ui/core/Divider';

const InvitedItem = (props) => {

    const classes = useStyles();
    const {
        firstname,
        dateCreated,
        suburb,
        category,
        id,
        description,
        price,
    } = props;

    return (
        <List>
            <ListItem classes={{ root: classes.listItem }}>
                <Box pl={3} pr={2}>
                    <Avatar className={classes.avatar}>M</Avatar>
                </Box>
                <Grid>
                    <Typography>{firstname}</Typography>
                    <Moment format="MMMM DD @ hh:mm a">{dateCreated}</Moment>
                </Grid>
            </ListItem>
            <Divider light/>
            <ListItem classes={{ root: classes.listItem }}>
                <RoomOutlinedIcon />
                <Box mr={3}><Typography>{suburb}</Typography></Box>
                <ClassOutlinedIcon/>
                <Box mr={3}><Typography>{category}</Typography></Box>
                <Typography>Job ID: {id}</Typography>
            </ListItem>
            <Divider light/>
            <ListItem classes={{ root: classes.listItem }}> 
                <Typography>{description}</Typography>
            </ListItem>
            <Divider light/>
            <ListItem classes={{ root: classes.listItem }}>
                <Box mr={3}><Button variant="contained" color="primary">Accept</Button></Box>
                <Box mr={4}><Button variant="contained" >Decline</Button></Box>
                <Grid container direction="row">
                    <Box  mr={2} fontWeight="fontWeightBold">$ {parseFloat(price).toFixed(3)}</Box>
                    <Typography>Lead Invitation</Typography>
                </Grid>
                
            </ListItem>
        </List>
    );
};

export default InvitedItem;