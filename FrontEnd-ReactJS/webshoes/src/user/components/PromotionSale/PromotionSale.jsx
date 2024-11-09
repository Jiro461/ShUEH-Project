import React from 'react';
import './PromotionSale.scss'

const PromotionSale = ({discount}) => {
    return (
        <div className="promotion-sale">
            <span>{discount}% OFF</span>
        </div>
    );
};

export default PromotionSale;