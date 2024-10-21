import React from 'react';
import { Outlet } from 'react-router-dom';

const UserLayout = (props) => {
    return (
        <> 
            <Outlet />
        </>
    )
};


export default UserLayout;