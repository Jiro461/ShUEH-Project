import React, { useEffect, useState } from 'react';
import './UserReview.scss'
import SectionTitle from "../../../components/SectionTitle/SectionTitle";
import CustomerReview from "../../../components/CustomerReview/CustomerReview";
import * as homeService from "../../../../services/homeService"

const UserReview = () => {
    const [reviews, setReviews] = useState()
    useEffect(()=> {
        const fetchData = async () => {
            const res = await homeService.getReviews()
            setReviews(res)
        }  
        fetchData() 
    }, [])
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
                {reviews?.map((item, index) => {
                    return <div key={index} className="col">
                        <CustomerReview
                        avatar={item.userAvatar}
                        name={item.userName}
                        comment={item.description}
                        rating={item.rate}
                        ></CustomerReview>
                    </div>
                })}
                </div>
        </div>
    );
};

export default UserReview;