import React, { useState } from 'react';
import { createBrowserRouter, RouterProvider, Route, Link } from "react-router-dom";
import AdminHome from './admin/pages/AdminHome/AdminHome.jsx';
import AdminLayout from './layouts/admin/AdminLayout.jsx';
import UserLayout from './layouts/user/UserLayout.jsx';
import UserHome from './user/pages/UserHome/UserHome.jsx';
import Users from './admin/pages/Users/Users.jsx';
import User from "./admin/pages/User/User.jsx";
import AdminProducts from "./admin/pages/AdminProducts/AdminProducts.jsx";
import AdminProduct from "./admin/pages/AdminProduct/AdminProduct.jsx";
import Orders from "./admin/pages/Orders/Orders.jsx"
import AdminCalendar from "./admin/pages/Calendar/Calendar.jsx"
import PaymentPage from './user/pages/PaymentPage/PaymentPage.jsx';
import ProductDetailPage from './user/pages/ProductDetailPage/ProductDetailPage.jsx';
import ProfilePage from './user/pages/ProfilePage/ProfilePage.jsx';
import './App.scss';

// Tạo router cho ứng dụng
const router = createBrowserRouter([
  {
    path: "/",
    element: <UserLayout />,
    children: [
      {
        path: "/",
        element: <UserHome />, // Thêm route cho SignInComponent
      },
    ],
  },
  {
    path: "/admin",
    element: <AdminLayout />,
    children: [
      {
        path: "",
      element: <AdminHome />, // Giả định AdminClient đã được định nghĩa
      },
      {
        path: "/admin/users",
        element: <Users />,
      },
      {
        path: "/admin/users/:id",
        element: <User />,
      },
      {
        path: "/admin/products",
        element: <AdminProducts />,
      },
      {
        path: "/admin/products/:id",
        element: <AdminProduct />,
      },
      {
        path: "/admin/orders/",
        element: <Orders />,
      },
      {
        path: "/admin/calendar/",
        element: <AdminCalendar />,
      },
    ],
  },
]);

// Component App
function App() {
  return (
    <RouterProvider router={router} />
  );
}

export default App;
