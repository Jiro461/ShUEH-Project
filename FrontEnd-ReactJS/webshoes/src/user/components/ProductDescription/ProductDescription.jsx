import React, { useState } from 'react';
import { CSSTransition, TransitionGroup } from 'react-transition-group';
import Review from '../Review/Review';
import data from "./data.json";

const ProductDescription = ({ product, error, loading }) => {
  const cmt = data;
  const [content, setContent] = useState('about');
  const [currentCommentIndex, setCurrentCommentIndex] = useState(0);

  const changeContent = (tab, event) => {
    event.preventDefault();
    setContent(tab);

    const navLinks = document.querySelectorAll('.nav-link');
    navLinks.forEach(link => link.classList.remove('active'));
    event.currentTarget.classList.add('active');
  };

  const goToNextComment = () => {
    if (currentCommentIndex < cmt.length - 1) {
      setCurrentCommentIndex(currentCommentIndex + 1);
    }
  };

  const goToPreviousComment = () => {
    if (currentCommentIndex > 0) {
      setCurrentCommentIndex(currentCommentIndex - 1);
    }
  };

  const renderContent = () => {
    switch (content) {
      case 'about':
        return <>{product.description}</>;
      case 'size':
        return "Here is the size table for our products.";
      case 'reviews':
        return (
          <div className="review-container">
            <div className="navigation-buttons">
              <button onClick={goToPreviousComment} disabled={currentCommentIndex === 0}>
                &lt; Previous
              </button>
              <button onClick={goToNextComment} disabled={currentCommentIndex === cmt.length - 1}>
                Next &gt;
              </button>
            </div>
            <TransitionGroup>
              <CSSTransition
                key={currentCommentIndex}
                timeout={300}
                classNames="slide"
              >
                <Review cmt={cmt[currentCommentIndex]} />
              </CSSTransition>
            </TransitionGroup>
          </div>
        );
      default:
        return '';
    }
  };

  if (loading) {
    return <div>Loading...</div>;
  }

  if (error) {
    return <div>Error: {error}</div>;
  }

  const shoe_color = product.colors.map((colo, index) => (
    <span key={index}>{colo.color}{index < product.colors.length - 1 ? ", " : ""}</span>
  ));

  const shoe_season = product.seasons.map((seas, index) => (
    <span key={index}>{seas.season}{index < product.seasons.length - 1 ? ", " : ""}</span>
  ));

  return (
    <>
      <h1>Description</h1>
      
      <div className="col-lg-5 nav-tabs">
        <ul id="nav">
          <li className="nav-item">
            <a className={`nav-link ${content === 'about' ? 'active' : ''}`} href="#nav" onClick={(e) => changeContent('about', e)}>About model</a>
          </li>
          <li className="nav-item">
            <a className={`nav-link ${content === 'size' ? 'active' : ''}`} href="#nav" onClick={(e) => changeContent('size', e)}>Size table</a>
          </li>
          <li className="nav-item">
            <a className={`nav-link ${content === 'reviews' ? 'active' : ''}`} href="#nav" onClick={(e) => changeContent('reviews', e)}>Reviews ({cmt.length})</a>
          </li>
        </ul>

        <div className="content" id="contentArea">
          <div id="contentText">{renderContent()}</div>
        </div>
      </div>

      <div className="col-lg-3 characterist">
        <h3>Characteristics</h3>
        <h4><span>Brand</span> {product.brand}</h4>
        <h4><span>Upper Material</span> {product.material}</h4>
        <h4><span>Color</span> {shoe_color}</h4>
        <h4><span>Season</span> {shoe_season}</h4>
      </div>
    </>
  );
};

export default ProductDescription;
