import React from 'react'; // Import React để sử dụng JSX
import './AddBlock.scss' // Import file SCSS cho styling của component
import { useNavigate } from "react-router-dom"; // Import hook useNavigate từ React Router để điều hướng trang

// Định nghĩa component AddBlock nhận prop 'id'
const AddBlock = ({id}) => {
    const navigate = useNavigate(); // Khởi tạo hàm navigate từ React Router

    return (
        <div className="add-block" onClick={() => navigate(`/product/${id}`)}>
            {/* Khi người dùng click vào div, sẽ điều hướng tới trang chi tiết sản phẩm với id tương ứng */}
            <img src='/+.svg' alt='add' /> {/* Hình ảnh của biểu tượng thêm */}
        </div>
    );
};

export default AddBlock; // Xuất component để sử dụng ở nơi khác
