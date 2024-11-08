// ProtectedRoute.js
import { Outlet, Navigate } from 'react-router-dom';
import * as authService from "../../../services/authService"
import { useEffect, useState } from "react";

const PrivateAdminRoutes = (props) => {
    const [loading, setLoading] = useState(true);
    const [isAdmin, setIsAdmin] = useState(false);

    useEffect(() => {
      const checkAuth = async () => {
        const res = await authService.loginStatus()

        if (res.status === 401) {
            setLoading(false)
        }

        if (res.data.role === "Admin"){
            setIsAdmin(true)
        } else {
            setIsAdmin(false)
        }

        setLoading(false);
        }

        checkAuth();

    }, []);

    if (loading) {
        return
    }

    return isAdmin ? <Outlet/> : <Navigate to="/" />;
};

export default PrivateAdminRoutes;
