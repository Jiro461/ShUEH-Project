import React from 'react';
import './scrollView.scss';

const ScrollView = (props) => {

  const convertToVND = (amount) => {
    return `${new Intl.NumberFormat('vi-VN').format(amount)} VNĐ`;
  };
  return (
    <div className='scrollView'>
      <div className='title'>{props.title}</div>
      <div className='transactions'>
        {props.data.map((transaction, index) => (
          <div className='transaction' key={index}>
            <img className='transaction-img' src={transaction.img} alt='user' />
            <div className='transaction-user'>{transaction.user}</div>
            <div className='transaction-date'>{transaction.date}</div>
            {!props.isMonth ? <div className='transaction-amount'>{convertToVND(transaction.amount)}</div> : <div style={{ fontSize: '17px', width: '40px', borderRadius: '25px' }} className='transaction-amount'>{transaction.amount}</div>}
          </div>
        ))}
      </div>
    </div>
  );
};

export default ScrollView;
