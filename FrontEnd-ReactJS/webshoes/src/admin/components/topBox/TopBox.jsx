import React from 'react';
import './TopBox.scss';

const Topbox = (props) => {
    const VND = new Intl.NumberFormat('vi-VN', {
        style: 'currency',
        currency: 'VND',
    });
    return (
        <div className='topBox'>
            <h1>{props.title}</h1>
            <div className='list'>
                {props.data.map(user => (
                    <div className='listItem' key={user.userId}>
                        <div className='user'>
                            <img src={user.avatar} alt='' />
                            <div className='userTexts'>
                                <span className='username'>{user.userName}</span>
                                <span className='email'>{user.email}</span>
                            </div>
                        </div>
                        <span className="amount">
                            {VND.format(user.totalRevenue)}
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
