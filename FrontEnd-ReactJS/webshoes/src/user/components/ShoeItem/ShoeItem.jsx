import React, { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import config from "../../../config/config.json";
import "./style.css"

function ShoeItem({ shoe, shoeID }) {
    const navigate = useNavigate();
    const { SERVER_API } = config;
    const [favoriteList, setFavoriteList] = useState([]); // Danh sách các sản phẩm yêu thích
    const [favorites, setFavorites] = useState([]);

    const toggleFavorite = (shoe) => {
        setFavorites((prevFavorites) =>
            prevFavorites.includes(shoe)
                ? prevFavorites.filter(fav => fav !== shoe)
                : [...prevFavorites, shoe]
        );
    };

    // Lấy danh sách yêu thích từ API khi component được mount
    useEffect(() => {
        const fetchFavoriteList = async () => {
            try {
                const response = await fetch(`${SERVER_API}/api/WishList`, { credentials: "include" });
                if (!response.ok) throw new Error("Không thể lấy danh sách yêu thích");
                
                const data = await response.json();
                setFavoriteList(data.wishListItems || []);
            } catch (error) {
                console.error("Lỗi khi lấy danh sách yêu thích:", error);
            }
        };

        fetchFavoriteList();
    }, []);

    // Kiểm tra xem sản phẩm hiện tại có nằm trong danh sách yêu thích không
    const isShoeFavorite = favoriteList.some(item => item.id === shoe.id);

    const handleToggleFavorite = async () => {
        try {
            // Gọi API để lấy UserID
            const response = await fetch(`${SERVER_API}/api/Account/cookieGetById`, { credentials: "include" });
            if (!response.ok) throw new Error("Không thể lấy thông tin người dùng");

            const { id: userId } = await response.json();
            if (!userId) {
                alert("Bạn phải đăng nhập để sử dụng chức năng này.");
                return;
            }

            const method = isShoeFavorite ? 'DELETE' : 'POST';
            const url = `${SERVER_API}/api/WishList/${shoe.id}`;

            // Gửi yêu cầu POST/DELETE
            const favoriteResponse = await fetch(url, {
                method,
                headers: {
                    'Content-Type': 'application/json',
                },
                credentials: "include"
            });

            if (!favoriteResponse.ok) throw new Error("Lỗi khi cập nhật danh sách yêu thích");

            // Cập nhật trạng thái yêu thích trong UI
            toggleFavorite(shoe);

            // Cập nhật danh sách yêu thích
            setFavoriteList(prevList =>
                isShoeFavorite
                    ? prevList.filter(item => item.id !== shoe.id) // Xóa nếu đã yêu thích
                    : [...prevList, shoe] // Thêm nếu chưa yêu thích
            );

        } catch (error) {
            console.error("Lỗi khi cập nhật danh sách yêu thích:", error);
        }
    };

    return (
        <li className="col item">
            <div className="image">
                <div className='url_img'>
                    <img src={`${process.env.REACT_APP_API_URL}/${shoe.imageUrl}`} alt={shoe.name} />
                </div>
                <button
                    type="button"
                    className="btn-buynow"
                    onMouseDown={() => toggleFavorite(shoe)}
                >
                    BUY NOW
                </button>
            </div>
            <a onClick={() => navigate(`/product/${shoe.id || shoeID}`)}>
                <div className={`new ${shoe.isNew ? "active" : ""}`}>New</div>
                <div className="item-detail">
                    <h4>{shoe.name} / {shoe.brand}</h4>
                    <p>Pricing ${shoe.price}</p>
                </div>
            </a>
            <div className="btn-heart" onClick={handleToggleFavorite}>
                <i className={`fa-solid fa-heart ${isShoeFavorite ? 'active-heart' : ''}`} />
            </div>
        </li>
    );
}

export default ShoeItem;
