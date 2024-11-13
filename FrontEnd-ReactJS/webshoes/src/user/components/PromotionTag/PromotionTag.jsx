import React from 'react';
import './PromotionTag.scss'

const PromotionTag = ({brand, discount}) => {
    return (
        <div className='promotion-tag flex-center border-circle'>
            <span>promo: {brand}</span>
            <span>{discount}</span>
            <span className="quantity">quantities left</span>
        </div>
    );
};

export default PromotionTag;