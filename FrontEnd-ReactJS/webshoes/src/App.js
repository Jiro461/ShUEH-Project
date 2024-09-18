import React, { useState, useEffect } from 'react';
import './App.css';

function App() {
  const [forecast, setForecast] = useState([]);
  const [loading, setLoading] = useState(true);
  useEffect(() => {
    const fetchWeather = async () => {
      try {
        const response = await fetch('http://localhost:5118/api/weatherforecast'); // Chỉnh đúng URL API của bạn
        const data = await response.json();
        setForecast(data);
        setLoading(false);
      } catch (error) {
        console.error("Error fetching data:", error);
        setLoading(false);
      }
    };

    fetchWeather();
  }, []);

  if (loading) {
    return <div>Loading...</div>;
  }

  return (
    <div className="App">
      <header className="App-header">
        <h1>Weather Forecast</h1>
        <ul>
          {forecast.map((weather, index) => (
            <li key={index}>
              <p>Date: {weather.date}</p>
              <p>Temperature: {weather.temperatureC}°C ({weather.temperatureF}°F)</p>
              <p>Summary: {weather.summary}</p>
            </li>
          ))}
        </ul>
      </header>
    </div>
  );
}

export default App;