import './style.scss'
import React from 'react';
import SideBar from '../../components/Product/SideBar';
import SubNav from '../../components/Product/Subnav';
import ProductList from '../../components/Product/ProductList';
import Header from '../../layouts/Header';

function Product() {
    return (
        <div className="container-fluid product">
            <div id="catalog" className="row">
                <img src="./img/catalog.png" alt="" />
            </div>

            <div id="ads" className="row">
                <div>Free shipping for orders over 1 million VND</div>
            </div>
            
            {/* Header */}
            <Header />

            <div className="row container-body">
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
