import React from 'react';
import { Outlet } from 'react-router-dom';

import './UserLayout.scss'
import PropTypes from 'prop-types';

const UserLayout = () => {
    return (
        <div className='main'>
            <Outlet></Outlet>
        </div>
    );
};

UserLayout.propTypes = {
    
};

export default UserLayout;