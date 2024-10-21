import React from 'react';
import PropTypes from 'prop-types';
import UserIntroduction from './sections/UserIntroduction'
import UserProducts from "./sections/UserProducts";
import UserBrandShoes from "./sections/UserBrandShoes";
import UserMostPopular from "./sections/UserMostPopular";
import UserAdvantage from "./sections/UserAdvantage";
import UserCollaboration from "./sections/UserCollaboration";
import UserReview from "./sections/UserReview";
import Login from "../../components/login/Login";
import Register from "../../components/register/Register";
import UserProductCustom from "./sections/UserProductCustom";

const UserHome = () => {
    return (
        <>
        {/* <Login/> */}
        {/* <Register/> */}
        <UserIntroduction/>
        <UserProducts/>
        {/* <UserProductCustom></UserProductCustom> */}
        <UserMostPopular/>
        <UserBrandShoes/>
        <UserAdvantage></UserAdvantage>
        <UserCollaboration></UserCollaboration>
        <UserReview></UserReview>
        </>
    );
};


export default UserHome;