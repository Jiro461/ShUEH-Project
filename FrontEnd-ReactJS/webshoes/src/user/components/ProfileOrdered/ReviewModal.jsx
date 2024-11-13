import React, { useState } from 'react';
import './style.css'; // You can import the same style or modify for the modal

const ReviewModal = ({ isOpen, selectedItem, onClose, onSubmit }) => {
    const [comment, setComment] = useState('');

    const handleSubmit = () => {
        if (comment.trim() !== '') {
            onSubmit(comment); // Pass comment back to parent on submit
            setComment(''); // Clear the comment after submit
        }
    };

    if (!isOpen) return null;

    return (
        <div className="modal-overlay">
            <div className="modal">
                <h2>Write a Review for {selectedItem.shoeName}</h2>
                <textarea
                    value={comment}
                    onChange={(e) => setComment(e.target.value)}
                    placeholder="Write your comment here..."
                />
                <div className="modal-buttons">
                    <button className="btn-cancel" onClick={onClose}>Cancel</button>
                    <button className="btn-submit" onClick={handleSubmit}>Submit</button>
                </div>
            </div>
        </div>
    );
};

export default ReviewModal;
