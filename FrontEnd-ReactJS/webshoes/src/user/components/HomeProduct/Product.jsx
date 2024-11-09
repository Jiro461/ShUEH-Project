import React from 'react';
import './Product.scss' 
import PromotionTagNew from '../PromotionTagNew/PromotionTagNew'
import PromotionSale from '../PromotionSale/PromotionSale'

const Product = ({width, productName, productBrand, imgClassName, imgSrc, isSale, discount, isNew, price, originalPrice}) => {
    return (
        <div className="product-home" style={{width: width || ""}}>
            <div className="info">
                <div className="title">
                    <p className="title-line-1">{productName}</p>
                    <p className="title-line-2">{productBrand}</p>
                </div>
                <img src="/heart-icon.svg" alt=""></img>
            </div>
            <div className="img-box">
                <img className={`img-product ${imgClassName}` || ""} style={{width:"100%" || ""}} src={imgSrc} alt=""></img>
                {isSale && <div className="product-promotion-sale">
                    <PromotionSale discount={discount}></PromotionSale>
                </div>}
                {isNew && <div className="product-promotion-tag-new">
                    <PromotionTagNew fz="1vw"></PromotionTagNew>
                </div>}
            </div>
            <div className={`product-price ${isSale ? "" : "single-price"}`}>
                {isSale && <span className="original-price">{originalPrice}đ</span>}
                <span className="sale-price">{price}đ</span>
            </div>
        </div>
    );
};

export default Product;