import React, { useRef, useEffect } from 'react';
import { genders, sports, minPrices, maxPrices, colors, sizes } from './dataSidebar';

function ProductsSidebar({ filters, updateFilters }) {
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
    // Render Sỏit
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
        if (value < filters.maxValue) {
            updateFilters({
                minValue: value,
                isMinOnTop: true,
                isMaxOnTop: false,
            });
        }
    };

    // xử lý max slider change
    const handleMaxSliderChange = (event) => {
        const value = parseInt(event.target.value);
        if (value > filters.minValue) {
            updateFilters({
                maxValue: value,
                isMaxOnTop: true,
                isMinOnTop: false,
            });
        }
    };

    // Ref to access DOM elements
    const progressBarRef = useRef(null);

    // Update slider and progress bar
    useEffect(() => {
        const minPercentage = (filters.minValue / (maxPrices.value - minPrices.value)) * 100;
        const maxPercentage = (filters.maxValue / (maxPrices.value - minPrices.value)) * 100;

        if (progressBarRef.current) {
            progressBarRef.current.style.left = `${minPercentage}%`;
            progressBarRef.current.style.right = `${100 - maxPercentage}%`;
        }
    }, [filters.minValue, filters.maxValue]);

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
    const sizeList = sizes.map((size, index) => (
        <div
            key={index}
            id={size.id}
            className={`col-1 size ${filters.selectedSizes.some(s => s.id === size.id) ? 'selected' : ''}`}
            onClick={() => handleSizeChange(size.id, size.value)}
        >
            {size.value}
        </div>
    ));

    // xử lý thay đổi size cho các selection
    const handleSizeChange = (id, value) => {
        const updatedSizes = filters.selectedSizes.find(size => size.id === id)
            ? filters.selectedSizes.filter(size => size.id !== id)
            : [...filters.selectedSizes, { id, value }];

        updateFilters({ selectedSizes: updatedSizes });
    };
        // Sale ---------------------------------------------------------------------------------------------------------------
    // Xử lý thay đổi sale checkbox
    const handleSaleChange = () => {
        updateFilters({ isOnSale: !filters.isOnSale });
    };

    return (
        <div className="col-lg-2 col-md-1 sidebar">
            <h1 className="heading">Filter</h1>
            <div className="gender">{genderList}</div>
            <div className="dividing-line" />
            <div className="sport">{sportList}</div>
            <div className="price-range-slider">
                <h3>Pricing</h3>
                <div className="price-values">
                    <div className={`${minPrices.id} price`}>${filters.minValue}</div>
                    <div className={`${maxPrices.id} price`}>${filters.maxValue}</div>
                </div>
                <div className="range-slider">
                    <input 
                        type="range" 
                        min={minPrices.value} 
                        max={maxPrices.value} 
                        value={filters.minValue} 
                        id="min-price" 
                        onChange={handleMinSliderChange}
                        onMouseUp={() => console.log(`Min Value: $${filters.minValue}`)}
                        className={filters.isMinOnTop ? 'overlap' : ''}
                    />
                    <input 
                        type="range" 
                        min={minPrices.value} 
                        max={maxPrices.value} 
                        value={filters.maxValue} 
                        id="max-price" 
                        onChange={handleMaxSliderChange}
                        onMouseUp={() => console.log(`Max Value: $${filters.maxValue}`)}
                        className={filters.isMaxOnTop ? 'overlap' : ''}
                    />
                </div>
                <div className="slider">
                    <div className="progress" ref={progressBarRef}/>
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
