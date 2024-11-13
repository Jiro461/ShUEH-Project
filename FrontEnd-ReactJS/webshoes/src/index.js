import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import App from './App';
import reportWebVitals from './reportWebVitals';
import { Provider } from "react-redux" // Cung cấp store cho ứng dụng bằng Redux
import store from "./redux/store"; // Import store từ Redux

const root = ReactDOM.createRoot(document.getElementById('root')); // Tạo root cho ứng dụng React
root.render(
  <Provider store={store}> {/* Provider cung cấp store Redux cho toàn bộ ứng dụng */}
    <React.StrictMode> {/* StrictMode giúp phát hiện lỗi trong phát triển */}
      <App /> {/* Ứng dụng chính */}
    </React.StrictMode>
  </Provider>
);

reportWebVitals(); // Báo cáo hiệu suất của ứng dụng
