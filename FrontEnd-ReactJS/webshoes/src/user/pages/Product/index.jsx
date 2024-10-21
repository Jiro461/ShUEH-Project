import './style.scss'
import React from 'react';
import SideBar from '../../components/Product/SideBar';
import SubNav from '../../components/Product/Subnav';
import ProductList from '../../components/Product/ProductList';

function Product() {
    return (
        <div className="container-fluid">
            {/* Header */}
            {/* <Header /> */}
            <div className="row product">
                <SideBar />
                <div className="col content">
                    <SubNav />
                    <ProductList />
                </div>
            </div>
        </div>
    );
}

export default Product;
