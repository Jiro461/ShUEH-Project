import React from 'react';
import './UserMostPopular.scss'
import ProductPopular from "../../../components/HomeProductPopular/ProductPopular";
import SectionTitle from "../../../components/SectionTitle/SectionTitle";
import Slider from "react-slick";
import { Reveal } from "../../../components/Animation/Reveal.tsx";

const UserMostPopular = () => {
    var settings = {
        dots: true,
        infinite: true,
        speed: 500,
        autoplay: true,
        autoplaySpeed: 3000,
        slidesToShow: 1,
        slidesToScroll: 1,
      };
    return (
        <div className="user-most-popular">
            <div className="title">
                <Reveal>
                    <SectionTitle title="MOST POPULAR"></SectionTitle>
                </Reveal>
            </div>
            <div className="product-popular d-none d-md-block">
                    
                    <div className="sub-left fit-content">
                        <ProductPopular></ProductPopular>
                    </div>
                    <div className="center-product fit-content">
                        <ProductPopular></ProductPopular>
                    </div>
                    <div className="sub-right fit-content">
                        <ProductPopular></ProductPopular>
                    </div>
                
            </div>

            <div className="slider-container d-md-none d-sm-block">
               <Slider {...settings}>
                    <div className="slider-item"><ProductPopular></ProductPopular></div>
                    <div className="slider-item"><ProductPopular></ProductPopular></div>
                    <div className="slider-item"><ProductPopular></ProductPopular></div>
               </Slider>
            </div>
        </div>
    );
};

export default UserMostPopular;