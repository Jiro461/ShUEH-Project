import React, { useEffect, useRef, useState } from 'react';
import './UserIntroduction.scss'
import PropTypes from 'prop-types';
import AddBlock from '../../../components/AddBlock/AddBlock';
import PromotionTag from "../../../components/PromotionTag/PromotionTag";
import { motion, useInView } from "framer-motion";
import Slider from 'react-slick'
import * as homeService from "../../../../services/homeService"

const UserIntroduction =  () => {
    const [data, setData] = useState([])
    const [loading, setLoading] = useState(false)
    var settings = {
        dots: true,
        infinite: true,
        speed: 500,
        autoplay: true,
        autoplaySpeed: 3000,
        slidesToShow: 1,
        slidesToScroll: 1,
      };
    useEffect(() => {
        const fetchApi = async () => {
            setLoading(true)
            const res = await homeService.getProducts()
            setData(res)
            
            setLoading(false)
        }
        fetchApi()
    }, [])
    console.log(data);
    const ref = useRef(null)
    const isInView = useInView(ref)
    const productStyle = {
        zIndex: 5,
        scale: isInView ? 1 : 0.1,
        opacity: isInView ? 1 : 0,
        transition: "scale 2s, opacity 2s"
    }
    const titleStyle = {
        zIndex: 6,
        transform: isInView ? "none" : "translateY(200px)",
        opacity: isInView ? 1 : 0,
        transition: "all 2s"
    }
    const [imageIndex, setImageIndex] = useState(0)
    const [slideDirection, setSlideDirection] = useState('');
    const handlePrevBtn = () => {
        setSlideDirection('left');
        setImageIndex((imageIndex - 1 + data.length) % data.length);
        setTimeout(() => setSlideDirection(""), 500);
    };
    
    const handleNextBtn = () => {
        setSlideDirection('right');
        setImageIndex((imageIndex + 1) % data.length);
        setTimeout(() => setSlideDirection(""), 500);
    };
    return (
        <div className='user-introduction' >
            <div className="prev-btn" onClick={handlePrevBtn}>
                <i className="fa-solid fa-chevron-left"></i>
            </div>
            <div className="next-btn" onClick={handleNextBtn}>
                <i className="fa-solid fa-chevron-right"></i>
            </div>
            <div className='line'>
                <img className='line' src='/intro-line-decor.svg' alt='line-decor'></img>
            </div>

            <div className= {`product-introduction image-${imageIndex}`} ref={ref} >
                <img className={`product-img image-${imageIndex} ${slideDirection === 'right' ? 'slide-right' : slideDirection === 'left' ? 'slide-left'  : ""}`} src={data[imageIndex]?.imageUrl || '/intro-product.svg'} alt='intro-product'></img>

                <div className={`product-promotion image-${imageIndex}`}>
                    <PromotionTag
                        brand={data[imageIndex]?.brand}
                        discount={data[imageIndex]?.discount}
                    ></PromotionTag>
                </div>

                <div className={`black-circle-block border-circle image-${imageIndex}`}></div>

                <div className={`product-add-block d-none d-sm-block image-${imageIndex}`}>
                    <AddBlock id={data[imageIndex]?.id}></AddBlock>
                </div>
            </div>

            <div className="title" style={titleStyle}>
                <div className='product-title'>Brand shoes.</div>

                <div className='product-sub-title'>We deliver immersive virtual reality experiences that encourages learning, creativity and play at transport hubs, select retail and culturally significant venues</div>
            </div>

            <div className='sub-product flex-center border-circle d-none d-lg-block' style={productStyle}>
                <div className='first-border border-circle'></div>
                <div className='second-border border-circle'></div>
                <img className={`img-product ${slideDirection === 'right' ? 'slide-right' : slideDirection === 'left' ? 'slide-left'  : ""}`} src={data[imageIndex]?.imageUrl || '/intro-sub-product.svg'} alt='sub-product'></img>
                <div className="sub-product-add-block">
                    <AddBlock id={data[imageIndex]?.id}></AddBlock>
                </div>
                <span className='sub-product--name'>{data[imageIndex]?.name}</span>
                <div className='sub-product--price flex-center'>{data[imageIndex]?.price}đ</div>
            </div>
        </div>
    );
};

export default UserIntroduction;