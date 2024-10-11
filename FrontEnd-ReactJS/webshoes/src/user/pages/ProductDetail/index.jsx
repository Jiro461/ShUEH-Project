import React from 'react';
import './style.scss';
import DetailProduct from '../../components/ProductDetail/Detail';
import Description from '../../components/ProductDetail/Description';

const ProductDetail = () => {
  return (
    <div className="container-fluid main-container">
      <DetailProduct />
      <Description />
    </div>
  );
};

export default ProductDetail;
