import Home from './home';

const Pages = [
    {
        routeProps: {
            exact: true,
            path: '/',
            component: Home
        },
        name: 'Home',
        nav: 'main',
        defaultPage: true
    }
];

export default Pages;