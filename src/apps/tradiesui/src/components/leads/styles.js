import { makeStyles } from '@material-ui/core/styles';
import { grey } from '@material-ui/core/colors';

const useStyles = makeStyles((theme) => ({
    root : {
        width: 800,
        backgroundColor: grey[300],
        padding: 10
    },
    tabs: {
        backgroundColor:'#ffffff',
    },
    tabContent: {
        backgroundColor: '#ffffff',
        marginTop: 15,
        padding: 0
    },
    avatar: {
      color: theme.palette.getContrastText(theme.palette.primary[500]),
      backgroundColor: theme.palette.primary[500],
    },
    listItem: {
      paddingTop: 10,
      paddingBottom: 10,
    }
  }));

  export default useStyles;