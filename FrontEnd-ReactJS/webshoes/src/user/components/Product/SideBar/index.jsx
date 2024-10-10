import React from 'react';
import { genders, sports, minPrices, maxPrices, colors, sizes } from './dataSidebar';

function SideBar() {
    const genderList = genders.map((gender, index) => (
        <div key={index} className="item">
            <h4>{gender.sex}</h4>
            <input type="checkbox" id={gender.id} />
            <label htmlFor={gender.id} />
        </div>
    ));

    const sportList = sports.map((sport, index) => (
        <div key={index} className="item">
            <h4>{sport.name}</h4>
            <input type="checkbox" id={sport.id} />
            <label htmlFor={sport.id} />
        </div>
    ));

    const colorList = colors.map((color, index) => (
        <div key={index} className="col-1 item" style={{backgroundColor: color.col}}/>
    ));

    const sizeList = sizes.map((size, index) => (
        <div key={index} id={size.id} className="col-1 size">{size.value}</div>
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
                    <div className={minPrices.id + " price"}>${minPrices.value}</div>
                    <div className={maxPrices.id + " price"}>${maxPrices.value}</div>
                </div>
                <div className="range-slider">
                    <input type="range" min={minPrices.value} max={maxPrices.value} defaultValue={minPrices.value} id="min-price"/>
                    <input type="range" min={minPrices.value} max={maxPrices.value} defaultValue={maxPrices.value} id="max-price"/>
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
        </div>
    );
}

export default SideBar;
