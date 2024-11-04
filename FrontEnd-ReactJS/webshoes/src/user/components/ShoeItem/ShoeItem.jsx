import React from "react";
import { useNavigate } from "react-router-dom";
import config from "../../../config/config.json"

function ShoeItem({ shoe, toggleFavorite, isFavorite }) {
    const navigate = useNavigate();
    const { SERVER_API } = config;
    
    return (
        <li className="col item">
            <div className="image">
                <div className='url_img'>
                    <img src={`${SERVER_API}/${shoe.imageUrl}`} alt={shoe.name} />
                </div>
                <button
                    type="button"
                    className="btn-buynow"
                    onMouseDown={() => toggleFavorite(shoe)}
                >
                    BUY NOW
                </button>
            </div>
            <a onClick={() => navigate(`/product/${shoe.id}`)}>
                <div className={`new ${shoe.isNew ? "active" : ""}`}>New</div>
                <div className="item-detail">
                    <h4>{shoe.name} / {shoe.brand}</h4>
                    <p>Pricing ${shoe.price}</p>
                </div>
            </a>
            <div className="btn-heart" onClick={() => toggleFavorite(shoe)}>
                <i className={`fa-solid fa-heart ${isFavorite ? 'active-heart' : ''}`} />
            </div>
        </li>
    )
}

export default ShoeItem;