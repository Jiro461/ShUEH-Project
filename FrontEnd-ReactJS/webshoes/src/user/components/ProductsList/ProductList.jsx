import React, { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';

function ProductsList({ filters }) {
    const itemsPerPage = 12; 
    const [currentPage, setCurrentPage] = useState(1);
    const [animate, setAnimate] = useState(false);
    const [favorites, setFavorites] = useState([]); 
    const [isButtonHeld, setIsButtonHeld] = useState(false);
    const [products, setProducts] = useState([]);
    const navigate = useNavigate();

    useEffect(() => {
        fetch('http://localhost:3004/shoes')
            .then((response) => response.json())
            .then((data) => {
                const filteredData = data.map((product) => ({
                    id: product.id,
                    name: product.name,
                    price: product.price,
                    gender: product.gender, // Giả định dữ liệu sản phẩm có thuộc tính gender
                    sport: product.sport, // Giả định dữ liệu sản phẩm có thuộc tính sport
                    size: product.size, // Giả định dữ liệu sản phẩm có thuộc tính size
                    color: product.color, // Giả định dữ liệu sản phẩm có thuộc tính color
                    isOnSale: product.isOnSale, // Giả định dữ liệu sản phẩm có thuộc tính isOnSale
                }));
                setProducts(filteredData);
            })
            .catch((error) => console.error('Error fetching data:', error));
    }, []);

    useEffect(() => {
        setAnimate(true);
        const timer = setTimeout(() => setAnimate(false), 500);
        return () => clearTimeout(timer);
    }, [currentPage]);

    // Lọc sản phẩm dựa trên các bộ lọc
    const filteredProducts = products.filter(product => {
        const matchesGender = filters.selectedGenders.length === 0 || filters.selectedGenders.some(g => g.sex === product.gender);
        const matchesBrand = filters.selectedBrands.length === 0 || filters.selectedBrands.includes(product.brand);
        const matchesSport = filters.selectedSports.length === 0 || filters.selectedSports.some(s => s.name === product.sport);
        const matchesSize = filters.selectedSizes.length === 0 || filters.selectedSizes.some(size => size.value === product.size);
        const matchesColor = filters.selectedColors.length === 0 || filters.selectedColors.some(c => c.color === product.color);
        const matchesPrice = product.price >= filters.minValue && product.price <= filters.maxValue;
        const matchesSale = !filters.isOnSale || product.isOnSale;
        console.log(matchesBrand + "1");
        // return matchesGender && matchesSport && matchesSize && matchesColor && matchesPrice && matchesSale;
        return matchesBrand;
    });

    const indexOfLastItem = currentPage * itemsPerPage;
    const indexOfFirstItem = indexOfLastItem - itemsPerPage;
    const currentItems = filteredProducts.slice(indexOfFirstItem, indexOfLastItem);

    const toggleFavorite = (shoe) => {
        setFavorites((prevFavorites) =>
            prevFavorites.includes(shoe)
                ? prevFavorites.filter((fav) => fav !== shoe)
                : [...prevFavorites, shoe]
        );
    };

    const handleMouseDown = () => {
        setIsButtonHeld(true);
    };

    const handleMouseUp = () => {
        setIsButtonHeld(false);
    };

    const shoeList = currentItems.map((shoe) => (
        <li key={shoe.id} className={`col item ${animate ? 'fade-in' : ''}`}>
            <div className="image">
                <img src={process.env.PUBLIC_URL + '/img/revolution7.png'} alt={shoe.name} />
                <button
                    type="button"
                    className={`btn-buynow ${isButtonHeld ? 'scale-up' : ''}`}
                    onMouseDown={handleMouseDown}
                    onMouseUp={handleMouseUp}
                    onMouseLeave={handleMouseUp}
                >
                    BUY NOW
                </button>
            </div>
            <a href="" onClick={() => navigate(`/product/${shoe.id}`)}>
                <div className="new">New</div>
                <div className="item-detail">
                    <h4>{shoe.name}</h4>
                    <p>Pricing ${shoe.price}</p>
                </div>
            </a>
            <div
                className="btn-heart"
                onClick={() => toggleFavorite(shoe)} 
            >
                <i
                    className={`fa-solid fa-heart ${favorites.includes(shoe) ? 'active-heart' : ''}`}
                />
            </div>
        </li>
    ));

    const totalPages = Math.ceil(filteredProducts.length / itemsPerPage);

    const paginationButtons = Array.from({ length: totalPages }, (_, index) => (
        <button
            key={index}
            onClick={() => setCurrentPage(index + 1)}
            className={currentPage === index + 1 ? 'active' : ''}
        >
            {index + 1}
        </button>
    ));

    return (
        <div>
            <ul className="row row-cols-4 product-list">
                {shoeList}
            </ul>

            <div className="pagination-controls">
                {paginationButtons}
            </div>
        </div>
    );
}

export default ProductsList;
