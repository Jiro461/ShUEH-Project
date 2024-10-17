import React, { useState } from 'react';
import { createBrowserRouter, RouterProvider, Route, Link } from "react-router-dom";
import UserHome from './user/pages/UserHome/UserHome.jsx';
import AdminHome from './admin/pages/AdminHome/AdminHome.jsx';
import AdminLayout from './layouts/admin/AdminLayout.jsx';
import UserLayout from './layouts/user/UserLayout.jsx';
import './App.scss';

// Định nghĩa component SignInComponent
const SignInComponent = () => {
  const [responseMessage, setResponseMessage] = useState('');
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState(null);

  const handleLogin = () => {
    // Chuyển hướng đến API của ASP.NET để bắt đầu xác thực
    window.location.href = 'http://localhost:5118/api/account/sign-in';
};

  return (
    <div>
      <h1>Sign In</h1>
      <button onClick={handleLogin} disabled={loading}>
        {loading ? 'Signing In...' : 'Sign In'}
      </button>
      {responseMessage && <p>{responseMessage}</p>}
      {error && <p style={{ color: 'red' }}>{error}</p>}
    </div>
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
        element: <UserHome />,
      },
      {
        path: "/sign-in",
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
