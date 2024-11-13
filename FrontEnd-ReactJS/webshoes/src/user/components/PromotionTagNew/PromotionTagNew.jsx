import React from 'react';
import './PromotionTagNew.scss'

const PromotionTagNew = ({fz}) => {
    return (
        <div className="promotion-tag-new">
            <span style={{fontSize: fz}}>NEW</span>
        </div>
    );
};

export default PromotionTagNew;