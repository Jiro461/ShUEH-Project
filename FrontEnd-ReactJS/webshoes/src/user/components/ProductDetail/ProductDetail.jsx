import React, { useEffect, useState } from "react";
import config from "../../../config/config.json";
import RatingStars from "../RatingStars/RatingStars";
import { useNavigate } from "react-router-dom";
import useFetchUserID from "../../hooks/useFetchUserID";

const ProductDetail = ({ product, error, loading }) => {
  const navigate = useNavigate();
  const [selectedSize, setSelectedSize] = useState(null);
  const [isModalOpen, setIsModalOpen] = useState(false);
  const [selectedImage, setSelectedImage] = useState("");
  const [favoriteList, setFavoriteList] = useState([]); // Danh sách các sản phẩm yêu thích

  // Sử dụng custom hook để lấy userID
  const userID = useFetchUserID();

  useEffect(() => {
    // Lấy danh sách yêu thích khi component được mount
    const fetchFavoriteList = async () => {
      try {
        const response = await fetch(
          `${process.env.REACT_APP_API_URL}/api/WishList`,
          { credentials: "include" }
        );
        if (!response.ok) throw new Error("Không thể lấy danh sách yêu thích");

        const data = await response.json();
        setFavoriteList(data.wishListItems || []);
      } catch (error) {
        console.error("Lỗi khi lấy danh sách yêu thích:", error);
      }
    };

    fetchFavoriteList();
  }, []);

  if (loading) {
    return <div>Loading...</div>;
  }

  if (error) {
    return <div>Error: {error}</div>;
  }

  // Xử lý chọn size giày
  const handleSizeSelect = (size) => {
    setSelectedSize(size);
  };

  // Kiểm tra xem sản phẩm hiện tại có nằm trong danh sách yêu thích không
  const isFavorite = favoriteList.some((item) => item.id === product.id);

  // Xử lý khi thêm sản phẩm vào giỏ hàng
  const handleAddToCart = async () => {
    if (!userID) {
      navigate("/");
    } else if (!selectedSize) {
      alert("Vui lòng chọn size trước khi thêm vào giỏ hàng.");
    } else {
      try {
        const response = await fetch(
          `${process.env.REACT_APP_API_URL}/api/Cart/add?shoeId=${product.id}&size=${selectedSize}`,
          {
            method: "POST",
            headers: {
              "Content-Type": "application/json",
            },
            credentials: "include",
          }
        );

        if (response.ok) {
          alert("Đã thêm vào giỏ hàng!");
        } else {
          throw new Error("Không thể thêm vào giỏ hàng");
        }
      } catch (error) {
        console.error("Lỗi:", error);
      }
    }
  };

  // Xử lý khi người dùng nhấn vào nút yêu thích
  const handleToggleFavorite = async () => {
    if (!userID) {
      alert("Bạn phải đăng nhập để sử dụng chức năng này.");
      navigate("/");
      return;
    }

    try {
      const method = isFavorite ? "DELETE" : "POST";
      const url = `${process.env.REACT_APP_API_URL}/api/WishList/${product.id}`;

      const response = await fetch(url, {
        method,
        headers: {
          "Content-Type": "application/json",
        },
        credentials: "include",
      });

      if (!response.ok) throw new Error("Lỗi khi cập nhật danh sách yêu thích");

      // Cập nhật danh sách yêu thích
      setFavoriteList(
        (prevList) =>
          isFavorite
            ? prevList.filter((item) => item.id !== product.id) // Xóa nếu đã yêu thích
            : [...prevList, product] // Thêm nếu chưa yêu thích
      );
    } catch (error) {
      console.error("Lỗi khi cập nhật danh sách yêu thích:", error);
    }
  };

  // Các phần tử hình ảnh và kích thước
  const img_shoe = product.otherImages.map((img_url, index) => (
    <div
      key={`image-${index}`}
      className="ava-shoe"
      onClick={() =>
        openModal(`${process.env.REACT_APP_API_URL}/${img_url.url}`)
      }
    >
      <img
        src={`${process.env.REACT_APP_API_URL}/${img_url.url}`}
        alt={`Thumbnail ${index + 1}`}
      />
    </div>
  ));

  // Xử lý mở modal
  const openModal = (imageUrl) => {
    setSelectedImage(imageUrl);
    setIsModalOpen(true);
  };

  // Xử lý đóng modal
  const closeModal = () => {
    setIsModalOpen(false);
    setSelectedImage("");
  };

  // Các phần tử kích thước giày
  const shoe_size = product.shoeDetails.map((shoe, index) => (
    <div
      key={`size-${index}`}
      className={`col-2 size ${selectedSize === shoe.size ? "selected" : ""}`}
      onClick={() => handleSizeSelect(shoe.size)}
    >
      {shoe.size}
    </div>
  ));

  return (
    <>
      <img
        src={process.env.PUBLIC_URL + "/img/back_shoe.png"}
        alt="Background"
        className="vector-img"
      />

      <div className="col-md-12 col-lg-6 col-xl-6 g img-background box">
        <div className="line-vector">
          <img
            src={process.env.PUBLIC_URL + "/img/Vector4.png"}
            alt="Vector 4"
            className="vector-4"
          />
          <img
            src={process.env.PUBLIC_URL + "/img/Vector5.png"}
            alt="Vector 5"
            className="vector-5"
          />
        </div>
        <img
          src={`${process.env.REACT_APP_API_URL}/${product.imageUrl}`}
          alt={product.name}
          className="shoe-img"
        />
      </div>

      <div className="col-md-12 col-lg-1 col-xl-1 ava-shoe-selection">
        {img_shoe}
      </div>

      <div className="col-md-12 col-lg-12 col-xl-3 detail-style">
        <h2>{product.name}</h2>

        <RatingStars rating={product.averageRating} />

        <h4>
          {product.isSale ? (
            <>
              <span
                style={{
                  textDecoration: "line-through",
                  fontSize: "23px",
                  color: "#000",
                  marginRight: "10px",
                }}
              >
                {product.price.toLocaleString("vi-VN")}đ
              </span>
              {product.salePrice.toLocaleString("vi-VN")}đ
            </>
          ) : (
            `${product.price}`
          )}
        </h4>

        <div className="select-size">
          <div className="select-button">
            <div>Select size</div>
          </div>
          <div className="row row-cols-5 size-box">{shoe_size}</div>
        </div>

        <div className="add-to-cart">
          <button className="add-cart" onClick={handleAddToCart}>
            Add to cart
          </button>
          <div className="heart" onClick={handleToggleFavorite}>
            <i
              className={`fa-solid fa-heart ${
                isFavorite ? "active-heart" : ""
              }`}
            />
          </div>
        </div>
      </div>

      {isModalOpen && (
        <div className="modal-overlay" onClick={closeModal}>
          <div className="modal-content">
            <img src={selectedImage} alt="Selected Shoe" />
          </div>
        </div>
      )}
    </>
  );
};

export default ProductDetail;
