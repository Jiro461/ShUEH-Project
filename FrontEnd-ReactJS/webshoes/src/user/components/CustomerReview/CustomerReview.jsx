import React from 'react';
import './CustomerReview.scss'
import StarRatings from 'react-star-ratings';

const CustomerReview = ({avatar, name, comment, rating}) => {
    return (
        <div className="customer-review">
            <img className="customer-avatar" src={avatar || "/customer-avatar.svg"} alt=""></img>
            <div className="customer-name">
                <img src="/customer-quote-1.svg" alt=""></img>
                <img src="/customer-quote-1.svg" alt=""></img>
                <span>{name}</span>
            </div>
            <div className="customer-comment">
                {comment}
            </div>
            <div className="customer-rate">
                <StarRatings
                    rating={rating}
                    numberOfStars={5}
                    starRatedColor="yellow"
                    starDimension="25px"
                    starSpacing="1px"
                ></StarRatings>
            </div>
        </div>
    );
};

export default CustomerReview;