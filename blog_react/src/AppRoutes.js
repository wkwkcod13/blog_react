import { Home } from './components/Home';
import { Posts } from './components/Posts';
import { PostEdit } from './components/PostEdit';
import { Pages } from './components/Pages';
import { Themes } from './components/Themes';
import { Layout } from './components/Layout';
import { Dates } from './components/Dates';


const AppRoutes = [
    {
        index: true,
        element: <Home></Home>
    },
    {
        path: '/posts',
        element: <Posts></Posts>
    },
    {
        path: '/posts/edit',
        element: <PostEdit></PostEdit>
    },
    {
        path: '/pages',
        element: <Pages></Pages>
    },
    {
        path: '/themes',
        element: <Themes></Themes>
    },
    {
        path: '/layout',
        element: <Layout></Layout>
    },
    {
        path: '/dates',
        element:<Dates></Dates>
    }
];
export default AppRoutes;