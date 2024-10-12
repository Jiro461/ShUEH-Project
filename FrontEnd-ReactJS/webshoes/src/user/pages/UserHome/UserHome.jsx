import React from 'react';
import PropTypes from 'prop-types';
import UserIntroduction from './sections/UserIntroduction'
import UserProducts from "./sections/UserProducts";
import UserBrandShoes from "./sections/UserBrandShoes";
import UserMostPopular from "./sections/UserMostPopular";
import UserAdvantage from "./sections/UserAdvantage";
import UserCollaboration from "./sections/UserCollaboration";
import UserReview from "./sections/UserReview";

const UserHome = () => {
    return (
        <>
        <UserIntroduction/>
        <UserProducts/>
        <UserBrandShoes/>
        <UserMostPopular/>
        <UserAdvantage></UserAdvantage>
        <UserCollaboration></UserCollaboration>
        <UserReview></UserReview>
        </>
    );
};


export default UserHome;