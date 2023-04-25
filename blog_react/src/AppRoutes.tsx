import { Home } from './components/Home';
import { Posts } from './components/Posts';
import { PostEdit } from './components/PostEdit';
import { Pages } from './components/Pages';
import { Themes } from './components/Themes';
import { Layout } from './components/Layout';
import { Dates } from './components/Dates';
import { Login } from './components/Login';
import { useParams } from 'react-router-dom';
import React from 'react';

//function PostEditWithId() {
//    // wrap the PostEdit component with the id prop
//    const { id } = useParams() ?? "";
//    return <PostEdit id={id} />;
//}

const AppRoutes = [
    {
        index: true,
        element: <Home></Home>
    },
    {
        path: '/posts',
        element: <Posts></Posts>
    },
    //{
    //    path: '/posts/:id',
    //    element:<PostEditWithId></PostEditWithId>
    //},
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
        element: <Dates></Dates>
    },
    {
        path: '/login',
        element: <Login></Login>
    }
];
export default AppRoutes;