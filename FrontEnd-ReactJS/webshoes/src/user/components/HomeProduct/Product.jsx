import React from 'react';
import './Product.scss' 
import PromotionTagNew from '../PromotionTagNew/PromotionTagNew'
import PromotionSale from '../PromotionSale/PromotionSale'

const Product = ({width, imgClassName, imgSrc, sale, originalPrice, salePrice}) => {
    return (
        <div className="home-product" style={{width: width || ""}}>
            <div className="info">
                <div className="title">
                    <p className="title-line-1">Nike air force brutus cecia </p>
                    <p className="title-line-2">nike air force 1 automating</p>
                </div>
                <img src="/heart-icon.svg" alt=""></img>
            </div>
            <div className="img-container">
                <img className={`img-product ${imgClassName || ""}`} style={{width:"100%" || ""}} src={imgSrc} alt=""></img>
                <div className="product-promotion-sale">
                    <PromotionSale sale={sale}></PromotionSale>
                </div>
                <div className="product-promotion-tag-new">
                    <PromotionTagNew fz="1vw"></PromotionTagNew>
                </div>
            </div>
            <div className="product-price">
                <span className="original-price">$320</span>
                <span className="sale-price">$250</span>
            </div>
        </div>
    );
};

export default Product;