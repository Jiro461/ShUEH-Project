import React from 'react';
import { createBrowserRouter, RouterProvider } from "react-router-dom"
import UserLayout from './layouts/user/UserLayout.jsx';
import Product from './user/pages/ProductPage/ProductPage.jsx';
import PaymentPage from './user/pages/PaymentPage/PaymentPage.jsx';
import ProductDetailPage from './user/pages/ProductDetailPage/ProductDetailPage.jsx';
import ProfilePage from './user/pages/ProfilePage/ProfilePage.jsx';
import './App.css';

function App() {
  const router = createBrowserRouter(
    [
      {
        path: "/",
        element: <UserLayout/>,
        children: [
          {
            path: 'product',
            element: <Product />
          },

          {
            path: 'payment',
            element: <PaymentPage />
          },

          {
            path: 'product/:id',
            element: <ProductDetailPage />
          },

          {
            path: 'profile',
            element: <ProfilePage />
          }
        ],
      },
    ]
  );

  return (
    <RouterProvider router={router} />
  );
  // const [forecast, setForecast] = useState([]);
  // const [loading, setLoading] = useState(true);
  // useEffect(() => {
  //   const fetchWeather = async () => {
  //     try {
  //       const response = await fetch(`${API_BASE_URL}/weatherforecast`);
  //       const data = await response.json();
  //       setForecast(data);
  //       setLoading(false);
  //     } catch (error) {
  //       console.error("Error fetching data:", error);
  //       setLoading(false);
  //     }
  //   };

  //   fetchWeather();
  // }, []);

  // if (loading) {
  //   return <div>Loading...</div>;
  // }

  // return (
  //   <div className="App">
  //     <header className="App-header">
  //       <h1>Weather Forecast</h1>
  //       <ul>
  //         {forecast.map((weather, index) => (
  //           <li key={index}>
  //             <p>Date: {weather.date}</p>
  //             <p>Temperature: {weather.temperatureC}°C ({weather.temperatureF}°F)</p>
  //             <p>Summary: {weather.summary}</p>
  //           </li>
  //         ))}
  //       </ul>
  //     </header>
  //   </div>
  // );
}

export default App;