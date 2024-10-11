import React from 'react';
import Product from './pages/Product';
import PropTypes from 'prop-types';
import SideBar from './components/Product/SideBar';
import ProductDetail from './pages/ProductDetail';

const UserClient = (props) => {
    return (
        <>
            {/* <Product /> */}
            <ProductDetail />
         </>
    );
};


export default UserClient;