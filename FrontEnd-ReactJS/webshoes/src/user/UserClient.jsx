import React from 'react';
import Product from './pages/Product';
import PropTypes from 'prop-types';
import SideBar from './components/Product/SideBar';
import ProductDetail from './pages/ProductDetail';
import PaymentPage from './pages/PaymentPage';

const UserClient = (props) => {
    return (
        <>
            <Product />
            <ProductDetail />
            <PaymentPage />
         </>
    );
};


export default UserClient;