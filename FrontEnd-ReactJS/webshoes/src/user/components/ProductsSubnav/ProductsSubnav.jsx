import React from 'react';
import { brands } from './dataSubnav';

function ProductsSubnav({ filters, updateFilters, deleteFilters }) {
    const handleBrandClick = (brand) => {
        const updatedBrands = filters.selectedBrands.includes(brand)
            ? filters.selectedBrands.filter(b => b !== brand)
            : [...filters.selectedBrands, brand];
        updateFilters({ selectedBrands: updatedBrands });
    };

    const handleNewestClick = () => {
        updateFilters({ isNewest: !filters.isNewest });
    };

    const handleSizeClick = () => {
        updateFilters({ isSizeUK: !filters.isSizeUK });
    };

    const handleDeleteFilter = () => {
        deleteFilters();
    }

    const isBrandSelected = (brand) => filters.selectedBrands.includes(brand);
    
    const brandList = brands.map((brand, index) => (
        <div key={index}>
            <a
                href="#"
                onClick={(e) => {
                    e.preventDefault();
                    handleBrandClick(brand.name);
                }}
                className={`${isBrandSelected(brand.name) ? 'active' : ''}`}
                >
                {brand.name}
            </a>
        </div>
    ));

    return (
        <div className="row subNav">
            <div className='col-1 menu'><i className="fa-solid fa-bars"></i></div>
            <div className="col-xl-7 brand">
                {brandList}
            </div>
            <div className="col-7 col-lg-4 col-xl-3 sub-filter">
                <div>
                    <a
                        href="#"
                        onClick={(e) => {
                            e.preventDefault();
                            handleNewestClick();
                        }}
                        className={`${filters.isNewest ? 'active' : ''}`}
                    >
                        Newest
                    </a>
                </div>
                <div>
                    <a
                        href="#"
                        onClick={(e) => {
                            e.preventDefault();
                            handleSizeClick();
                        }}
                        className={`${filters.isSizeUK ? 'active' : ''}`}
                    >
                        Kích thước UK
                    </a>
                </div>
            </div>
            <div className="col-1 btn-filter">
                <i className="fa-solid fa-filter btn-filter"></i>
            </div>
            <div className="col-1 col-lg-1 col-xl-1 btn-exit">
                <div><i className="fa-solid fa-xmark" onClick={handleDeleteFilter}/></div>
            </div>
        </div>
    );
}

export default ProductsSubnav;
