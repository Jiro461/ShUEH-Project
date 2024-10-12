import React from 'react';
import './AddBlock.scss'

const AddBlock = ({className}) => {
    return (
        <div className={`add-block ${className}`}>
            <img src='/+.svg' alt='add'></img>
        </div>
    );
};

export default AddBlock;