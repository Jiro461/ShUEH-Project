import React from 'react';
import './ProductAdvantage.scss'

const ProductAdvantage = ({index, name, desc, src, style}) => {
    console.log(style?.imgTopPosition); 
    return (
        <div className="product-advantage" style={{
            width: style?.width, 
            height: style?.height, 
            background: style?.bgcolor,
            flexDirection: style?.flexDirection}}>
            <span className="advantage-index">{index}</span>
            {style?.flexDirection ? <span className="advantage-name ml">{name}</span> : <span className="advantage-name">{name}</span>}
            {desc ? <span className="advantage-desc">{desc}</span> : "" }
            {src ? <img style={{
                position: "absolute",
                width: `${style?.imgWidth}`,
                height: `${style?.imgHeight}`,
                top: `${style?.imgTopPosition}`, 
                right: `${style?.imgRightPosition}`}} src={src} alt=""></img>: ""}
        </div>
    );
};

export default ProductAdvantage;