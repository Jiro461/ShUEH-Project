import React from 'react';
import './UserAdvantage.scss'
import ProductAdvantage from "../../../components/product-advantage/ProductAdvantage";
import SectionTitle from "../../../components/section-title/SectionTitle";

const UserAdvantage = () => {
    return (
        <div className="user-advantage">
            <div className="container-fluid">
                <div className="row g-0">
                    <div className="col d-flex justify-content-center align-items-center">
                        <SectionTitle title="Advantage"></SectionTitle>
                    </div>
                    <div className="col">
                        <ProductAdvantage
                            width="400px" 
                            height="330px" 
                            index="01" 
                            name="Quality Assurance" 
                            desc="We deliver the best assurance policy that encourage buying more of our products.">
                        </ProductAdvantage>
                        <img src="/advantage-product-1.svg" alt=""></img> 
                    </div>
                    <div className="col">
                        <ProductAdvantage
                            width="350px" 
                            index="03"
                            name = "Nice shipping"
                            bgcolor="transparent"
                            flexDirection="row">
                        </ProductAdvantage>
                        <img src="/advantage-product-3.svg" alt=""></img> 
                    </div>
                </div>
                <div className="row g-0">
                    <div className="col d-flex justify-content-flex-end align-items-flex-end">
                        <ProductAdvantage
                            width="350px" 
                            height="400px" 
                            index="02" 
                            name="Athletic shoes" 
                            desc="We deliver the best Brand shoes for athletic activities including football, basketball and more.">
                        </ProductAdvantage>
                        <img src="/advantage-product-2.svg" alt=""></img> 
                    </div>
                    <div className="col">
                        <img src="/advantage-img.svg" alt=""></img>
                    </div>
                    <div className="col">
                        <ProductAdvantage
                            width="350px" 
                            height="400px" 
                            index="04" 
                            name="Gifts Certificates" 
                            desc="We deliver the best Brand Gift card and voucher all over the East side. Not just for buying shoes but for many many other contents.">
                        </ProductAdvantage>
                    </div>
                </div>
            </div>
        </div>
    );
};


export default UserAdvantage;