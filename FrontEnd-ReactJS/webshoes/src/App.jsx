import React, { useEffect, useState } from 'react';
import { Routes, Route, useNavigate, Navigate, BrowserRouter } from "react-router-dom";
import AdminLayout from './layouts/admin/AdminLayout.jsx';
import UserLayout from './layouts/user/UserLayout.jsx';
import { publicRoutes, privateRoutes, adminRoutes } from "./routes/routes.js";
import PrivateAdminRoutes from "./user/components/PrivateRoute/PrivateAdminRoutes.js";
import PrivateUserRoutes from "./user/components/PrivateRoute/PrivateUserRoutes.js";

function App() {
    return (
        <BrowserRouter>
            <div className="App">
                <Routes>

                    <Route element={<UserLayout/>}>
                        {publicRoutes.map((route, index) => {
                            const Page = route.element;
                            return (
                                <Route
                                    key={index}
                                    path={route.path}
                                    element={<Page />}
                                >
                                    {route?.children?.map((childrenRoute, index) => {
                                        return (
                                            <Route
                                            key={index}
                                            path={childrenRoute.path}
                                            element={childrenRoute.element}
                                        />
                                        )
                                    })}
                                </Route>
                            );
                        })}
                    </Route>

                    <Route element={<PrivateUserRoutes/>}>
                        <Route element={<UserLayout/>}>
                            {privateRoutes.map((route,index) => {
                                const Page = route.element
                                return (
                                    <Route
                                        key={index}
                                        path={route.path}
                                        element={<Page/>}
                                    />
                                )
                            })}
                        </Route>
                    </Route>

                    <Route element={<PrivateAdminRoutes/>}>
                        <Route element={<AdminLayout/>}>
                            {adminRoutes.map((route,index) => {
                                const Page = route.element
                                return (
                                    <Route
                                        key={index}
                                        path={route.path}
                                        element={<Page/>}
                                    />
                                )
                            })}
                        </Route>
                    </Route>

                </Routes>
            </div>
        </BrowserRouter>
    );
}

export default App