import React from 'react';
import { Outlet } from 'react-router-dom'; // Dùng Outlet để hiển thị các route con
import Navbar from '../../user/components/navbar/Navbar' // Import Navbar cho người dùng
import Chat from '../../admin/components/chat/Chat'; // Import Chat cho admin
import './UserLayout.scss' // Import file CSS cho layout người dùng
import PropTypes from 'prop-types'; // PropTypes giúp xác định loại dữ liệu của props

const UserLayout = () => {
    return (
        <div className='user-main'> {/* Bao bọc toàn bộ layout trong div */}
            <Navbar></Navbar> {/* Hiển thị Navbar */}
            <Outlet></Outlet> {/* Vị trí để render các route con */}
            <Chat /> {/* Hiển thị chat cho admin */}
        </div>
    );
};

UserLayout.propTypes = { 
    // Ở đây có thể thêm các kiểu dữ liệu cho props nếu cần
};

export default UserLayout;
