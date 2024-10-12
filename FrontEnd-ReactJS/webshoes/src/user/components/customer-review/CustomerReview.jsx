import React from 'react';
import './CustomerReview.scss'

const CustomerReview = () => {
    return (
        <div className="customer-review">
            <div className="customer-avatar">
                <img src="/customer-avatar.svg" alt=""></img>
            </div>
            <div className="customer-name">
                <img src="/customer-quote-1.svg" alt=""></img>
                <img src="/customer-quote-1.svg" alt=""></img>
                <span>name</span>
            </div>
            <div className="customer-comment">
            Leaving a review here. This is such a gud page where I can find shoes
and many other sporty stuff. Not just so, the name is Shueh is how UEHer can find shoes that relates to UEH. BLAH BLAH BLAH BLAH
            </div>
            <div className="customer-rate">
                <img src="/customer-rate-star.svg" alt=""></img>
                <img src="/customer-rate-star.svg" alt=""></img>
                <img src="/customer-rate-star.svg" alt=""></img>
                <img src="/customer-rate-star.svg" alt=""></img>
                <img src="/customer-rate-star.svg" alt=""></img>
            </div>
        </div>
    );
};

export default CustomerReview;