import React from 'react';
import {brands} from './dataSubnav'

function SubNav() {
    const brandList = brands.map((brand, index) => (
        <div key={index}><a href="#">{brand.name} ({brand.amountItem})</a></div>
    ));

    return (
        <div className="row subNav">
            <div className="col-8 brand">
                {brandList}
            </div>
            <div className="col-3 sub-filter">
                <div><a href="#">Newest</a></div>
                <div><a href="#">UK size</a></div>
            </div>
            <div className="col-1 btn-exit">
                <i className="fa-solid fa-xmark" />
            </div>
        </div>
    );
}

export default SubNav;
