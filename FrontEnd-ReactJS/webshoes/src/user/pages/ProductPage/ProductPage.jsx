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
        isOnSale: false,
        selectedSizes: [],
        selectedColors: [],
        minValue: 1000,
        maxValue: 7000,
        isMinOnTop: false,
        isMaxOnTop: false,
        selectedBrands: [],
        isNewest: false,
        isSizeUK: false,
    });

    console.log(filters);
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
                minValue: 1000,
                maxValue: 7000,
                isMinOnTop: false,
                isMaxOnTop: false,
                selectedBrands: [],
                isNewest: false,
                isSizeUK: false,
            }
        );
    }
    
    return (
        <div className="container-fluid">
            <div className="row product">
                <ProductsSidebar filters={filters} updateFilters={updateFilters}/>
                <div className="col content">
                    <ProductsSubnav filters={filters} updateFilters={updateFilters} deleteFilters={deleteFilters}/>
                    <ProductsList filters={filters}/>
                </div>
            </div>
        </div>
    );
}

export default ProductPage;
