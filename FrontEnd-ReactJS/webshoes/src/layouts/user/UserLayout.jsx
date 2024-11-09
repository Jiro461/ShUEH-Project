import React from 'react';
import { Outlet } from 'react-router-dom';
import Navbar from '../../user/components/Navbar/Navbar'
import Chat from '../../admin/components/chat/Chat';

import './UserLayout.scss'
import PropTypes from 'prop-types';

const UserLayout = () => {
    return (
        <div className='user-main'>
            <Navbar></Navbar>
            <Outlet></Outlet>
            <Chat />
        </div>
    );
};

UserLayout.propTypes = {
    
};

export default UserLayout;