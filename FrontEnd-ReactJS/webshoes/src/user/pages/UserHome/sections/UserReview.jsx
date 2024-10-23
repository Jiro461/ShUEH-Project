import React from 'react';
import './UserReview.scss'
import SectionTitle from "../../../components/SectionTitle/SectionTitle";
import CustomerReview from "../../../components/CustomerReview/CustomerReview";

const UserReview = () => {
    return (
        <div className="review-section">
            <div className="decor d-none d-md-block">
                <img src="/customer-review-decor-1.svg" alt=""></img>
                <img src="/customer-review-decor-2.svg" alt=""></img>
            </div>

            <div className="review-title">
                <SectionTitle title="CUSTOMER REVIEW"></SectionTitle>
            </div>

            <div className="customer-review-block">
                    <div className="col"><CustomerReview></CustomerReview></div>
                    <div className="col"><CustomerReview></CustomerReview></div>
                    <div className="col"><CustomerReview></CustomerReview></div>
                </div>
        </div>
    );
};

export default UserReview;