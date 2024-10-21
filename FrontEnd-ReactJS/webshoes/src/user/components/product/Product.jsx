import React from 'react';
import './Product.scss' 

const Product = ({width, imgClassName, imgSrc}) => {
    return (
        <div className="product" style={{width: width || ""}}>
            <div className="info">
                <div className="title">
                    <p className="title-line-1">Nike air force brutus cecia </p>
                    <p className="title-line-2">nike air force 1 automating</p>
                </div>
                <img src="/heart-icon.svg" alt=""></img>
            </div>
            <img className={`img-product ${imgClassName || ""}`} style={{width:"100%" || ""}} src={imgSrc} alt=""></img>
        </div>
    );
};

export default Product;