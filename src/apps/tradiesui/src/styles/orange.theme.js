import { createMuiTheme } from '@material-ui/core/styles';
import deepOrange from '@material-ui/core/colors/deepOrange';
import grey from '@material-ui/core/colors/grey';

const orange = createMuiTheme({
  palette: {
    primary: deepOrange,
    secondary: grey,
  },
  status: {
    danger: 'red',
  },
  spacing: [0, 4, 8, 16, 32, 64],
});

export default orange;