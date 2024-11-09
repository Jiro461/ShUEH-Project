import React from 'react';
import './AddBlock.scss'
import { useNavigate } from "react-router-dom";

const AddBlock = ({id}) => {
    const navigate = useNavigate()
    return (
        <div className="add-block" onClick={() => navigate(`/product/${id}`)}>
            <img src='/+.svg' alt='add'></img>
        </div>
    );
};

export default AddBlock;