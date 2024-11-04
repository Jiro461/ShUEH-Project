import React from 'react';
import Topbox from '../../components/topBox/TopBox';
import './AdminHome.scss';
import { useState } from 'react';
import axios from 'axios';
import ChartBox from './../../components/chartBox/ChartBox';
import { chartBoxUser, chartBoxProduct, chartBoxConversion, chartBoxRevenue, barChartBoxVisit, barChartBoxRevenue } from '../../data';
import PieChartBox from '../../components/pieChartBox/PieChartBox';
import BarChartBox from '../../components/barChartBox/BarChartBox';
import ScrollView from './../../components/scrollView/ScrollView';
const AdminHome = () => {
    const [users, setUsers] = useState({});
    const [orders, setOrders] = useState({});
    const [revenue, setRevenue] = useState({});
    const [topDeals, setTopDeals] = useState([]);
    const color = [
        "#0088FE",
        "#00C49F",
        "#FFBB28",
        "#FF8042"
    ]
    axios.get('http://localhost:5118/api/Statistic/users/monthly').then(res => {
        console.log(res.data);
        setUsers(res.data);
    });
    axios.get('http://localhost:5118/api/Statistic/orders/monthly').then(res => {
        console.log(res.data);
        setOrders(res.data);
    });
    axios.get('http://localhost:5118/api/Statistic/revenue/monthly').then(res => {
        console.log(res.data);
        setRevenue(res.data);
    });
    axios.get('http://localhost:5118/api/Statistic/users/top-deals').then(res => {
        console.log(res.data);
        setTopDeals(res.data);
    });
    const DevicesView = [
        { name: "Mobile", value: 400 },
        { name: "Desktop", value: 300 },
        { name: "Laptop", value: 300 },
        { name: "Tablet", value: 200 },
    ];
    DevicesView.forEach((device, index) => {
        device.color = color[index];
    });
    const brands = [
        { name: "Nike", value: 400 },
        { name: "Adidas", value: 100 },
        { name: "Converse", value: 300 },
        { name: "Vans", value: 200 },
    ];

    brands?.forEach((brand, index) => {
        brand.color = color[index];
    });
    const transactions = [
        { user: 'johndoe', date: '2021-09-01', amount: '11', img: 'https://images.pexels.com/photos/1103970/pexels-photo-1103970.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=2' },
        { user: 'jackdower', date: '2022-04-01', amount: '10', img: 'https://images.pexels.com/photos/1103970/pexels-photo-1103970.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=2' },
        { user: 'aberdohnny', date: '2021-09-01', amount: '9', img: 'https://images.pexels.com/photos/1103970/pexels-photo-1103970.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=2' },
        { user: 'aberdohnny', date: '2021-09-01', amount: '8', img: 'https://images.pexels.com/photos/1103970/pexels-photo-1103970.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=2' },
        { user: 'aberdohnny', date: '2021-09-01', amount: '7', img: 'https://images.pexels.com/photos/1103970/pexels-photo-1103970.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=2' }
    ];

    const visits = [
        { month: '6', viewCount: '400' },
        { month: '7', viewCount: '100' },
        { month: '8', viewCount: '200' },
        { month: '9', viewCount: '300' },
        { month: '10', viewCount: '400' },
        { month: '11', viewCount: '500' }
    ];

    const users_test = {
        usersByMonth: [
            { month: '6', totalUsers: '400' },
            { month: '7', totalUsers: '300' },
            { month: '8', totalUsers: '200' },
            { month: '9', totalUsers: '300' },
            { month: '10', totalUsers: '400' },
            { month: '11', totalUsers: '500' }
        ],
        totalUsers: 1000
    };
    const orders_test = {
        ordersByMonth: [
            { month: '6', totalOrders: '400' },
            { month: '7', totalOrders: '300' },
            { month: '8', totalOrders: '200' },
            { month: '9', totalOrders: '300' },
            { month: '10', totalOrders: '400' },
            { month: '11', totalOrders: '500' }
        ],
        totalOrders: 1000
    }
    const revenue_test = {
        revenueFromOrdersByMonth: [
            { month: '6', totalRevenue: '400000' },
            { month: '7', totalRevenue: '200000' },
            { month: '8', totalRevenue: '800000' },
            { month: '9', totalRevenue: '200000' },
            { month: '10', totalRevenue: '300000' },
            { month: '11', totalRevenue: '500000' }
        ],
        totalRevenue: 2100000
    }
    const countPercentage = (object, key1, key2) => {
        return ((object?.[key1]?.[object[key1].length - 1]?.[key2] - object?.[key1]?.[object[key1].length - 2]?.[key2]) / object?.[key1]?.[object[key1].length - 2]?.[key2] * 100).toFixed(2);
    }
    const convertToVND = (amount) => {
        return `${new Intl.NumberFormat('vi-VN').format(amount)} VNĐ`;
    };
    return (
        <div className='home'>
            <div className='box box1'>
                <Topbox data={topDeals.slice(0, 9)} title="Top Deals" />
            </div>
            <div className='box box2'><ChartBox label="User" percentage={countPercentage(users, "usersByMonth", "totalUsers")} icon={chartBoxUser.icon} chartData={users.usersByMonth} dataKey="totalUsers" color="#8884d8" title="Users by month" number={users.totalUsers} /></div>
            <div className='box box3'><ChartBox label="Order" percentage={countPercentage(orders, "ordersByMonth", "totalOrders")} icon={chartBoxProduct.icon} chartData={orders.ordersByMonth} dataKey="totalOrders" color="#8884d8" title="Orders by month" number={orders.totalOrders} /></div>
            <div className='box box4'><PieChartBox data={DevicesView} title="Devices view this month" /></div>
            {/*Show most shoes sold by month*/}
            <div className='box box5'><ScrollView data={transactions} title="Recent Transactions" /></div>
            <div className='box box6'><ChartBox label="Revenue" percentage={countPercentage(revenue, "revenueFromOrdersByMonth", "totalRevenue")} icon={chartBoxRevenue.icon} chartData={revenue.revenueFromOrdersByMonth} dataKey="totalRevenue" color="#8884d8" title="Revenue by month" number={convertToVND(revenue.totalRevenue)} isVND={true} /></div>
            <div className='box box7'><PieChartBox data={brands} title="Brands sold this month" /></div>
            <div className='box box8'><ScrollView data={transactions} title="Most Sold Shoes by month" isMonth={true} /></div>
            <div className='box box9'><BarChartBox chartData={visits} dataKey="viewCount" color="#8884d8" title="Visits by month" /></div>
        </div>
    );
};

export default AdminHome;