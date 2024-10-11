import './style.scss'
import React from 'react';
import SideBar from '../../components/Product/SideBar';
import SubNav from '../../components/Product/Subnav';
import ProductList from '../../components/Product/ProductList';

function Product() {
    return (
        <div className="container-fluid product">
            <div id="catalog" className="row">
                <img src="./img/catalog.png" alt="" />
            </div>

            <div id="ads" className="row">
                <div>Free shipping for orders over 1 million VND</div>
            </div>
            
            <div className="row header" />

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
