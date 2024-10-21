import React, { useState, useEffect } from 'react';
import { shoes } from './dataProduct';

function ProductList() {
    const itemsPerPage = 12; 
    const [currentPage, setCurrentPage] = useState(1);
    const [animate, setAnimate] = useState(false);
    const [favorites, setFavorites] = useState([]); 
    const [isButtonHeld, setIsButtonHeld] = useState(false); // Trạng thái giữ chuột

    useEffect(() => {
        setAnimate(true);
        const timer = setTimeout(() => setAnimate(false), 500);
        return () => clearTimeout(timer);
    }, [currentPage]);

    const indexOfLastItem = currentPage * itemsPerPage;
    const indexOfFirstItem = indexOfLastItem - itemsPerPage;
    const currentItems = shoes.slice(indexOfFirstItem, indexOfLastItem);

    const toggleFavorite = (shoe) => {
        setFavorites((prevFavorites) =>
            prevFavorites.includes(shoe)
                ? prevFavorites.filter((fav) => fav !== shoe)
                : [...prevFavorites, shoe]
        );
    };

    // Khi nhấn giữ và nhả nút "BUY NOW"
    const handleMouseDown = () => {
        setIsButtonHeld(true); // Khi giữ chuột
    };

    const handleMouseUp = () => {
        setIsButtonHeld(false); // Khi nhả chuột
    };

    const shoeList = currentItems.map((shoe, index) => (
        <li key={index} className={`col item ${animate ? 'fade-in' : ''}`}>
            <div className="image">
                <img src={process.env.PUBLIC_URL + '/img/revolution7.png'} alt={shoe.name} />
                <button
                    type="button"
                    className={`btn-buynow ${isButtonHeld ? 'scale-up' : ''}`}
                    onMouseDown={handleMouseDown}
                    onMouseUp={handleMouseUp}
                    onMouseLeave={handleMouseUp} // Để chắc chắn nút trở lại bình thường khi rời chuột
                >
                    BUY NOW
                </button>
            </div>
            <a href="">
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
                    className={`fa-solid fa-heart ${favorites.includes(shoe) ? 'active-heart' : ''
                        }`}
                />
            </div>
        </li>
    ));

    const totalPages = Math.ceil(shoes.length / itemsPerPage);

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

export default ProductList;
