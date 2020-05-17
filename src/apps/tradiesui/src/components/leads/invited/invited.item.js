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
import { v4 as uuidv4 } from 'uuid';

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
        executeAction,
        _links,
    } = props;

    return (
        <List>
            <ListItem className={classes.listItem}>
                <Box pl={3} pr={2} >
                    <Avatar className={classes.avatar}>{firstname.charAt(0).toUpperCase()}</Avatar>
                </Box>
                <Grid>
                    <Typography className={classes.emphasis}>{firstname}</Typography>
                    <Moment format="MMMM DD @ hh:mm a">{dateCreated}</Moment>
                </Grid>
            </ListItem>
            <Divider light/>
            <ListItem className={classes.listItem}>
                <RoomOutlinedIcon />
                <Box mr={3}><Typography>{suburb}</Typography></Box>
                <ClassOutlinedIcon/>
                <Box mr={3}><Typography>{category}</Typography></Box>
                <Typography>Job ID: {id}</Typography>
            </ListItem>
            <Divider light/>
            <ListItem className={classes.listItem}> 
                <Typography className={classes.description}>{description}</Typography>
            </ListItem>
            <Divider light/>
            <ListItem className={classes.listItem}>
                {_links && Object.values(_links).map(link => (
                    link.rel !== 'self' && 
                    <Box mr={3} key={uuidv4()}>
                        <Button 
                            variant="contained"
                            color={link.name}
                            classes={link.name === 'primary' ? {root: classes.primaryButton}: {}}
                            onClick={() => { executeAction(link); }}>
                                {link.title}
                        </Button>
                    </Box>
                ))}
                <Grid container direction="row">
                    <Box  mr={2} fontWeight="fontWeightBold" className={classes.emphasis}>$ {parseFloat(price).toFixed(3)}</Box>
                    <Typography>Lead Invitation</Typography>
                </Grid>
                
            </ListItem>
        </List>
    );
};

export default InvitedItem;