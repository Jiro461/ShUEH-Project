import React from "react";

function PaginationControls({ totalPages, currentPage, setCurrentPage }) {
    return (
        <div className="pagination-controls">
            {Array.from({ length: totalPages }, (_, index) => (
                <button
                    key={index}
                    onClick={() => setCurrentPage(index + 1)}
                    className={currentPage === index + 1 ? 'active' : ''}
                >
                    {index + 1}
                </button>
            ))}
        </div>
    );
}

export default PaginationControls;