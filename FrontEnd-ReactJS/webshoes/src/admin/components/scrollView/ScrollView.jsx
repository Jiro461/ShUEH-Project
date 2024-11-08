import React from 'react';
import './scrollView.scss';

const ScrollView = (props) => {
  const host = "http://shueh.somee.com";
  var id = props.idKey;
  var img = props.imgKey;
  var user = props.nameKey;
  var date = props.dateKey;
  var amount = props.amountKey;
  const convertToVND = (amount) => {
    return `${new Intl.NumberFormat('vi-VN').format(amount)} VNĐ`;
  };
  const convertDate = (date) => {
    return new Date(date).toLocaleDateString('vi-VN', { year: 'numeric', month: 'long', day: 'numeric' });
  };
  return (
    <div className='scrollView'>
      <div className='title'>{props.title}</div>
      <div className='transactions'>
        {props.data.map((transaction, index) => (
          <div className='transaction' key={transaction[id]}>
            <img className='transaction-img' src={`${host}/${transaction[img]}`} alt='user' />
            {props.isMonth ? 
            <>
            <div style={{display: 'flex', flexDirection: 'column', gap: '5px'}}>
            <div style={{width: '120px'}} className='transaction-user'>{transaction[user]}</div> 
            <div>{transaction["shoeBrand"]}</div>
            </div>
            </>
            : <div className='transaction-user'>{transaction[user]}</div>}
            {props.isMonth ? <div style={{paddingLeft: '35px'}} className='transaction-date'>{transaction[date]}</div> : <div className='transaction-date'>{convertDate(transaction[date])}</div>}
            {!props.isMonth ? <div className='transaction-amount'>{convertToVND(transaction[amount])}</div> : <div style={{ fontSize: '17px', width: '40px', borderRadius: '25px' }} className='transaction-amount'>{transaction[amount]}</div>}
          </div>
        ))}
      </div>
    </div>
  );
};

export default ScrollView;
