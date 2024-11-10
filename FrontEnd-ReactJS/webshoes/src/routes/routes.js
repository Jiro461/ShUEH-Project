import AdminHome from "../admin/pages/AdminHome/AdminHome.jsx";
import UserHome from '../user/pages/UserHome/UserHome.jsx';
import Users from '../admin/pages/Users/Users.jsx';
import User from "../admin/pages/User/User.jsx"
import AdminProducts from "../admin/pages/AdminProducts/AdminProducts.jsx";
import AdminProduct from "../admin/pages/AdminProduct/AdminProduct.jsx"
import Orders from "../admin/pages/Orders/Orders.jsx"
import Discounts from "../admin/pages/Discounts/Discounts.jsx"
import ProductPage from "../user/pages/ProductPage/ProductPage.jsx"
import ProductDetailPage from "../user/pages/ProductDetailPage/ProductDetailPage.jsx"
import PaymentPage from "../user/pages/PaymentPage/PaymentPage.jsx"
import ProfilePage from "../user/pages/ProfilePage/ProfilePage.jsx"
import ProfileUser from "../user/components/ProfileUser/ProfileUser.jsx"
import ProfileFavorite from "../user/components/ProfileFavorite/ProfileFavorite.jsx"
import ProfileOrdered from "../user/components/ProfileOrdered/ProfileOrdered.jsx"
import ProfileChangePassword from "../user/components/ProfileChangePassword/ProfileChangePassword.jsx";
import AdminLogin from "../admin/pages/AdminLogin/AdminLogin.jsx"
import No_404 from "../user/components/No_404/No_404.jsx";

export const publicRoutes = [
    { path: "/", element: UserHome },
    { path: "product", element: ProductPage },
    { path: "product/:id", element: ProductDetailPage },
    { path: "admin/login", element: AdminLogin },
    {path: "/*", element: No_404}
]

export const privateRoutes = [
    {
        path: "profile", // Trang hồ sơ người dùng
        element: ProfilePage,
        children: [
          {
            path: "", // Mặc định là thông tin cá nhân
            element: ProfileUser
          },
          {
            path: "favour", // Danh sách yêu thích
            element: ProfileFavorite
          },
          {
            path: "ordered", // Lịch sử đơn hàng
            element: ProfileOrdered
          },
          {
            path: "change-password",
            element: ProfileChangePassword
          },
        ]
    },
    { path: "payment", element: PaymentPage, }, // Trang thanh toán
]

// Các route cho admin
export const adminRoutes = [
    { path: "/admin", element: AdminHome }, // Trang chủ admin
    { path: "/admin/users", element: Users }, // Quản lý người dùng
    { path: "/admin/users/:id", element: User }, // Chi tiết người dùng theo id
    { path: "/admin/products", element: AdminProducts }, // Quản lý sản phẩm
    { path: "/admin/products/:id", element: AdminProduct }, // Chi tiết sản phẩm theo id
    { path: "/admin/orders", element: Orders }, // Quản lý đơn hàng
    { path: "/admin/discounts", element: Discounts }, // Quản lý giảm giá
]
