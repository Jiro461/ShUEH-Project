import React from 'react';
import './UserReview.scss'
import SectionTitle from "../../../components/section-title/SectionTitle";
import CustomerReview from "../../../components/customer-review/CustomerReview";

const UserReview = () => {
    return (
        <div className="review-section">
            <div className="decor">
                <img src="/customer-review-decor-1.svg" alt=""></img>
                <img src="/customer-review-decor-2.svg" alt=""></img>
            </div>

            <div className="review-title">
                <SectionTitle title="CUSTOMER REVIEW"></SectionTitle>
            </div>

            <div className="container-fluid">
                <div className="row g-0">
                    <div className="col"><CustomerReview></CustomerReview></div>
                    <div className="col"><CustomerReview></CustomerReview></div>
                    <div className="col"><CustomerReview></CustomerReview></div>
                </div>
            </div>
        </div>
    );
};

export default UserReview;