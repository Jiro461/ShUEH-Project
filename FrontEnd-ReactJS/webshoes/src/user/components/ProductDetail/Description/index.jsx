import React, { useState } from 'react';

const Description = () => {
  const [content, setContent] = useState('about');

  const changeContent = (tab, event) => {
    event.preventDefault();
    setContent(tab);

    // Update active tab
    const navLinks = document.querySelectorAll('.nav-link');
    navLinks.forEach(link => link.classList.remove('active'));
    event.currentTarget.classList.add('active');
  };

  const renderContent = () => {
    switch (content) {
      case 'about':
        return "We deliver immersive virtual reality experiences that encourage learning, creativity, and play...";
      case 'size':
        return "Here is the size table for our products.";
      case 'shipping':
        return "We offer free shipping on orders over $50.";
      case 'reviews':
        return "Read customer reviews and feedback here.";
      default:
        return '';
    }
  };

  return (
    <div className="row description">
      <h1>Description</h1>
      {/* Description Tabs */}
      <div className="col-lg-5 nav-tabs">
        <ul id="nav">
          <li className="nav-item">
            <a className="nav-link active" href="#nav" onClick={(e) => changeContent('about', e)}>About model</a>
          </li>
          <li className="nav-item">
            <a className="nav-link" href="#nav" onClick={(e) => changeContent('size', e)}>Size table</a>
          </li>
          <li className="nav-item">
            <a className="nav-link" href="#nav" onClick={(e) => changeContent('shipping', e)}>Free shipping</a>
          </li>
          <li className="nav-item">
            <a className="nav-link" href="#nav" onClick={(e) => changeContent('reviews', e)}>Reviews (12)</a>
          </li>
        </ul>

        <div className="content" id="contentArea">
          <h2>QUALITY ASSURANCE</h2>
          <p id="contentText">{renderContent()}</p>
        </div>
      </div>

      {/* Product Characteristics */}
      <div className="col-lg-3 characterist">
        <h3>Characteristics</h3>
        <h4><span>Brand</span> Nike</h4>
        <h4><span>Upper Material</span> Textile, Artificial Material</h4>
        <h4><span>Color</span> White</h4>
        <h4><span>Season</span> Summer, Spring</h4>
        <h4><span>Code</span> A2731</h4>
      </div>
    </div>
  );
};

export default Description;
