import React, { useState } from 'react';

const RateShoe = ({ maxStars = 5, onRatingChange }) => {
    const [rating, setRating] = useState(0);
    const [hover, setHover] = useState(0);

    const handleClick = (newRating) => {
        setRating(newRating);
        if (onRatingChange) onRatingChange(newRating); // Gọi callback nếu có
    };

    return (
        <div className="star-rating">
            {[...Array(maxStars)].map((_, index) => {
                const starValue = index + 1;
                return (
                    <span
                        key={starValue}
                        className={`star ${starValue <= (hover || rating) ? 'filled' : ''}`}
                        onClick={() => handleClick(starValue)}
                        onMouseEnter={() => setHover(starValue)}
                        onMouseLeave={() => setHover(0)}
                        style={{ cursor: 'pointer', fontSize: '24px' }}
                    >
                        ★
                    </span>
                );
            })}
        </div>
    );
};

export default RateShoe;
