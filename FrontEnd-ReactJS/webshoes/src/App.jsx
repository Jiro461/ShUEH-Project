import React, { useState, useEffect } from 'react';
import { createBrowserRouter, RouterProvider, Route, Link, } from "react-router-dom"
import AdminClient from './admin/AdminClient.jsx'
import UserClient from './user/UserClient.jsx';
import AdminLayout from './layouts/admin/AdminLayout.jsx';
import './App.scss'

function App() {


  
  const router = createBrowserRouter([
    {
      path: "/",
      children: [
        {
          path: "",
          element: <UserClient />,
        },
      ],
    },
    {
      path: "/admin",
      element: <AdminLayout/>,
      children: [
        {
          path: "",
          element: <AdminClient />,
        },
      ],
    },
  ]);

  return (
      <RouterProvider router={router}/>
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