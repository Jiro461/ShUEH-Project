import React from 'react';
import Product from './pages/Product';
import PropTypes from 'prop-types';
import SideBar from './components/Product/SideBar';
import ProductDetail from './pages/ProductDetail';
import PaymentPage from './pages/PaymentPage';
import Profile from './pages/ProfilePage';
import { Link, Outlet, BrowserRouter, Route, Routes } from 'react-router-dom';

const UserClient = (props) => {
    return (
        <> 
            <Outlet />
        </>
    )
};


export default UserClient;