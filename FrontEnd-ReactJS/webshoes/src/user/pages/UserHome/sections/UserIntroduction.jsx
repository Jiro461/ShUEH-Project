import React, { useRef } from 'react';
import './UserIntroduction.scss'
import PropTypes from 'prop-types';
import AddBlock from '../../../components/AddBlock/AddBlock';
import PromotionTag from "../../../components/PromotionTag/PromotionTag";
import { motion, useInView } from "framer-motion";
import axios from "axios";

const UserIntroduction =  () => {
    const ref = useRef(null)
    const isInView = useInView(ref)
    const productStyle = {
        zIndex: 5,
        scale: isInView ? 1 : 0.1,
        opacity: isInView ? 1 : 0,
        transition: "all 2s"
    }
    const titleStyle = {
        zIndex: 6,
        transform: isInView ? "none" : "translateX(-200px)",
        opacity: isInView ? 1 : 0,
        transition: "all 2s"
    }
    return (
            <div className='user-introduction' >
                <div className='line'>
                    <img className='line' src='/intro-line-decor.svg' alt='line-decor'></img>
                </div>

                <div className="product" ref={ref} style={productStyle}>
                    <img className="product-img" src='/intro-product.svg' alt='intro-product'></img>

                    <div className='product-promotion'>
                        <PromotionTag></PromotionTag>
                    </div>

                    <div className='black-circle-block border-circle'></div>

                    <div className="product-add-block d-none d-sm-block">
                        <AddBlock></AddBlock>
                    </div>
                </div>

                <div className="title" style={titleStyle}>
                    <div className='product-title'>Brand shoes.</div>

                    <div className='product-sub-title'>We deliver immersive virtual reality experiences that encourages learning, creativity and play at transport hubs, select retail and culturally significant venues</div>
                </div>

                <div className='sub-product flex-center border-circle d-none d-lg-block'>
                    <div className='first-border border-circle'></div>
                    <div className='second-border border-circle'></div>
                    <img className='img-product' src='/intro-sub-product.svg' alt='sub-product'></img>
                    <div className="sub-product-add-block">
                        <AddBlock></AddBlock>
                    </div>
                    <span className='sub-product--name'>AIR JORDAN</span>
                    <div className='sub-product--price flex-center'>$100.00</div>
                </div>
            </div>
    );
};

export default UserIntroduction;