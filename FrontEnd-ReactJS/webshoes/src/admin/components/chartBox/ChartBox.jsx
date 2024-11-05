import React from 'react'
import './ChartBox.scss'
import { ResponsiveContainer, LineChart, Line } from 'recharts'
import { Link } from 'react-router-dom'
import { Tooltip } from 'recharts'

const ChartBox = (props) => {
  const convertToVND = (amount) => {
    return `${new Intl.NumberFormat('vi-VN').format(amount)} VNĐ`;
  };
  const CustomTooltip = ({ active, payload, label }) => {
    
    if (active && payload && payload.length){
      var myvalue = payload[0].value;
      if(props.label == "Revenue"){
        myvalue = convertToVND(myvalue);
      }
      return (
        <div className="custom-tooltip">
          <p className="label" style={{color: props.color}}>{`${props.label} : ${myvalue}`}</p>
        </div>
      );
    }
    return null;
  };
  return (
    <div className="chartBox">
      <div className="boxInfo">
        <div className="title">
          <img src={props.icon} alt="" />
          <span>{props.title}</span>
        </div>
        {props.isVND ? <h1 style={{ fontSize: '25px' }}>{props.number}</h1> : <h1>{props.number}</h1>}
        <Link to="/" style={{ color: props.color }}>
          View all
        </Link>
      </div>
      <div className="chartInfo">
        <div className="chart">
          <ResponsiveContainer width="100%" height="100%">
            <LineChart data={props.chartData}>
              <Tooltip
                content={<CustomTooltip />}
                contentStyle={{ background: "transparent", border: "none" }}
                labelStyle={{ display: "none" }}
                position={{ x: 10, y: 100 }}
              />
              <Line
                type="monotone"
                dataKey={props.dataKey}
                stroke={props.color}
                strokeWidth={2}
                dot={false}
              />
            </LineChart>
          </ResponsiveContainer>
        </div>
        <div className="texts">
          <span
            className="percentage"
            style={{ color: props.percentage < 0 ? "tomato" : "limegreen" }}
          >
            {props.percentage}%
          </span>
          <span className="duration">this month</span>
        </div>
      </div>
    </div>
  );
};

export default ChartBox