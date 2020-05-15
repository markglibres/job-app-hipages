import React from 'react';
import {  Route, withRouter } from 'react-router-dom';
import Pages from './pages';
import { Grid } from '@material-ui/core';
import { ThemeProvider  } from '@material-ui/core/styles';
import themes from './styles';

function App() {
  return (
    <ThemeProvider theme={themes.orangeTheme}>
      <Grid container>
        {Pages.map(page => (
          <Route {...page.routeProps} key={page.name} />
        ))}
      </Grid>
    </ThemeProvider>
  );
}

export default withRouter(App);
