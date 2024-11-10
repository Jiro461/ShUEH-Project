import './style.css'
import { useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';

function ProfileFavorite() {
    const [favoriteList, setFavoriteList] = useState([]); // Danh sách các sản phẩm yêu thích
    const navigate = useNavigate();  // Khởi tạo useNavigate để điều hướng

    // Lấy danh sách yêu thích từ API khi component được mount
    useEffect(() => {
        const fetchFavoriteList = async () => {
            try {
                const response = await fetch(`${process.env.REACT_APP_API_URL}/api/WishList`, { credentials: "include" });
                if (!response.ok) throw new Error("Không thể lấy danh sách yêu thích");
                
                const data = await response.json();
                setFavoriteList(data.wishListItems || []);
            } catch (error) {
                console.error("Lỗi khi lấy danh sách yêu thích:", error);
            }
        };

        fetchFavoriteList();
    }, [favoriteList]);

    const handleToggleFavorite = async(item) => {
        try {
            const method = 'DELETE';
            const url = `${process.env.REACT_APP_API_URL}/api/WishList/${item.id}`;
    
            const favoriteResponse = await fetch(url, {
                method,
                headers: {
                    'Content-Type': 'application/json',
                },
                credentials: "include"
            });
    
            if (!favoriteResponse.ok) throw new Error("Lỗi khi cập nhật danh sách yêu thích");

            setFavoriteList(prevList =>
                    prevList.filter(item => item.id !== item.id) // Xóa nếu đã yêu thích
            );
        } catch {

        }
    }


    
    return (
        <ul className="row row-cols-3 favour">
            {favoriteList.map((item, index) => (
                <li key={index} className='col favour-item'>
                    {item.isNew && <div className="new">New</div>}
                    <div className='image-favour'><img src={`${process.env.REACT_APP_API_URL}/${item.imageUrl}`} alt={item.name} /></div>
                    <a href="">
                        <div className="favour-item-detail">
                            <h4>{item.name}</h4>
                            <p>Pricing ${item.price}</p>
                        </div>
                    </a>
                    <div className="btn-heart" onClick={() => handleToggleFavorite(item)}>
                        <i className={`fa-solid fa-heart`}/>
                    </div>
                    <div className='add-to-cart'>
                        <button className='btn-addToCart' onClick={() => navigate(`/product/${item.id}`)}>Add To Cart</button>
                    </div>
                </li>
            ))}
        </ul>
    );
}

export default ProfileFavorite;
