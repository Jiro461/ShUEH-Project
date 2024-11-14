import React, { useState, useEffect } from 'react';
import './style.scss';
import ProductDetail from '../../components/ProductDetail/ProductDetail';
import ProductDescription from '../../components/ProductDescription/ProductDescription';
import { useParams } from 'react-router-dom';
import ShoeItem from '../../components/ShoeItem/ShoeItem';
import Slider from "react-slick"; // Thư viện slide, cài đặt với 'npm install react-slick' và 'slick-carousel'

const ProductDetailPage = () => {
  const { id } = useParams();
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);
  const [product, setProduct] = useState(null);
  const [otherShoes, setOtherShoes] = useState([]); // State lưu các sản phẩm cùng brand

  useEffect(() => {
    // Fetch chi tiết sản phẩm
    const fetchProduct = async () => {
      try {
        const response = await fetch(`${process.env.REACT_APP_API_URL}/api/Shoe/${id}`);
        if (!response.ok) {
          throw new Error('Network response was not ok');
        }
        const data = await response.json();
        setProduct(data);

        // Fetch các sản phẩm cùng thương hiệu nếu chi tiết sản phẩm thành công
        if (data.brand) {
          fetchOtherShoes(data.brand);
        }
      } catch (error) {
        setError(error.message);
      } finally {
        setLoading(false);
      }
    };

    // Fetch các sản phẩm cùng thương hiệu
    const fetchOtherShoes = async (brand) => {
      if (!brand) {
        console.error("Brand is missing or undefined");
        return;
      }

      try {
        const response = await fetch(`${process.env.REACT_APP_API_URL}/api/Shoe/brand?brand=${brand}`);
        if (!response.ok) {
          throw new Error(`Failed to fetch: ${response.status}`);
        }
        const shoes = await response.json();
        setOtherShoes(shoes);
      } catch (error) {
        console.error("Error fetching other shoes:", error);
      }
    };


    fetchProduct();
  }, [id]);

  // Cài đặt cho slider
  const sliderSettings = {
    dots: true,
    infinite: true,
    speed: 500,
    slidesToShow: 5,
    slidesToScroll: 1,
    responsive: [
      { breakpoint: 1024, settings: { slidesToShow: 3 } },
      { breakpoint: 768, settings: { slidesToShow: 2 } },
      { breakpoint: 480, settings: { slidesToShow: 1 } }
    ]
  };

  return (
    <div className="product-detail-container">
      <div className="row detail-product">
        <ProductDetail product={product} error={error} loading={loading} />
      </div>

      <div className="row description">
        <ProductDescription product={product} error={error} loading={loading} />
      </div>

      {/* Render các sản phẩm khác cùng thương hiệu */}
      <div className="row other-shoes-list">
        <h3>Other shoes from {product?.brand}</h3>
        <Slider {...sliderSettings}>
          {otherShoes.map(shoe => (
            <ShoeItem key={shoe.id} shoe={shoe} />
          ))}
        </Slider>
      </div>
    </div>
  );
};

export default ProductDetailPage;
