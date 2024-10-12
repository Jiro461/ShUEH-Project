import React from 'react';
import './ProductPopular.scss'
import TagNew from "../tag/new/TagNew";
import PromotionTag from "../promotion-tag/PromotionTag";

const ProductPopular = () => {
    return (
        <div className="popular-product">
            <div className="info">
                <TagNew></TagNew>
                <span className="info-title">PRODUCT</span>
                <span className="info-title">NO.###</span>
                <span className="info-title">300000$</span>

                <button>Go to Catalog</button>
            </div>
            <div className="title">
                BRAND
            </div>
            <div className="product">
                <img src="/popular-product.svg" alt=""></img>
                <img className="line-decor-1" src="/popular-line-decor-2.svg" alt=""></img>
                <div className="promotion-block">
                    <PromotionTag></PromotionTag>
                </div>
                <div className="product-info">
                    <span className="product-brand">SHUEH</span>
                    <span className="product-name">OUTDOORS</span>
                </div>
            </div>
            <div className="line-decor-2">
                <img src="/popular-line-decor-1.svg" alt=""></img>
            </div>
        </div>
    );
};

export default ProductPopular;