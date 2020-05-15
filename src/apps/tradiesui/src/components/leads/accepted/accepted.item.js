import React from 'react';
import { Grid, Typography, Box } from '@material-ui/core';
import useStyles from '../styles';
import Avatar from '@material-ui/core/Avatar';
import Moment from 'react-moment';
import RoomOutlinedIcon from '@material-ui/icons/RoomOutlined';
import ClassOutlinedIcon from '@material-ui/icons/ClassOutlined';
import LocalPhoneOutlinedIcon from '@material-ui/icons/LocalPhoneOutlined';
import EmailOutlinedIcon from '@material-ui/icons/EmailOutlined';
import List from '@material-ui/core/List';
import ListItem from '@material-ui/core/ListItem';
import Divider from '@material-ui/core/Divider';

const AcceptedItem = (props) => {

    const classes = useStyles();
    const {
        firstname,
        dateCreated,
        suburb,
        category,
        id,
        description,
        price,
        contact,
    } = props;

    var name = contact.fullname ? contact.fullname : firstname;
    return (
        <List>
            <ListItem className={classes.listItem}>
                <Box pl={3} pr={2} >
                    <Avatar className={classes.avatar}>{name.charAt(0).toUpperCase()}</Avatar>
                </Box>
                <Grid>
                    <Typography className={classes.emphasis}>{name}</Typography>
                    <Moment format="MMMM DD @ hh:mm a">{dateCreated}</Moment>
                </Grid>
            </ListItem>
            <Divider light/>
            <ListItem className={classes.listItem}>
                <RoomOutlinedIcon />
                <Box mr={3}><Typography>{suburb}</Typography></Box>
                <ClassOutlinedIcon/>
                <Box mr={3}><Typography>{category}</Typography></Box>
                <Box mr={3}><Typography>Job ID: {id}</Typography></Box>
                <Typography>$ {parseFloat(price).toFixed(3)} Lead Invitation</Typography>
            </ListItem>
            <Divider light/>
            <ListItem className={classes.listItem}> 
                <LocalPhoneOutlinedIcon />
                <Box mr={3}><Typography className={classes.contact}>{contact.phone}</Typography></Box>
                <EmailOutlinedIcon/>
                <Box mr={3}><Typography className={classes.contact}>{contact.email}</Typography></Box>
            </ListItem>
            <ListItem className={classes.listItem}> 
                <Typography className={classes.description}>{description}</Typography>
            </ListItem>
        </List>
    );
};

export default AcceptedItem;