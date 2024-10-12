import React from 'react';
import './UserIntroduction.scss'
import PropTypes from 'prop-types';
import AddBlock from '../../../components/home/introduction/AddBlock';
import PromotionTag from "../../../components/promotion-tag/PromotionTag";

const UserIntroduction = () => {
    return (
            <div className='introduction'>
                <div className='line'>
                    <img className='line' src='/intro-line-decor.svg' alt='line-decor'></img>
                </div>

                <div className='circle-block border-circle'></div>

                <div className='main-product'>
                    <img src='/intro-product.svg' alt='intro-product'></img>
                </div>

                <div className='promotion-block'>
                   <PromotionTag></PromotionTag>
                </div>

                <AddBlock className='main-product__add-block'></AddBlock>

                <div className='main-product-title'>Brand shoes.</div>

                <div className='main-product-sub-title'>We deliver immersive virtual reality experiences that encourages learning, creativity and play at transport hubs, select retail and culturally significant venues</div>

                <div className='sub-product flex-center border-circle'>
                    <div className='first-border border-circle'></div>
                    <div className='second-border border-circle'></div>
                    <img className='img-product' src='/intro-sub-product.svg' alt='sub-product'></img>
                    <AddBlock className='sub-product__add-block'></AddBlock>
                    <span className='sub-product--name'>AIR JORDAN</span>
                    <div className='sub-product--price flex-center'>$100.00</div>
                </div>
            </div>
    );
};

export default UserIntroduction;