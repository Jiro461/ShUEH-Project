import React from 'react';
import './SectionTitle.scss'

const SectionTitle = ({title}) => {
    return (
        <p className="section-title">
            {title}  
        </p>
    );
};

export default SectionTitle;