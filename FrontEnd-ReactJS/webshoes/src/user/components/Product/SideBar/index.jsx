import React, { useState } from 'react';
import { genders, sports, minPrices, maxPrices, colors, sizes } from './dataSidebar';
import { hover } from '@testing-library/user-event/dist/hover';

function SideBar() {
    // State for storing selected values
    const [selectedGenders, setSelectedGenders] = useState([]);
    const [selectedSports, setSelectedSports] = useState([]);
    const [isOnSale, setIsOnSale] = useState(false);
    const [selectedSizes, setSelectedSizes] = useState([]);
    const [selectedColors, setSelectedColors] = useState([]);
    const [minValue, setMinValue] = useState(minPrices.value); // State for min price
    const [maxValue, setMaxValue] = useState(maxPrices.value); // State for max price

    console.log(selectedGenders);
    console.log(selectedSports);
    console.log(isOnSale);
    console.log(selectedSizes);
    console.log(selectedColors);

    // Handle gender selection
    const handleGenderChange = (id, sex) => {
        setSelectedGenders(prevSelectedGenders =>
            prevSelectedGenders.find(g => g.id === id)
                ? prevSelectedGenders.filter(gender => gender.id !== id)
                : [...prevSelectedGenders, { id, sex }]
        );
    };

    // Handle sport selection
    const handleSportChange = (id, name) => {
        setSelectedSports(prevSelectedSports =>
            prevSelectedSports.find(s => s.id === id)
                ? prevSelectedSports.filter(sport => sport.id !== id)
                : [...prevSelectedSports, { id, name }]
        );
    };

    // Handle sale checkbox change
    const handleSaleChange = () => {
        setIsOnSale(prevIsOnSale => !prevIsOnSale);
    };

    // Handle size change for multiple selection
    const handleSizeChange = (id, value) => {
        setSelectedSizes(prevSelectedSizes =>
            prevSelectedSizes.find(size => size.id === id)
                ? prevSelectedSizes.filter(size => size.id !== id)
                : [...prevSelectedSizes, { id, value }]
        );
    };

    // Handle color change for multiple selection
    const handleColorChange = (id, color) => {
        setSelectedColors(prevSelectedColors =>
            prevSelectedColors.find(c => c.id === id)
                ? prevSelectedColors.filter(c => c.id !== id)
                : [...prevSelectedColors, { id, color }]
        );
    };

    // Handle price range change
    const handlePriceChange = (e) => {
        const { id, value } = e.target;
        if (id === 'min-price') {
            setMinValue(value);
        } else if (id === 'max-price') {
            setMaxValue(value);
        }
    };

    // Handle mouse up event to finalize price values
    const handleMouseUp = () => {
        console.log('Final min price:', minValue);
        console.log('Final max price:', maxValue);
        // You can add logic to save these values if needed
    };

    // Map gender items
    const genderList = genders.map((gender, index) => (
        <div key={index} className="item">
            <h4>{gender.sex}</h4>
            <input
                type="checkbox"
                id={gender.id}
                checked={selectedGenders.some(g => g.id === gender.id)}
                onChange={() => handleGenderChange(gender.id, gender.sex)}
            />
            <label htmlFor={gender.id} />
        </div>
    ));

    // Map sport items
    const sportList = sports.map((sport, index) => (
        <div key={index} className="item">
            <h4>{sport.name}</h4>
            <input
                type="checkbox"
                id={sport.id}
                checked={selectedSports.some(s => s.id === sport.id)}
                onChange={() => handleSportChange(sport.id, sport.name)}
            />
            <label htmlFor={sport.id} />
        </div>
    ));

    // Map color and size items
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
            {selectedColors.some(c => c.id === color.id) && (
                <span><i className="fa-solid fa-check"></i></span>
            )}
        </div>
    ));

    const sizeList = sizes.map((size, index) => (
        <div
            key={index}
            id={size.id}
            className={`col-1 size ${selectedSizes.some(s => s.id === size.id) ? 'selected' : ''}`}
            onClick={() => handleSizeChange(size.id, size.value)}
        >
            {size.value}
        </div>
    ));

    return (
        <div className="col-lg-2 col-md-1 sidebar">
            <h1 className="heading">Filter</h1>
            <div className="gender">{genderList}</div>
            <div className="dividing-line" />
            <div className="sport">{sportList}</div>
            <div className="price-range-slider">
                <h3>Pricing</h3>
                <div className="price-values">
                    <div className={minPrices.id + " price"}>${minValue}</div>
                    <div className={maxPrices.id + " price"}>${maxValue}</div>
                </div>
                <div className="range-slider">
                    <input 
                        type="range" 
                        min={minPrices.value} 
                        max={maxPrices.value} 
                        value={minValue} 
                        id="min-price" 
                        onChange={handlePriceChange}
                        onMouseUp={handleMouseUp} // Call function when mouse is released
                    />
                    <input 
                        type="range" 
                        min={minPrices.value} 
                        max={maxPrices.value} 
                        value={maxValue} 
                        id="max-price" 
                        onChange={handlePriceChange}
                        onMouseUp={handleMouseUp} // Call function when mouse is released
                    />
                </div>
                <div className="slider">
                    <div className="progress" />
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
                        checked={isOnSale}
                        onChange={handleSaleChange}
                    />
                    <label htmlFor="checkbox9" />
                </div>
            </div>
            <div className="dividing-line"></div> 
        </div>
    );
}

export default SideBar;
