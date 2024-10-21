import React from 'react';
import './style.scss';
import ProductDetail from '../../components/ProductDetail/ProductDetail';
import ProductDescription from '../../components/ProductDescription/ProductDescription';

const ProductDetailPage = () => {
  return (
    <div className="main-container">
      <div className="row detail-product">
        <ProductDetail />
      </div>
      
      <div className="row description">
        <ProductDescription />
      </div>
    </div>
  );
};

export default ProductDetailPage;
