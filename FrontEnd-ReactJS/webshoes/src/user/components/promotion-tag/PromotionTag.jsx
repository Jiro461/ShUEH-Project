import React from 'react';
import './PromotionTag.scss'

const PromotionTag = () => {
    return (
        <div className='promotion-tag flex-center border-circle'>
            <span>promo: nike</span>
            <span>40%</span>
            <span>sale</span>
        </div>
    );
};

export default PromotionTag;