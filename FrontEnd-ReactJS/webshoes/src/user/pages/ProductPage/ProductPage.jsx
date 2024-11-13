import React from 'react';
import { useState } from 'react';
import ProductsSidebar from '../../components/ProductsSidebar/ProductsSidebar';
import ProductsSubnav from '../../components/ProductsSubnav/ProductsSubnav';
import ProductsList from '../../components/ProductsList/ProductList';
import './style.scss'

function ProductPage() {
    const [filters, setFilters] = useState({
        selectedGenders: [],
        selectedSports: [],
        isSale: false,
        selectedSizes: [],
        selectedColors: [],
        minValue: 1000000,
        maxValue: 11000000,
        selectedBrands: [],
        isNewest: false,
        isSizeUK: false,
    });

    console.log(filters.minValue);
    console.log(filters.maxValue);

    // cập nhật trạng thái filters với các giá trị mới.
    // updateFilters nhận một đối tượng newFilters - các bộ lọc mới cần cập nhật.
    const updateFilters = (newFilters) => {
        setFilters((prevFilters) => ({
            ...prevFilters,
            ...newFilters,
        }));
    };

    const deleteFilters = () => {
        setFilters(
            {
                selectedGenders: [],
                selectedSports: [],
                isOnSale: false,
                selectedSizes: [],
                selectedColors: [],
                minValue: 1000000,
                maxValue: 11000000,
                selectedBrands: [],
                isNewest: false,
                isSizeUK: false,
            }
        );
    }

    const [isMenuSidebarVisible, setIsMenuSidebarVisible] = useState(false);

    const toggleMenuSidebar = () => {
        setIsMenuSidebarVisible(!isMenuSidebarVisible);
        console.log(isMenuSidebarVisible);
    }

    return (
        <div className="container-fluid">
            <div className="row product">
                <ProductsSidebar filters={filters} updateFilters={updateFilters} isMenuSidebarVisible={isMenuSidebarVisible} />
                <div className="col content">
                    <ProductsSubnav filters={filters} updateFilters={updateFilters} deleteFilters={deleteFilters} toggleMenuSidebar={toggleMenuSidebar} />
                    <ProductsList filters={filters} />
                </div>
            </div>
        </div>
    );
}

export default ProductPage;
