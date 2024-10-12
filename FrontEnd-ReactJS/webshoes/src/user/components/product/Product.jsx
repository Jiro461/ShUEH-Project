import React from 'react';
import './Product.scss' 

const Product = ({className, src}) => {
    return (
        <div className="product">
            <div className="info">
                <div className="title">
                    <p className="title-line-1">Nike air force brutus cecia </p>
                    <p className="title-line-2">nike air force 1 automating</p>
                </div>
                <img src="/heart-icon.svg" alt=""></img>
            </div>
            <img className={className} src={src} alt=""></img>
        </div>
    );
};

export default Product;