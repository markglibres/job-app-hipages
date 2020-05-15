import { createMuiTheme } from '@material-ui/core/styles';
import orange from '@material-ui/core/colors/orange';
import grey from '@material-ui/core/colors/grey';

const orangeTheme = createMuiTheme({
    typography: {
        fontFamily: 'Verdana',
        fontSize: 14
    },
    palette: {
        primary: orange,
        secondary: grey,
    },
    status: {
        danger: 'red',
    }
});

export default orangeTheme;