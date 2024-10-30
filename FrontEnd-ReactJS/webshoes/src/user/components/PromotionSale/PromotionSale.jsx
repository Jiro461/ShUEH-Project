import React from 'react';
import './PromotionSale.scss'

const PromotionSale = ({sale}) => {
    return (
        <div className="promotion-sale">
            <span>{sale} OFF</span>
        </div>
    );
};

export default PromotionSale;