import React from 'react';
import { shoes } from './dataProduct';

function ProductList() {
    const shoeList = shoes.map((shoe, index) => (
        <div key={index} className="col item">
            <img src={process.env.PUBLIC_URL + '/img/revolution7.png'} alt="" />
            <div className="new">New</div>
            <div className="item-detail">
                <h4>{shoe.name}</h4>
                <p>Pricing ${shoe.price}</p>
                <div className="btn-heart">
                    <i className="fa-solid fa-heart" />
                </div>
            </div>
        </div>
    ));

    return (
        <div className="row row-cols-4 product-list">
            {shoeList}
        </div>
    );
}

export default ProductList;
