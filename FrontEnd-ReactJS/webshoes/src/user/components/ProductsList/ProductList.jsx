import React, { useState, useEffect } from 'react';
import { useFetchProducts } from '../../hooks/useFetchProducts';
import PaginationControls from '../PaginationControls/PaginationControls';
import ShoeItem from '../ShoeItem/ShoeItem';

function ProductsList({ filters }) {
    const itemsPerPage = 12;
    const products = useFetchProducts();
    const [currentPage, setCurrentPage] = useState(1);
    const [favorites, setFavorites] = useState([]);

    // Filtered Products
    const filteredProducts = products.filter(product => {
        const matchesGender = filters.selectedGenders.length === 0 || filters.selectedGenders.some(g => g.id === product.gender);
        const matchesBrand = filters.selectedBrands.length === 0 || filters.selectedBrands.includes(product.brand);
        const matchesSport = filters.selectedSports.length === 0 || filters.selectedSports.some(s => s.name === product.sport);
        const matchesPrice = product.price >= filters.minValue && product.price <= filters.maxValue;
        const matchesColor = filters.selectedColors.length === 0 || filters.selectedColors.some(color => product.colors.some(c => c.color === color.color));
        const matchesSize = filters.selectedSizes.length === 0 || filters.selectedSizes.some(size => product.shoeDetails.some(sz => sz.size === size.value_VN));
        const matchesSale = !filters.isSale || product.isSale;
        const matchesIsNew = !filters.isNewest || product.isNew;

        return matchesGender && matchesBrand && matchesSport && matchesPrice && matchesColor && matchesSize && matchesSale && matchesIsNew;
    });

    // Pagination logic
    const totalPages = Math.ceil(filteredProducts.length / itemsPerPage);
    const indexOfLastItem = currentPage * itemsPerPage;
    const indexOfFirstItem = indexOfLastItem - itemsPerPage;
    const currentItems = filteredProducts.slice(indexOfFirstItem, indexOfLastItem);

    const toggleFavorite = (shoe) => {
        setFavorites((prevFavorites) =>
            prevFavorites.includes(shoe)
                ? prevFavorites.filter(fav => fav !== shoe)
                : [...prevFavorites, shoe]
        );
    };

    return (
        <div>
            <ul className="row row-cols-4 product-list">
                {currentItems.map(shoe => (
                    <ShoeItem
                        key={shoe.id}
                        shoe={shoe}
                        toggleFavorite={toggleFavorite}
                        isFavorite={favorites.includes(shoe)}
                    />
                ))}
            </ul>

            <PaginationControls
                totalPages={totalPages}
                currentPage={currentPage}
                setCurrentPage={setCurrentPage}
            />
        </div>
    );
}

export default ProductsList;
