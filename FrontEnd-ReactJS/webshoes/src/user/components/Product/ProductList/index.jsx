import React from 'react';
import { shoes } from './dataProduct';

function ProductList() {
    const shoeList = shoes.map((shoe, index) => (
        <li key={index} className="col item">
            <a href="">
                <div className="image">
                    <img src={process.env.PUBLIC_URL + '/img/revolution7.png'} alt="" />
                    <button type='button' className='btn-buynow'>BUY NOW</button>
                </div>
                <div className="new">New</div>
                <div className="item-detail">
                    <h4>{shoe.name}</h4>
                    <p>Pricing ${shoe.price}</p>
                    <div className="btn-heart">
                        <i className="fa-solid fa-heart" />
                    </div>
                </div>
            </a>
        </li>
    ));

    return (
        <ul className="row row-cols-4 product-list">
            {shoeList}
        </ul>
    );
}

export default ProductList;
