import React from 'react';
import Product from "../../../components/HomeProduct/Product";
import './UserBrandShoes.scss'
import SectionTitle from "../../../components/SectionTitle/SectionTitle";

const UserBrandShoes = () => {
    return (
        <div className="brand-shoes">
            <SectionTitle className="text-center" title="BRAND SHOES."></SectionTitle>
            <div className="img-brand-block">
                <img src="/brand-nike-icon.svg" alt=""></img>
                <img src="/brand-adidas-icon.svg" alt=""></img>
                <img src="/brand-puma-icon.svg" alt=""></img>
                <img src="/brand-reebok-icon.svg" alt=""></img>
                <img src="/brand-converse-icon.svg" alt=""></img>
            </div>
        </div>
    );
};

export default UserBrandShoes;