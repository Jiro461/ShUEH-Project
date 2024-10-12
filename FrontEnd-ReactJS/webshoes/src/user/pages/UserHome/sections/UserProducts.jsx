import React from 'react';
import './UserProducts.scss'
import Product from "../../../components/product/Product";

const UserProducts = () => {
    return (
        <div className="products">

            <h3>PRODUCTS</h3>
            
            <div className="navbar">
                <ul>
                    <li>Nike<span>(123)</span></li>
                    <li>Adidas<span>(123)</span></li>
                    <li>Puma<span>(123)</span></li>
                    <li>Rebok<span>(123)</span></li>
                    <li>Converse<span>(123)</span></li>
                </ul>
                <ul>
                    <li>Newest</li>
                    <li>VN size</li>
                    <li>X</li>
                </ul>
            </div>

            <div className="container-fluid">
                <div className="row g-0">
                    <div className="col-4 g-0">
                        <Product className='img-custom' src="/product-1.svg"></Product>
                    </div>
                    <div className="col-8">
                        <div className="row">
                            <div className="col">
                                <Product src="/product-2.svg"></Product>
                            </div>
                            <div className="col">
                                <Product src="/product-3.svg"></Product>
                            </div>
                        </div>
                        <div className="row g-0">
                            <div className="col">
                                <Product src="/product-4.svg"></Product>
                            </div>
                        </div>
                    </div>
                </div>

                <div className="row g-0">
                    <div className="col">
                        <Product src="/product-5.svg"></Product>
                    </div>
                    <div className="col">
                        <Product src="/product-6.svg"></Product>
                    </div>
                    <div className="col">
                        <Product src="/product-7.svg"></Product>
                    </div>
                </div>
                
            </div>
        </div>
    );
};

export default UserProducts;