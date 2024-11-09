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

export const publicRoutes = [
    { path: "/", element: UserHome },
    { path: "product", element: ProductPage },
    { path: "product/:id", element: ProductDetailPage },
]

export const privateRoutes = [
    {
        path: "profile",
        element: ProfilePage,
        children: [
          {
            path: "",
            element: ProfileUser
          },
          {
            path: "favour",
            element: ProfileFavorite
          },
          {
            path: "ordered",
            element: ProfileOrdered
          },
        ]
    },
    { path: "payment", element: PaymentPage, },
    
]

export const adminRoutes = [
    { path: "/admin", element: AdminHome },
    { path: "/admin/users", element: Users },
    { path: "/admin/users/:id", element: User },
    { path: "/admin/products", element: AdminProducts },
    { path: "/admin/products/:id", element: AdminProduct },
    { path: "/admin/orders", element: Orders },
    { path: "/admin/discounts", element: Discounts },
]