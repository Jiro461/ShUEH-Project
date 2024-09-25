import React from 'react';
import { Outlet } from 'react-router-dom';
import Navbar from '../../user/components/navbar/Navbar';

import './UserLayout.scss'
import PropTypes from 'prop-types';

const UserLayout = () => {
    return (
        <div className='main'>
            <Navbar></Navbar>
            <Outlet></Outlet>
        </div>
    );
};

UserLayout.propTypes = {
    
};

export default UserLayout;