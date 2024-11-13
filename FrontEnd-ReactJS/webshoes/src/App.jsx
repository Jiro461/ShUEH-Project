import React, { useEffect, useState } from 'react';
import { Routes, Route, useNavigate, Navigate, BrowserRouter } from "react-router-dom";
import AdminLayout from './layouts/admin/AdminLayout.jsx';
import UserLayout from './layouts/user/UserLayout.jsx';
import { publicRoutes, privateRoutes, adminRoutes } from "./routes/routes.js";
import PrivateAdminRoutes from "./user/components/PrivateRoute/PrivateAdminRoutes.js";
import PrivateUserRoutes from "./user/components/PrivateRoute/PrivateUserRoutes.js";

function App() {
    return (
        <BrowserRouter> {/* Dùng BrowserRouter để quản lý routing trong ứng dụng */}
            <div className="App">
                <Routes> {/* Định nghĩa các route trong ứng dụng */}

                    <Route element={<UserLayout/>}> {/* Dùng layout cho người dùng */}
                        {publicRoutes.map((route, index) => {  // Duyệt qua các route công cộng
                            const Page = route.element;
                            return (
                                <Route
                                    key={index}
                                    path={route.path}
                                    element={<Page />}
                                >
                                </Route>
                            );
                        })}
                    </Route>

                    <Route element={<PrivateUserRoutes/>}> {/* Kiểm tra quyền truy cập của người dùng */}
                        <Route element={<UserLayout/>}> {/* Dùng layout cho người dùng */}
                            {privateRoutes.map((route,index) => {  // Duyệt qua các route riêng tư
                                const Page = route.element
                                return (
                                    <Route
                                        key={index}
                                        path={route.path}
                                        element={<Page/>}
                                    >
                                        {route?.children?.map((childrenRoute, index) => {  // Duyệt qua các route con
                                        return (
                                            <Route
                                            key={index}
                                            path={childrenRoute.path}
                                            element={<childrenRoute.element />}  // Hiển thị component con
                                        />
                                        )
                                    })}
                                    </Route>
                                )
                            })}
                        </Route>
                    </Route>

                    <Route element={<PrivateAdminRoutes/>}> {/* Kiểm tra quyền truy cập của admin */}
                        <Route element={<AdminLayout/>}> {/* Dùng layout cho admin */}
                            {adminRoutes.map((route,index) => {  // Duyệt qua các route admin
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
