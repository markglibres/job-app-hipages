import { createMuiTheme } from '@material-ui/core/styles';
import orange from '@material-ui/core/colors/orange';
import grey from '@material-ui/core/colors/grey';

const orangeTheme = createMuiTheme({
    typography: {
        fontFamily: 'Verdana',
        fontSize: 12
    },
    palette: {
        primary: orange,
        secondary: grey,
    },
    status: {
        danger: 'red',
    },
    spacing: [0, 4, 8, 16, 32, 64],
});

export default orangeTheme;