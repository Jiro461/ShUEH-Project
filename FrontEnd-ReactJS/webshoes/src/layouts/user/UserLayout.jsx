import React from 'react';
import Product from '../../user/pages/Product';
import PropTypes from 'prop-types';
import SideBar from '../../user/components/Product/SideBar';
import ProductDetail from '../../user/pages/ProductDetail';
import PaymentPage from '../../user/pages/PaymentPage';
import Profile from '../../user/pages/ProfilePage';
import { Link, Outlet, BrowserRouter, Route, Routes } from 'react-router-dom';

const UserLayout = (props) => {
    return (
        <> 
            <Outlet />
        </>
    )
};


export default UserLayout;