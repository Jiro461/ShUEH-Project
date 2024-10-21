import React from 'react';
import './UserProducts.scss'
import Product from "../../../components/product/Product";
import Slider from 'react-slick'
import '../../../../../styles/slider.scss'
import {Reveal} from "../../../components/utils/Reveal.tsx";

const UserProducts = () => {
    const images = [
        {id: 2,
            src: "/product-2.svg"
        },
        {id: 3,
            src: "/product-3.svg"
        },
        {id: 4,
            src: "/product-4.svg"
        },
    ]
    var settings = {
        dots: true,
        infinite: true,
        speed: 500,
        autoplay: false,
        autoplaySpeed: 3000,
        slidesToShow: 1,
        slidesToScroll: 1,
      };
    return (
        <div className="products">
            <Reveal>
                <h3>PRODUCTS</h3>
            </Reveal>

            <div className="navbar d-none d-md-flex">
            <Reveal>
                <ul>
                    <li>Nike<span>(123)</span></li>
                    <li>Adidas<span>(123)</span></li>
                    <li>Puma<span>(123)</span></li>
                    <li>Rebok<span>(123)</span></li>
                    <li>Converse<span>(123)</span></li>
                </ul>
            </Reveal>
            <Reveal>
                <ul>
                    <li>Newest</li>
                    <li>VN size</li>
                    <li>X</li>
                </ul>
            </Reveal>
            </div>

            <div className="container-fluid d-none d-md-block">
                <div className="row g-0">
                        <div className="col-4 g-0">
                    <Reveal>
                            <Product imgClassName='img-custom' imgSrc="/product-1.svg"></Product>
                    </Reveal>
                        </div>
                    <div className="col-8">
                        <div className="row">
                                <div className="col">
                            <Reveal>
                                    <Product imgSrc="/product-2.svg"></Product>
                            </Reveal>
                                </div>
                                <div className="col">
                            <Reveal>
                                    <Product imgSrc="/product-3.svg"></Product>
                            </Reveal>
                                </div>
                        </div>
                        <div className="row g-0">
                            <div className="col">
                                <Reveal>
                                    <Product imgSrc="/product-4.svg"></Product>
                                </Reveal>
                            </div>
                            <div className="col">

                            </div>
                        </div>
                    </div>
                </div>

                <div className="row g-0">
                    <div className="col">
                        <Reveal>
                            <Product imgSrc="/product-5.svg"></Product>
                        </Reveal>
                    </div>
                    <div className="col">
                        <Reveal>
                            <Product imgSrc="/product-6.svg"></Product>
                        </Reveal>
                    </div>
                    <div className="col">
                        <Reveal>
                            <Product imgSrc="/product-7.svg"></Product>
                        </Reveal>
                    </div>
                </div>  
            </div>

            <div className="slider-container d-sm-block d-md-none">
                <Slider {...settings}>
                    {images.map((item, index) => {
                        return <Reveal>
                            <div key={index} className="slider-item">
                                <Product width="90%"  imgSrc={item.src}></Product>
                            </div>
                        </Reveal>
                    })}
                </Slider>
            </div>
        </div>
        
    );
};

export default UserProducts;