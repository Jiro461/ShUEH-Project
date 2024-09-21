import React from 'react';
import './TopBox.scss';
import { top_Deals } from '../../data';

const Topbox = () => {
    const VND = new Intl.NumberFormat('vi-VN', {
        style: 'currency',
        currency: 'VND',
    });
    return (
        <div className='topBox'>
            <h1>Top Deals</h1>
            <div className='list'>
                {top_Deals.map(user => (
                    <div className='listItem' key={user.id}>
                        <div className='user'>
                            <img src={user.img} alt='' />
                            <div className='userTexts'>
                                <span className='username'>{user.username}</span>
                                <span className='email'>{user.email}</span>
                            </div>
                        </div>
                        <span className="amount">
                            {VND.format(user.amount)}
                        </span>
                    </div>
                ))}
            </div>
        </div>
    )
}

Topbox.propTypes = {

}

export default Topbox
