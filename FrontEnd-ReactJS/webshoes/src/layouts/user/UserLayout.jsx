import React from 'react';
import { Outlet } from 'react-router-dom';
import Chat from '../../admin/components/chat/Chat';

import './UserLayout.scss'
import PropTypes from 'prop-types';

const UserLayout = () => {
    return (
        <div className='main'>
            <Outlet></Outlet>
            <Chat />
        </div>
    );
};

UserLayout.propTypes = {
    
};

export default UserLayout;