// RatingStars.js
import React from 'react';

const RatingStars = ({ rating }) => {
    const fullStars = Math.floor(rating);
    const partialStarPercentage = (rating % 1) * 100;
    const emptyStars = 5 - Math.ceil(rating);

    const renderStars = () => {
        const stars = [];
        for (let i = 0; i < fullStars; i++) {
            stars.push(
                <div key={`full-${i}`} className="star-container">
                    <svg viewBox="0 0 24 24" className="star">
                        <polygon points="12,2 15,8.5 22,9.3 17,14.1 18.6,21 12,17.5 5.4,21 7,14.1 2,9.3 9,8.5" className="star-fill" />
                    </svg>
                </div>
            );
        }
        if (partialStarPercentage > 0) {
            stars.push(
                <div key="partial" className="star-container">
                    <svg viewBox="0 0 24 24" className="star">
                        <polygon points="12,2 15,8.5 22,9.3 17,14.1 18.6,21 12,17.5 5.4,21 7,14.1 2,9.3 9,8.5" className="star-bg" />
                        <polygon
                            points="12,2 15,8.5 22,9.3 17,14.1 18.6,21 12,17.5 5.4,21 7,14.1 2,9.3 9,8.5"
                            className="star-fill"
                            style={{ clipPath: `inset(0 ${100 - partialStarPercentage}% 0 0)` }}
                        />
                    </svg>
                </div>
            );
        }
        for (let i = 0; i < emptyStars; i++) {
            stars.push(
                <div key={`empty-${i}`} className="star-container">
                    <svg viewBox="0 0 24 24" className="star">
                        <polygon points="12,2 15,8.5 22,9.3 17,14.1 18.6,21 12,17.5 5.4,21 7,14.1 2,9.3 9,8.5" className="star-bg" />
                    </svg>
                </div>
            );
        }
        return stars;
    };

    return (
        <div className="rating-stars">
            {renderStars()}
            <span className='rating-number'>({rating})</span>
        </div>
    );
};

export default RatingStars;
