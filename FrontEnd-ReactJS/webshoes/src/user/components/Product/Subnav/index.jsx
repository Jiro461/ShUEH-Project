import React from 'react';
import {brands} from './dataSubnav'

function SubNav() {
    const brandList = brands.map((brand, index) => (
        <div key={index}><a href="#">{brand.name} ({brand.amountItem})</a></div>
    ));

    return (
        <div className="row subNav">
            <div className='col-1 menu'><i className="fa-solid fa-bars"></i></div>
            <div className="col-xl-7 brand">
                {brandList}
            </div>
            <div className="col-7 col-lg-4 col-xl-3 sub-filter">
                <div><a href="#">Newest</a></div>
                <div><a href="#">UK size</a></div>
            </div>
            <div className="col-1 btn-filter">
                <i className="fa-solid fa-filter btn-filter"></i>
            </div>
            <div className="col-1 col-lg-1 col-xl-1 btn-exit">
                <div><i className="fa-solid fa-xmark" /></div>
            </div>
        </div>
    );
}

export default SubNav;
