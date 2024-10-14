import React from 'react';
import { Outlet } from 'react-router-dom';
import Navbar from '../../admin/components/navbar/Navbar';
import Menu from '../../admin/components/menu/Menu';
import Footer from '../../admin/components/footer/Footer';
import PropTypes from 'prop-types';
import "./AdminLayout.scss"
const AdminLayout = () => {
    return (
        <div className='main'>
            <Navbar />
            <div className='admincontainer'>
                <div className='menuContainer'>
                    <Menu />
                </div>
                <div className='contentContainer'>
                    <Outlet />
                </div>
            </div>
            <Footer />
        </div>
    );
};

AdminLayout.propTypes = {

};

export default AdminLayout;