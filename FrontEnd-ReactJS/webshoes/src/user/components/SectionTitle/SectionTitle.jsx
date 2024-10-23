import React from 'react';
import './SectionTitle.scss'

const SectionTitle = ({title, className}) => {
    return (
        <p className={`section-title ${className}`}>
            {title}  
        </p>
    );
};

export default SectionTitle;