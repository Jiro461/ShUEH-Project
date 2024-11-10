import React from 'react';
import { Outlet } from 'react-router-dom'; // Dùng Outlet để hiển thị các route con
import Navbar from '../../admin/components/navbar/Navbar'; // Import Navbar cho admin
import Menu from '../../admin/components/menu/Menu'; // Import Menu cho admin
import Footer from '../../admin/components/footer/Footer'; // Import Footer cho admin
import PropTypes from 'prop-types'; // PropTypes giúp xác định kiểu dữ liệu của props
import "./AdminLayout.scss" // Import file CSS cho layout admin

const AdminLayout = () => {
    return (
        <div className='admin-main'> {/* Bao bọc toàn bộ layout trong div */}
            <Navbar /> {/* Hiển thị Navbar cho admin */}
            <div className='admin-container'> {/* Chứa các phần tử menu và nội dung */}
                <div className='menuContainer'> {/* Phần chứa Menu */}
                    <Menu /> {/* Hiển thị Menu */}
                </div>
                <div className='contentContainer'> {/* Phần chứa nội dung chính */}
                    <Outlet /> {/* Vị trí để render các route con */}
                </div>
            </div>
            <Footer /> {/* Hiển thị Footer */}
        </div>
    );
};

AdminLayout.propTypes = { 
    // Ở đây có thể thêm các kiểu dữ liệu cho props nếu cần
};

export default AdminLayout;
