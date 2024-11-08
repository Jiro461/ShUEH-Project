// ProtectedRoute.js
import { Outlet, Navigate } from 'react-router-dom';
import * as authService from "../../../services/authService"
import { useEffect, useState } from "react";

const PrivateUserRoutes = (props) => {
    const [loading, setLoading] = useState(true);
    const [isUser, setIsUser] = useState(false);

    useEffect(() => {
      const checkAuth = async () => {
        const res = await authService.loginStatus()
        if (res.status === 401) {
            setLoading(false)
        }

        if (res.status === 200){
            setIsUser(true)   
        } else {
            setIsUser(false)
        }
        
        setLoading(false);
        };

        checkAuth();
    }, []);

    if (loading) {
        return
    }

    return isUser ? <Outlet/> : <Navigate to="/" />;
};

export default PrivateUserRoutes;
