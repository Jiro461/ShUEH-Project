import React from 'react';
import { Link } from 'react-router-dom'
import './Menu.scss'
import { menu_data } from '../../data'
const Menu = props => {
    return (
        <div className='menu'>
            {menu_data.map(item => (
                <div className='item' key={item.id}>
                    <span className="title">{item.title}</span>
                    {item.listItems.map((listItem) => (
                        <Link to="/" className='listItem' key={listItem.id}>
                            <img src={`/${listItem.icon}`} alt='' />
                            <span className="listItemTitle">{listItem.title}</span>
                        </Link>
                    ))}
                </div>
            ))}
        </div>
    );
};

Menu.propTypes = {

};

export default Menu;