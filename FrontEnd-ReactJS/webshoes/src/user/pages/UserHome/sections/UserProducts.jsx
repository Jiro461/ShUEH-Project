import React, { useEffect, useRef, useState } from "react";
import "./UserProducts.scss";
import Product from "../../../components/HomeProduct/Product.jsx";
import SectionTitle from "../../../components/SectionTitle/SectionTitle.jsx";
import Slider from "react-slick";
import { Reveal } from "../../../components/Animation/Reveal.tsx";
import * as homeService from "../../../../services/homeService.jsx";
import { useInView } from "framer-motion";
import { useNavigate } from "react-router-dom";

const UserProducts = () => {
  const [data, setData] = useState();
  const [loading, setLoading] = useState(false);
  const [brand, setBrand] = useState("Nike");
  const [activeBrand, setActiveBrand] = useState("Nike");
  const navigate = useNavigate();
  const ref = useRef(null);
  const isInView = useInView(ref);
  const productStyle = {
    zIndex: 5,
    scale: isInView ? 1 : 0.1,
    opacity: isInView ? 1 : 0,
    transition: "scale 2s, opacity 2s",
  };
  const titleStyle = {
    zIndex: 6,
    transform: isInView ? "none" : "translateY(200px)",
    opacity: isInView ? 1 : 0,
    transition: "all 2s",
  };
  useEffect(() => {
    const fetchApi = async () => {
      setLoading(true);
      const res = await homeService.getProductsByBrand(brand);
      setData(res);
      setLoading(false);
    };
    fetchApi();
  }, [brand]);
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
    setBrand(selectedBrand);
    setActiveBrand(selectedBrand);
  };
  return (
    <div className="products-home" id="products-home">
      <Reveal>
        <SectionTitle title="PRODUCTS"></SectionTitle>
      </Reveal>

      <div className="navbar">
        <Reveal>
          <ul>
            {["Nike", "Adidas", "Puma", "Reebok", "Converse"].map((item) => (
              <li
                key={item}
                onClick={handleNavbar}
                className={activeBrand === item ? "active" : ""} // Conditionally add 'active' class
              >
                {item}
                <span>(123)</span>
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

      <div className="product-home-wrapper d-none d-md-flex">
        {data?.map((item, index) => {
          return (
            <div
              key={index}
              className="product-home-wrapper-item"
              onClick={() => navigate(`/product/${item.id}`)}
            >
              <Product
                productName={item.name}
                productBrand={item.brand}
                imgSrc={item.imageUrl || "/product-7.svg"}
                isSale={item.isSale}
                discount={item.discount}
                isNew={item.isNew}
                price={item.price}
                originalPrice={item.originalPrice}
              ></Product>
            </div>
          );
        })}
      </div>

      <div className="slider-container d-sm-block d-md-none">
        <Slider {...settings}>
          {data?.map((item, index) => {
            return (
              <div key={index} className="slider-item">
                <Product
                  width="90%"
                  productName={item.name}
                  productBrand={item.brand}
                  imgSrc={item.imageUrl || "/product-7.svg"}
                  isSale={item.isSale}
                  discount={item.discount}
                  isNew={item.isNew}
                  price={item.price}
                  originalPrice={item.originalPrice}
                ></Product>
              </div>
            );
          })}
        </Slider>
      </div>
    </div>
  );
};

export default UserProducts;
