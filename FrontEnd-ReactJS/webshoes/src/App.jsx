import React, { useState, useEffect } from 'react';
import { API_BASE_URL } from './constants/apiUrls.jsx'
import { Route, Routes, BrowserRouter } from "react-router-dom"
import AdminClient from './admin/AdminClient.jsx'
import UserClient from './user/UserClient.jsx';
import Profile from './user/components/Profile/Content/UserProfile/index.jsx';
import Product from './user/pages/Product/index.jsx';
import Favorite from './user/components/Profile/Content/Favorite/index.jsx';
import Ordered from './user/components/Profile/Content/Ordered/index.jsx';
import Setting from './user/components/Profile/Content/Setting/index.jsx';
import ProfilePage from './user/pages/ProfilePage/index.jsx';
import './App.css';
import PaymentPage from './user/pages/PaymentPage/index.jsx';
import ProductDetail from './user/pages/ProductDetail/index.jsx';

function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path='/' element={<UserClient />}>
          <Route path='product' element={<Product />}>
          </Route>
          <Route path='product/detail-product' element={<ProductDetail />}/>
          <Route path='profile' element={<ProfilePage />}>
            <Route path='' element={<Profile />}/>
            <Route path='setting' element={<Setting />}/>
            <Route path='favorite' element={<Favorite />}/>
            <Route path='ordered' element={<Ordered />}/>
          </Route>
          <Route path='payment' element={<PaymentPage />}/>
        </Route>
      </Routes>
    </BrowserRouter>
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