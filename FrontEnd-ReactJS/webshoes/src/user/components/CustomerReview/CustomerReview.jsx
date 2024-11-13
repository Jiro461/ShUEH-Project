import React from 'react';
import './CustomerReview.scss'
import StarRatings from 'react-star-ratings';

const CustomerReview = ({avatar, name, comment, rating}) => { // Nhận vào các props: avatar, name, comment, rating
    return (
        <div className="customer-review">
            {/* Hình ảnh avatar của khách hàng, nếu không có thì sử dụng hình ảnh mặc định */}
            <img className="customer-avatar" src={avatar || "/customer-avatar.svg"} alt=""></img>
            <div className="customer-name">
                {/* Biểu tượng dấu ngoặc kép cho tên khách hàng */}
                <img src="/customer-quote-1.svg" alt=""></img>
                <img src="/customer-quote-1.svg" alt=""></img>
                <span>{name}</span> {/* Hiển thị tên khách hàng */}
            </div>
            <div className="customer-comment">
                {comment} {/* Hiển thị bình luận của khách hàng */}
            </div>
            <div className="customer-rate">
                {/* Hiển thị đánh giá sao của khách hàng */}
                <StarRatings
                    rating={rating} // Điểm đánh giá sao
                    numberOfStars={5} // Số lượng sao (5 sao)
                    starRatedColor="yellow" // Màu sao đã được đánh giá
                    starDimension="25px" // Kích thước sao
                    starSpacing="1px" // Khoảng cách giữa các sao
                ></StarRatings>
            </div>
        </div>
    );
};

export default CustomerReview;
