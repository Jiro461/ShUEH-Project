import React from 'react';
import './ProductAdvantage.scss'

const ProductAdvantage = ({index, name, desc, width, height, pt, bgcolor, flexDirection}) => {
    return (
        <div className="product-advantage" style={{width: width, height: height,backgroundColor: bgcolor, flexDirection: flexDirection}}>
            <span className="advantage-index">{index}</span>
            {flexDirection ? <span className="advantage-name ml">{name}</span> : <span className="advantage-name">{name}</span>}
            {desc ? <span className="advantage-desc">{desc}</span> : "" }
        </div>
    );
};

export default ProductAdvantage;