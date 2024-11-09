import React, { useState } from 'react';
import { createBrowserRouter, RouterProvider, Route, Link } from "react-router-dom";
import AdminHome from './admin/pages/AdminHome/AdminHome.jsx';
import AdminLayout from './layouts/admin/AdminLayout.jsx';
import UserLayout from './layouts/user/UserLayout.jsx';
import Users from './admin/pages/Users/Users.jsx';
import Product from './user/pages/ProductPage/ProductPage.jsx';
import PaymentPage from './user/pages/PaymentPage/PaymentPage.jsx';
import ProductDetailPage from './user/pages/ProductDetailPage/ProductDetailPage.jsx';
import ProfilePage from './user/pages/ProfilePage/ProfilePage.jsx';
import UserHome from './user/pages/UserHome/UserHome.jsx';
import AdminLogin from './admin/pages/AdminLogin/AdminLogin.jsx';
import './App.scss';

// Định nghĩa component SignInComponent
const SignInComponent = () => {
  const handlePayment = async () => {
    const data = {
      fullname: "Mạch Gia Huy",
      description: "Thanh toán đơn hàng",
      amount: 10000000.00,
      createDate: new Date().toISOString(),
      orderId: "0785d59b-3b30-4308-8213-04eed4318df9",
    };

    try {
      const response = await fetch("http://localhost:5118/api/payment", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(data),
      });; 
      if (response.ok) {
        const responseData = await response.json();
        const paymentUrl = responseData.paymentUrl; // Lấy URL thanh toán từ response
        window.location.href = paymentUrl; // Điều hướng người dùng đến URL thanh toán
      }
    } catch (error) {
      console.error("Lỗi khi thực hiện thanh toán:", error);
    }
  };

  return (
    <button onClick={handlePayment}>Sign In</button>
  );
};


// Tạo router cho ứng dụng
const router = createBrowserRouter([
  {
    path: "/",
    element: <UserLayout />,
    children: [
      {
        path: "/",
        element: <SignInComponent />, // Thêm route cho SignInComponent
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

    ]
    ,
  },
  {
    path: "/admin/login",
    element: <AdminLogin />,
  }
]);

// Component App
function App() {
  return (
    <RouterProvider router={router} />
  );
}

export default App;
