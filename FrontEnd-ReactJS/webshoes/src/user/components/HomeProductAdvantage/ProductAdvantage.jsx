import React from 'react';
import './ProductAdvantage.scss'

const ProductAdvantage = ({index, name, desc, src, style}) => {
    return (
        <div className="home-product-advantage" style={{
            width: style?.width, /* Chiều rộng của phần tử */
            height: style?.height, /* Chiều cao của phần tử */
            background: style?.bgcolor, /* Màu nền của phần tử */
            flexDirection: style?.flexDirection}} /* Định hướng Flexbox (row hoặc column) */
        >
            <span className="advantage-index">{index}</span> {/* Hiển thị chỉ mục */}
            {/* Kiểm tra nếu có flexDirection thì thêm class ml, nếu không sẽ sử dụng class mặc định */}
            {style?.flexDirection ? <span className="advantage-name ml">{name}</span> : <span className="advantage-name">{name}</span>}
            {/* Nếu có mô tả (desc), hiển thị mô tả */}
            {desc ? <span className="advantage-desc">{desc}</span> : "" }
            {/* Nếu có hình ảnh (src), hiển thị ảnh với các thuộc tính vị trí được chỉ định */}
            {src ? <img style={{
                position: "absolute", /* Đặt ảnh ở vị trí tuyệt đối */
                width: `${style?.imgWidth}`, /* Chiều rộng của ảnh */
                height: `${style?.imgHeight}`, /* Chiều cao của ảnh */
                top: `${style?.imgTopPosition}`, /* Vị trí ảnh từ trên xuống */
                right: `${style?.imgRightPosition}`}} /* Vị trí ảnh từ bên phải */
                src={src} alt=""></img>: ""} {/* Nếu không có src, không hiển thị ảnh */}
        </div>
    );
};

export default ProductAdvantage;
