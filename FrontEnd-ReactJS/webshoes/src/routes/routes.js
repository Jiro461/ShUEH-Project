import AdminHome from "../admin/pages/AdminHome/AdminHome.jsx"; // Trang chủ của admin
import UserHome from '../user/pages/UserHome/UserHome.jsx'; // Trang chủ của người dùng
import Users from '../admin/pages/Users/Users.jsx'; // Quản lý người dùng cho admin
import User from "../admin/pages/User/User.jsx"; // Chi tiết người dùng cho admin
import AdminProducts from "../admin/pages/AdminProducts/AdminProducts.jsx"; // Quản lý sản phẩm cho admin
import AdminProduct from "../admin/pages/AdminProduct/AdminProduct.jsx"; // Chi tiết sản phẩm cho admin
import Orders from "../admin/pages/Orders/Orders.jsx"; // Quản lý đơn hàng cho admin
import Discounts from "../admin/pages/Discounts/Discounts.jsx"; // Quản lý giảm giá cho admin
import ProductPage from "../user/pages/ProductPage/ProductPage.jsx"; // Trang sản phẩm cho người dùng
import ProductDetailPage from "../user/pages/ProductDetailPage/ProductDetailPage.jsx"; // Chi tiết sản phẩm cho người dùng
import PaymentPage from "../user/pages/PaymentPage/PaymentPage.jsx"; // Trang thanh toán cho người dùng
import ProfilePage from "../user/pages/ProfilePage/ProfilePage.jsx"; // Trang hồ sơ người dùng
import ProfileUser from "../user/components/ProfileUser/ProfileUser.jsx"; // Chi tiết thông tin cá nhân người dùng
import ProfileFavorite from "../user/components/ProfileFavorite/ProfileFavorite.jsx"; // Danh sách yêu thích của người dùng
import ProfileOrdered from "../user/components/ProfileOrdered/ProfileOrdered.jsx"; // Lịch sử đơn hàng của người dùng
import AdminLogin from "../admin/pages/AdminLogin/AdminLogin.jsx"; // Trang đăng nhập của admin

// Các route công khai cho người dùng
export const publicRoutes = [
    { path: "/", element: UserHome }, // Trang chủ cho người dùng
    { path: "product", element: ProductPage }, // Trang sản phẩm cho người dùng
    { path: "product/:id", element: ProductDetailPage }, // Chi tiết sản phẩm theo id
    { path: "admin/login", element: AdminLogin }, // Trang đăng nhập cho admin
]

// Các route riêng tư cho người dùng đã đăng nhập
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
