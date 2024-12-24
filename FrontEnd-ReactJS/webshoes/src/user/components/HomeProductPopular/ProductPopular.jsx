import React from "react";
import "./ProductPopular.scss";
import PromotionTagNew from "../PromotionTagNew/PromotionTagNew";
import PromotionTag from "../PromotionTag/PromotionTag";

const ProductPopular = () => {
  return (
    <div>
      {/* Phần hiển thị sản phẩm phổ biến */}
      <div className="home-popular-product">
        <div className="info">
          {/* Thẻ Tag cho sản phẩm mới */}
          <PromotionTagNew></PromotionTagNew>
          {/* Các thông tin sản phẩm như loại, mã sản phẩm và giá */}
          <span className="info-title">PRODUCT</span>
          <span className="info-title">3.000.000đ</span>

          {/* Nút đi đến danh mục, ẩn trên các màn hình nhỏ hơn */}
          <button className="d-none d-md-block">Go to Catalog</button>
        </div>
        {/* Tiêu đề cho thương hiệu */}
        <div className="title">BRAND</div>
        <div className="product-popular-wrapper">
          {/* Hình ảnh sản phẩm phổ biến */}
          <img className="product-img" src="/popular-product.svg" alt=""></img>
          {/* Hình ảnh trang trí */}
          <img
            className="line-decor-1"
            src="/popular-line-decor-2.svg"
            alt=""
          ></img>
          <div className="promotion-block">
            {/* Thẻ tag cho khuyến mãi */}
            <PromotionTag brand="Nike" discount="40"></PromotionTag>
          </div>
          <div className="product-info">
            {/* Thông tin về thương hiệu và tên sản phẩm */}
            <span className="product-brand">SHUEH</span>
            <span className="product-name">OUTDOORS</span>
          </div>
        </div>
        {/* Hình ảnh trang trí cho phần dưới */}
        <div className="line-decor-2">
          <img src="/popular-line-decor-1.svg" alt=""></img>
        </div>
      </div>
      {/* Phần nút bấm cho các thiết bị di động */}
      <div className="btn-block d-flex d-md-none">
        <button className="btn-custom">Go to Catalog</button>
      </div>
    </div>
  );
};

export default ProductPopular;
