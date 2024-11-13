import React, { useRef, useEffect, useState } from 'react';
import { genders, sports, minPrices, maxPrices, colors, sizes_VN } from './dataSidebar';

function ProductsSidebar({ filters, updateFilters, isMenuSidebarVisible }) {
    const [isMinOnTop, setIsMinOnTop] = useState(false);
    const [isMaxOnTop, setIsMaxOnTop] = useState(false);
    const [min, setMin] = useState(minPrices.value);
    const [max, setMax] = useState(maxPrices.value);

    // Gender ---------------------------------------------------------------------------------------------------------------
    // Render gender
    const genderList = genders.map((gender, index) => (
        <div key={index} className="item">
            <h4>{gender.sex}</h4>
            <input
                type="checkbox"
                id={gender.id}
                checked={filters.selectedGenders.some(g => g.id === gender.id)}
                onChange={() => handleGenderChange(gender.id, gender.sex)}
            />
            <label htmlFor={gender.id} />
        </div>
    ));

    // Xử lý gender selection
    const handleGenderChange = (id, sex) => {
        const updatedGenders = filters.selectedGenders.find(g => g.id === id)
            ? filters.selectedGenders.filter(gender => gender.id !== id)
            : [...filters.selectedGenders, { id, sex }];

        updateFilters({ selectedGenders: updatedGenders });
    };

    // Sport ---------------------------------------------------------------------------------------------------------------
    // Render sport
    const sportList = sports.map((sport, index) => (
        <div key={index} className="item">
            <h4>{sport.name}</h4>
            <input
                type="checkbox"
                id={sport.id}
                checked={filters.selectedSports.some(s => s.id === sport.id)}
                onChange={() => handleSportChange(sport.id, sport.name)}
            />
            <label htmlFor={sport.id} />
        </div>
    ));

    // Xử lý sport selection
    const handleSportChange = (id, name) => {
        const updatedSports = filters.selectedSports.find(s => s.id === id)
            ? filters.selectedSports.filter(sport => sport.id !== id)
            : [...filters.selectedSports, { id, name }];

        updateFilters({ selectedSports: updatedSports });
    };

    // Price ---------------------------------------------------------------------------------------------------------------
    // xử lý min slider change
    const handleMinSliderChange = (event) => {
        const value = parseInt(event.target.value);
        if (value < max) {
            setMin(value);
            setIsMinOnTop(true);
            setIsMaxOnTop(false);
        }
    };

    // xử lý max slider change
    const handleMaxSliderChange = (event) => {
        const value = parseInt(event.target.value);
        if (value > min) {
            setMax(value);
            setIsMinOnTop(false);
            setIsMaxOnTop(true);
        }
    };

    // Ref to access DOM elements
    const progressBarRef = useRef(null);

    // Update slider and progress bar
    useEffect(() => {
        const minPercentage = (min / (maxPrices.value - minPrices.value)) * 100;
        const maxPercentage = (max / (maxPrices.value - minPrices.value)) * 100;

        if (progressBarRef.current) {
            progressBarRef.current.style.left = `${minPercentage - 10}%`;
            progressBarRef.current.style.right = `${100 - maxPercentage + 10}%`;
        }
    }, [min, max]);

    // Color ---------------------------------------------------------------------------------------------------------------
    // Render Color
    const colorList = colors.map((color, index) => (
        <div
            key={index}
            id={color.id}
            className="col-1 item"
            style={{
                position: 'relative',
                backgroundColor: color.col,
            }}
            onClick={() => handleColorChange(color.id, color.col)}
        >
            {filters.selectedColors.some(c => c.id === color.id) && (
                <span><i className="fa-solid fa-check"></i></span>
            )}
        </div>
    ));

    // xử lý thay đổi color cho các selection
    const handleColorChange = (id, color) => {
        const updatedColors = filters.selectedColors.find(c => c.id === id)
            ? filters.selectedColors.filter(c => c.id !== id)
            : [...filters.selectedColors, { id, color }];

        updateFilters({ selectedColors: updatedColors });
    };

    // Size ---------------------------------------------------------------------------------------------------------------
    // Render Size
    const sizeList = sizes_VN.map((size, index) => (
        <div
            key={index}
            id={size.id}
            className={`col-1 size ${filters.selectedSizes.some(s => s.id === size.id) ? 'selected' : ''}`}
            onClick={() => handleSizeChange(size.id, size.value_VN)}
        >
            {filters.isSizeUK ? size.value_UK : size.value_VN}
        </div>
    ));

    // xử lý thay đổi size cho các selection
    const handleSizeChange = (id, value_VN) => {
        const updatedSizes = filters.selectedSizes.find(size => size.id === id)
            ? filters.selectedSizes.filter(size => size.id !== id)
            : [...filters.selectedSizes, { id, value_VN }];

        updateFilters({ selectedSizes: updatedSizes });
    };
    // Sale ---------------------------------------------------------------------------------------------------------------
    // Xử lý thay đổi sale checkbox
    const handleSaleChange = () => {
        updateFilters({ isSale: !filters.isSale });
    };

    return (
        <div className={`col-lg-2 col-md-1 sidebar ${isMenuSidebarVisible ? 'active' : ''}`}>
            <h1 className="heading">Filter</h1>
            <div className="gender">{genderList}</div>
            <div className="dividing-line" />
            <div className="sport">{sportList}</div>
            <div className="price-range-slider">
                <h3>Pricing</h3>
                <div className="price-values">
                    <div className={`${minPrices.id} price`}>${min}</div>
                    <div className={`${maxPrices.id} price`}>${max}</div>
                </div>
                <div className="range-slider">
                    <input
                        type="range"
                        min={minPrices.value}
                        max={maxPrices.value}
                        value={min}
                        id="min-price"
                        onChange={handleMinSliderChange}
                        onMouseUp={() => {
                            updateFilters({
                                minValue: min,
                            })
                        }}
                        className={isMinOnTop ? 'overlap' : ''}
                    />
                    <input
                        type="range"
                        min={minPrices.value}
                        max={maxPrices.value}
                        value={max}
                        id="max-price"
                        onChange={handleMaxSliderChange}
                        onMouseUp={() => {
                            updateFilters({
                                maxValue: max,
                            })
                        }}
                        className={isMaxOnTop ? 'overlap' : ''}
                    />
                </div>
                <div className="slider">
                    <div className="progress" ref={progressBarRef} />
                </div>
            </div>
            <div className="colors">
                <h3>Colors</h3>
                <div className="row row-cols-5 color-item">{colorList}</div>
            </div>
            <div className="dividing-line" />
            <div className="size-list">
                <h3>Size</h3>
                <div className="row row-cols-5 size-item">{sizeList}</div>
            </div>
            <div className="dividing-line"></div>
            <div className="sale">
                <div className="item">
                    <h3>Sale</h3>
                    <input
                        type="checkbox"
                        id="checkbox9"
                        checked={filters.isOnSale}
                        onChange={handleSaleChange}
                    />
                    <label htmlFor="checkbox9" />
                </div>
            </div>
            <div className="dividing-line"></div>
        </div>
    );
}

export default ProductsSidebar;
