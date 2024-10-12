import React from 'react';
import Product from "../../../components/product/Product";
import './UserBrandShoes.scss'
import SectionTitle from "../../../components/section-title/SectionTitle";

const UserBrandShoes = () => {
    return (
        <div className="brand-shoes">
            <div className="container-fluid">
                <div className="row g-0">
                    <div className="col-8">
                        <div className="row g-0">
                            <SectionTitle title="BRAND SHOES."></SectionTitle>
                        </div>
                        <div className="row g-0">
                            <div className="col"><Product src="/product-8.svg"></Product></div>
                            <div className="col"><Product src="/product-9.svg"></Product></div>
                        </div>
                    </div>
                    <div className="col-4">
                        <Product src="/product-10.svg"></Product>
                    </div>
                </div>
                
            </div>
        </div>
    );
};

export default UserBrandShoes;