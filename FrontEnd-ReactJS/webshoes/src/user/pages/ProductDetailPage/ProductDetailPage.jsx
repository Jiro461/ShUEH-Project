import React from 'react';
import './style.scss';
import ProductDetail from '../../components/ProductDetail/ProductDetail';
import ProductDescription from '../../components/ProductDescription/ProductDescription';
import { useState } from 'react';
import { useParams } from 'react-router-dom';
import { useEffect } from 'react';

const ProductDetailPage = () => {
  const { id } = useParams();
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);
  const [product, setProduct] = useState(null);

  useEffect(() => {
    const fetchProduct = async () => {
      try {
        const response = await fetch(`http://localhost:5118/api/Shoe/${id}`);
        if (!response.ok) {
          throw new Error('Network response was not ok');
        }
        const data = await response.json();
        setProduct(data);
      } catch (error) {
        setError(error.message);
      } finally {
        setLoading(false);
      }
    };

    fetchProduct();
  }, [id]);

  return (
    <div className="product-detail-container">
      <div className="row detail-product">
        <ProductDetail product={product} error={error} loading={loading}/>
      </div>

      <div className="row description">
        <ProductDescription product={product} error={error} loading={loading}/>
      </div>
    </div>
  );
};

export default ProductDetailPage;
