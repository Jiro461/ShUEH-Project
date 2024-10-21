import React from 'react';
import './UserAdvantage.scss'
import ProductAdvantage from "../../../components/product-advantage/ProductAdvantage";
import SectionTitle from "../../../components/section-title/SectionTitle";
import Slider from 'react-slick'
import '../../../../../styles/slider.scss'

const UserAdvantage = () => {
    var settings = {
        dots: true,
        infinite: true,
        speed: 500,
        autoplay: false,
        autoplaySpeed: 3000,
        slidesToShow: 1.1,
        slidesToScroll: 1,
      };
    return (
        <div className="user-advantage">
            <SectionTitle className="d-sm-block d-md-none text-center section-title-custom" title="ADVANTAGE"></SectionTitle>
            <div className="container-fluid d-none d-md-block">
                <div className="row g-0">
                    <div className="col d-flex justify-content-center align-items-center">
                        <SectionTitle title="Advantage"></SectionTitle>
                    </div>
                    <div className="col advantage-1">
                        <ProductAdvantage
                            style={{
                                width: "27vw", 
                                height: "20vw",
                                imgWidth: "20vw",
                                imgTopPosition: "-20%",
                                imgRightPosition: "-25%"}}
                            index="01" 
                            name="Quality Assurance" 
                            desc="We deliver the best assurance policy that encourage buying more of our products."
                            src="/advantage-product-1.svg">
                        </ProductAdvantage>
                    </div>
                    <div className="col advantage-3">
                        <ProductAdvantage
                            index="03"
                            name = "Nice shipping"
                            style={{
                                width: "27vw",
                                height: "20vw",
                                bgcolor: "transparent",
                                flexDirection: "row",
                                imgWidth: "20vw",
                                imgTopPosition: "40%",
                                imgRightPosition: "0%"}}
                                src="/advantage-product-3.svg" >
                        </ProductAdvantage>
                    </div>
                </div>
                <div className="row g-0">
                    <div className="col advantage-2 d-flex justify-content-flex-end align-items-flex-end">
                        <ProductAdvantage
                            style={{
                                width:"27vw", 
                                height:"20vw",
                                imgWidth: "25vw",
                                imgTopPosition: "-40%"}}
                            index="02" 
                            name="Athletic shoes" 
                            desc="We deliver the best Brand shoes for athletic activities including football, basketball and more."
                            src="/advantage-product-2.svg">
                        </ProductAdvantage>
                    </div>
                    <div className="col">
                        <img style={{width: "27vw", height: "20vw", objectFit: "cover"}} src="/advantage-img.svg" alt=""></img>
                    </div>
                    <div className="col advantage-4">
                        <ProductAdvantage
                            style={{
                                width:"27vw", 
                                height:"20vw"}}
                            index="04" 
                            name="Gifts Certificates" 
                            desc="We deliver the best Brand Gift card and voucher all over the East side. Not just for buying shoes but for many many other contents.">
                        </ProductAdvantage>
                    </div>
                </div>
            </div>
            <div className="slider-container d-sm-block d-md-none">
                <Slider {...settings}>
                    <div className="slider-item advantage-1">
                        <ProductAdvantage 
                            style={{
                                width:"70vw", 
                                height: "45vw",
                                imgWidth: "40vw",
                                imgTopPosition: "-15%",
                                imgRightPosition: "-15%"}}
                            index="01" 
                            name="Quality Assurance" 
                            desc="We deliver the best assurance policy that encourage buying more of our products."
                            src="/advantage-product-1.svg">
                        </ProductAdvantage>
                    </div>
                    <div className="slider-item advantage-2">
                        <ProductAdvantage
                            style={{
                                width:"70vw", 
                                height: "45vw",
                                imgWidth: "40vw",
                                imgTopPosition: "-15%",
                                imgRightPosition: "-15%"}}
                            index="02" 
                            name="Athletic shoes" 
                            desc="We deliver the best Brand shoes for athletic activities including football, basketball and more."
                            src="/advantage-product-2.svg">
                        </ProductAdvantage>
                    </div>
                    <div className="slider-item advantage-3">
                    <ProductAdvantage
                            style={{
                                width:"70vw", 
                                height: "45vw",
                                imgWidth: "40vw",
                                imgTopPosition: "0%",
                                imgRightPosition: "0%"}}
                            index="03"
                            name = "Nice shipping"
                            src="/advantage-product-3.svg">
                        </ProductAdvantage> 
                    </div>
                    <div className="slider-item advantage-4">
                        <ProductAdvantage
                            style={{
                                width:"70vw" , 
                                height: "45vw"}}
                            index="04" 
                            name="Gifts Certificates" 
                            desc="We deliver the best Brand Gift card and voucher all over the East side. Not just for buying shoes but for many many other contents.">
                        </ProductAdvantage>
                    </div>
                </Slider>
            </div>
        </div>
    );
};


export default UserAdvantage;