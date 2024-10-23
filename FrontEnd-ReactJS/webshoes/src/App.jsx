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
import './App.scss';

// Định nghĩa component SignInComponent
const SignInComponent = () => {
  const [shoeData, setShoeData] = useState({
    name: '',
    brand: '',
    gender: 0,
    material: '',
    category: '',
    imageUrl: '',
    description: '',
    price: 0,
    stock: 0,
    isSale: false,
    discount: 0,
    colors: [],
    seasons: [],
    sizes: [],
    additionalImages: [],
    mainImage: null, // State for the main image
  });

  const [errors, setErrors] = useState({});

  const handleChange = (e) => {
    const { name, value, type, checked, files } = e.target;

    if (type === 'checkbox') {
      setShoeData({
        ...shoeData,
        [name]: checked,
      });
    } else if (type === 'file') {
      if (name === 'mainImage') {
        // Handle main image upload
        setShoeData({
          ...shoeData,
          mainImage: files[0], // Only the first file for main image
        });
      } else {
        // Handle additional images upload
        setShoeData({
          ...shoeData,
          [name]: files ? Array.from(files) : []
        });
      }
    } else {
      setShoeData({
        ...shoeData,
        [name]: value,
      });
    }
  };

  const handleColorsChange = (color) => {
    setShoeData((prev) => ({
      ...prev,
      colors: [...prev.colors, { Color: color }],
    }));
  };

  const handleSizesChange = (size) => {
    setShoeData((prev) => ({
      ...prev,
      sizes: [...prev.sizes, { Size: size }],
    }));
  };

  const handleSeasonsChange = (season) => {
    setShoeData((prev) => ({
      ...prev,
      seasons: [...prev.seasons, { Season: season }],
    }));
  };

  const handleRemoveColor = (index) => {
    setShoeData((prev) => ({
      ...prev,
      colors: prev.colors.filter((_, i) => i !== index),
    }));
  };

  const handleRemoveSize = (index) => {
    setShoeData((prev) => ({
      ...prev,
      sizes: prev.sizes.filter((_, i) => i !== index),
    }));
  };

  const handleRemoveSeason = (index) => {
    setShoeData((prev) => ({
      ...prev,
      seasons: prev.seasons.filter((_, i) => i !== index),
    }));
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    const validationErrors = validate(shoeData);
    if (Object.keys(validationErrors).length > 0) {
      setErrors(validationErrors);
      return;
    }

    // Create FormData object
    const formData = new FormData();
    formData.append('Name', shoeData.name);
    formData.append('Brand', shoeData.brand);
    formData.append('Gender', shoeData.gender);
    formData.append('Material', shoeData.material);
    formData.append('Category', shoeData.category);
    formData.append('ImageUrl', shoeData.imageUrl);
    formData.append('Description', shoeData.description);
    formData.append('Price', shoeData.price);
    formData.append('Stock', shoeData.stock);
    formData.append('IsSale', shoeData.isSale);
    formData.append('Discount', shoeData.discount);
    
    // Append main image to the form data
    if (shoeData.mainImage) {
      formData.append('MainImage', shoeData.mainImage);
    }

    // Append colors, seasons, sizes
    shoeData.colors.forEach(color => formData.append('Colors', JSON.stringify(color)));
    shoeData.seasons.forEach(season => formData.append('Seasons', JSON.stringify(season)));
    shoeData.sizes.forEach(size => formData.append('Sizes', JSON.stringify(size)));

    // Append additional images
    shoeData.additionalImages.forEach(image => {
      formData.append('AdditionalImages', image);
    });

    // Make the API call
    try {
      const response = await fetch('http://localhost:5118/api/shoe/create', {
        method: 'POST',
        body: formData,
      });

      if (response.ok) {
        // Handle successful response
        console.log('Shoe created successfully');
        // Reset form or redirect as necessary
      } else {
        // Handle error response
        const errorData = await response.json();
        console.error('Error creating shoe:', errorData);
      }
    } catch (error) {
      console.error('Error:', error);
    }
  };

  const validate = (data) => {
    const validationErrors = {};
    if (!data.name) validationErrors.name = 'Shoe name is required.';
    if (!data.brand) validationErrors.brand = 'Brand is required.';
    if (data.gender < 0 || data.gender > 2) validationErrors.gender = 'Gender must be between 0 and 2.';
    if (!data.material) validationErrors.material = 'Material is required.';
    if (!data.category) validationErrors.category = 'Category is required.';
    if (!data.description) validationErrors.description = 'Description is required.';
    if (data.price <= 0 || data.price > 10000) validationErrors.price = 'Price must be between 0 and 10000.';
    if (data.stock < 0 || data.stock > 10000) validationErrors.stock = 'Stock must be between 0 and 10000.';
    if (data.discount < 0 || data.discount > 100) validationErrors.discount = 'Discount must be between 0 and 100.';
    if (data.colors.length === 0) validationErrors.colors = 'Colors are required.';
    if (data.seasons.length === 0) validationErrors.seasons = 'Seasons are required.';
    if (data.sizes.length === 0) validationErrors.sizes = 'Sizes are required.';
    return validationErrors;
  };

  return (
    <form onSubmit={handleSubmit}>
      <h2>Create New Shoe</h2>

      <div>
        <label>Shoe Name:</label>
        <input type="text" name="name" value={shoeData.name} onChange={handleChange} />
        {errors.name && <span>{errors.name}</span>}
      </div>

      <div>
        <label>Brand:</label>
        <input type="text" name="brand" value={shoeData.brand} onChange={handleChange} />
        {errors.brand && <span>{errors.brand}</span>}
      </div>

      <div>
        <label>Gender:</label>
        <select name="gender" value={shoeData.gender} onChange={handleChange}>
          <option value={0}>Male</option>
          <option value={1}>Female</option>
          <option value={2}>Unisex</option>
        </select>
        {errors.gender && <span>{errors.gender}</span>}
      </div>

      <div>
        <label>Material:</label>
        <input type="text" name="material" value={shoeData.material} onChange={handleChange} />
        {errors.material && <span>{errors.material}</span>}
      </div>

      <div>
        <label>Category:</label>
        <input type="text" name="category" value={shoeData.category} onChange={handleChange} />
        {errors.category && <span>{errors.category}</span>}
      </div>

      <div>
        <label>Main Image:</label>
        <input type="file" name="mainImage" accept="image/*" onChange={handleChange} />
        {errors.mainImage && <span>{errors.mainImage}</span>}
      </div>

      <div>
        <label>Image URL:</label>
        <input type="text" name="imageUrl" value={shoeData.imageUrl} onChange={handleChange} />
      </div>

      <div>
        <label>Description:</label>
        <textarea name="description" value={shoeData.description} onChange={handleChange} />
        {errors.description && <span>{errors.description}</span>}
      </div>

      <div>
        <label>Price:</label>
        <input type="number" name="price" value={shoeData.price} onChange={handleChange} />
        {errors.price && <span>{errors.price}</span>}
      </div>

      <div>
        <label>Stock:</label>
        <input type="number" name="stock" value={shoeData.stock} onChange={handleChange} />
        {errors.stock && <span>{errors.stock}</span>}
      </div>

      <div>
        <label>On Sale:</label>
        <input type="checkbox" name="isSale" checked={shoeData.isSale} onChange={handleChange} />
      </div>

      <div>
        <label>Discount:</label>
        <input type="number" name="discount" value={shoeData.discount} onChange={handleChange} />
        {errors.discount && <span>{errors.discount}</span>}
      </div>

      <div>
        <label>Colors:</label>
        <input
          type="text"
          placeholder="Add color"
          onBlur={(e) => {
            const color = e.target.value;
            if (color) {
              handleColorsChange(color);
              e.target.value = ''; // Clear input after adding
            }
          }}
        />
        {errors.colors && <span>{errors.colors}</span>}
        <ul>
          {shoeData.colors.map((color, index) => (
            <li key={index}>
              {color.Color}
              <button type="button" onClick={() => handleRemoveColor(index)}>Remove</button>
            </li>
          ))}
        </ul>
      </div>

      <div>
        <label>Sizes:</label>
        <input
          type="number"
          placeholder="Add size"
          onBlur={(e) => {
            const size = parseInt(e.target.value);
            if (!isNaN(size) && size > 0) {
              handleSizesChange(size);
              e.target.value = ''; // Clear input after adding
            }
          }}
        />
        {errors.sizes && <span>{errors.sizes}</span>}
        <ul>
          {shoeData.sizes.map((size, index) => (
            <li key={index}>
              {size.Size}
              <button type="button" onClick={() => handleRemoveSize(index)}>Remove</button>
            </li>
          ))}
        </ul>
      </div>

      <div>
        <label>Seasons:</label>
        <input
          type="text"
          placeholder="Add season"
          onBlur={(e) => {
            const season = e.target.value;
            if (season) {
              handleSeasonsChange(season);
              e.target.value = ''; // Clear input after adding
            }
          }}
        />
        {errors.seasons && <span>{errors.seasons}</span>}
        <ul>
          {shoeData.seasons.map((season, index) => (
            <li key={index}>
              {season.Season}
              <button type="button" onClick={() => handleRemoveSeason(index)}>Remove</button>
            </li>
          ))}
        </ul>
      </div>

      <div>
        <label>Additional Images:</label>
        <input type="file" name="additionalImages" multiple onChange={handleChange} />
      </div>

      <button type="submit">Create Shoe</button>
    </form>
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
