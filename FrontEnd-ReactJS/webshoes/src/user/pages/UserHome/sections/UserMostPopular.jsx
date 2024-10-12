import React from 'react';
import './UserMostPopular.scss'
import ProductPopular from "../../../components/product-popular/ProductPopular";
import SectionTitle from "../../../components/section-title/SectionTitle";

const UserMostPopular = () => {
    return (
        <div className="user-most-popular">
            <div className="title">
                <SectionTitle title="MOST POPULAR"></SectionTitle>
            </div>
            <div className="product-popular">
                <div className="sub-left fit-content">
                    <ProductPopular></ProductPopular>
                </div>
                <div className="center-product fit-content">
                    <ProductPopular></ProductPopular>
                </div>
                <div className="sub-right fit-content">
                    <ProductPopular></ProductPopular>
                </div>
            </div>
        </div>
    );
};

export default UserMostPopular;