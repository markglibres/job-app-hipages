import { makeStyles } from '@material-ui/core/styles';
import { grey } from '@material-ui/core/colors';

const useStyles = makeStyles((theme) => ({
    root : {
        width: 900,
        backgroundColor: grey[300],
        padding: 10
    },
    tabs: {
        backgroundColor:'#ffffff',
    },
    tabContent: {
        backgroundColor: '#ffffff',
        marginTop: 15,
        padding: 0,
        color: grey[600]
    },
    avatar: {
      color: '#fff',
      backgroundColor: theme.palette.primary[400],
    },
    listItem: {
      paddingTop: 15,
      paddingBottom: 15,
      paddingLeft: 0,
      paddingRight: 0
    },
    primaryButton: {
        color: '#fff',
    },
    emphasis: {
        color: '#000',
        fontWeight: 'bold'
    },
    bold: {
        fontWeight: 'bold'
    },
    description: {
        fontSize: theme.typography.fontSize - 1,
    },
    contact: {
        color: theme.palette.primary[400],
        fontWeight: 'bold'
    }
  }));

  export default useStyles;