import React from 'react';
import './Product.scss' 
import PromotionTagNew from '../PromotionTagNew/PromotionTagNew'
import PromotionSale from '../PromotionSale/PromotionSale'

const Product = ({width, productName, productBrand, imgClassName, imgSrc, isSale, discount, isNew, price, originalPrice}) => {
    return (
        <div className="product-home" style={{width: width || ""}}> {/* Lớp chứa toàn bộ sản phẩm, có thể thay đổi chiều rộng */}
            <div className="info">
                <div className="title">
                    <p className="title-line-1">{productName}</p> {/* Tên sản phẩm */}
                    <p className="title-line-2">{productBrand}</p> {/* Thương hiệu sản phẩm */}
                </div>
                <img src="/heart-icon.svg" alt=""></img> {/* Biểu tượng trái tim */}
            </div>
            <div className="img-box">
                <img className={`img-product ${imgClassName}` || ""} style={{width:"100%" || ""}} src={imgSrc} alt=""></img> {/* Hình ảnh sản phẩm, có thể thay đổi class và src */}
                {isSale && <div className="product-promotion-sale">
                    <PromotionSale discount={discount}></PromotionSale> {/* Hiển thị giảm giá nếu có */}
                </div>}
                {isNew && <div className="product-promotion-tag-new">
                    <PromotionTagNew fz="1.2rem"></PromotionTagNew> {/* Hiển thị thẻ sản phẩm mới nếu có */}
                </div>}
            </div>
            <div className={`product-price ${isSale ? "" : "single-price"}`}> {/* Hiển thị giá sản phẩm, thay đổi class nếu có khuyến mãi */}
                {isSale && <span className="original-price d-none d-sm-block">{originalPrice}đ</span>} {/* Giá gốc, chỉ hiển thị trên màn hình lớn */}
                <span className="sale-price">{price}đ</span> {/* Giá sau khi giảm */}
            </div>
        </div>
    );
};

export default Product;
