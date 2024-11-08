import React, { useEffect, useState } from 'react';
import './UserProducts.scss'
import Product from "../../../components/HomeProduct/Product.jsx";
import SectionTitle from "../../../components/SectionTitle/SectionTitle.jsx"
import Slider from 'react-slick'
import {Reveal} from "../../../components/Animation/Reveal.tsx";
import * as homeService from "../../../../services/homeService.jsx"

const UserProducts = () => {
    const [data, setData] = useState()
    const [loading, setLoading] = useState(false)
    const [brand, setBrand] = useState("Nike")
    const [activeBrand, setActiveBrand] = useState("Nike")
    useEffect(() => {
        const fetchApi = async () => {
            setLoading(true)
            const res = await homeService.getProductsByBrand(brand)
            console.log(res);
            setData(res)
            setLoading(false)
        }
        fetchApi()
    }, [brand])
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
        autoplay: true,
        autoplaySpeed: 3000,
        slidesToShow: 1,
        slidesToScroll: 1,
      };
    const handleNavbar = (e) => {
        const selectedBrand = e.currentTarget.childNodes[0].nodeValue.trim();
        setBrand(selectedBrand)
        setActiveBrand(selectedBrand); 
    }
    return (
        <div className="products-home">
            <Reveal>
                <SectionTitle title="PRODUCTS"></SectionTitle>
            </Reveal>

            <div className="navbar d-none d-md-flex">
            <Reveal>
                <ul>
                {["Nike", "Adidas", "Puma", "Reebok", "Converse"].map((item) => (
                        <li
                            key={item}
                            onClick={handleNavbar}
                            className={activeBrand === item ? "active" : ""} // Conditionally add 'active' class
                        >
                            {item}<span>(123)</span>
                        </li>
                    ))}
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

            {/* <div className="container-fluid d-none d-md-block">
                <div className="row g-0">
                        <div className="col-4 g-0">
                    <Reveal>
                            <Product imgClassName='img-custom' imgSrc=""></Product>
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
            </div> */}

            <div className="product-home-wrapper">
                {data?.map((item, index) => {
                    return <div key={index} className="product-home-wrapper-item">
                        <Product 
                            
                            imgSrc={item.imageUrl || "/product-7.svg"}> 
                        </Product>
                    </div>
                })}
                
            </div>

            <div className="slider-container d-sm-block d-md-none">
                <Slider {...settings}>
                    {images.map((item, index) => {
                        return <div key={index} className="slider-item">
                                <Product width="90%"  imgSrc={item.src}></Product>
                            </div>
                    })}
                </Slider>
            </div>
        </div>
        
    );
};

export default UserProducts;