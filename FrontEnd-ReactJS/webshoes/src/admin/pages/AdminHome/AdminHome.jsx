import React, { useEffect } from 'react';
import Topbox from '../../components/topBox/TopBox';
import CircularProgress from '@mui/material/CircularProgress';
import './AdminHome.scss';
import { useState } from 'react';
import axios from 'axios';
import ChartBox from './../../components/chartBox/ChartBox';
import { chartBoxUser, chartBoxProduct, chartBoxConversion, chartBoxRevenue, barChartBoxVisit, barChartBoxRevenue } from '../../data';
import PieChartBox from '../../components/pieChartBox/PieChartBox';
import BarChartBox from '../../components/barChartBox/BarChartBox';
import ScrollView from './../../components/scrollView/ScrollView';
const AdminHome = () => {
    const host = "http://shueh.somee.com";
    const axiosInstance = axios.create({
        baseURL: host,  // Đặt URL của server API
        headers: {
          'Content-Type': 'application/json',
          'Access-Control-Allow-Origin': host,  // Đặt CORS
        }
      });
    const [users, setUsers] = useState({});
    const [orders, setOrders] = useState({});
    const [revenue, setRevenue] = useState({});
    const [topDeals, setTopDeals] = useState([]);
    const [brands, setBrands] = useState([]);
    const [devicesView, setDevicesView] = useState([]);
    const [recentOrder, setRecentOrder] = useState([]);
    const [mostSoldShoes, setMostSoldShoes] = useState([]);
    const [visits, setVisits] = useState([]);
    const [loadingUsers, setLoadingUsers] = useState(true);
    const [loadingOrders, setLoadingOrders] = useState(true);
    const [loadingRevenue, setLoadingRevenue] = useState(true);
    const [loadingTopDeals, setLoadingTopDeals] = useState(true);
    const [loadingBrands, setLoadingBrands] = useState(true);
    const [loadingDevicesView, setLoadingDevicesView] = useState(true);
    const [loadingRecentOrder, setLoadingRecentOrder] = useState(true);
    const [loadingMostSoldShoes, setLoadingMostSoldShoes] = useState(true);
    const [loadingVisits, setLoadingVisits] = useState(true);
    const color = [
        "#0088FE",
        "#00C49F",
        "#FFBB28",
        "#FF8042"
    ]
    useEffect(() => {
        axiosInstance.get(`${host}/api/Statistic/users/monthly`).then(res => {
        setUsers(res.data);
        setLoadingUsers(false);
    });
    axiosInstance.get(`${host}/api/Statistic/orders/monthly`).then(res => {
        setOrders(res.data);
        setLoadingOrders(false);
    });
    axiosInstance.get(`${host}/api/Statistic/revenue/monthly`).then(res => {
        setRevenue(res.data);
        setLoadingRevenue(false);
    });
    axiosInstance.get(`${host}/api/Statistic/users/top-deals`).then(res => {
        setTopDeals(res.data);
        setLoadingTopDeals(false);
    });
    axiosInstance.get(`${host}/api/Statistic/shoes/sold-quantity-by-brand-monthly`).then(res => {
        setBrands(res.data);
        setLoadingBrands(false);
        res.data ? res.data.forEach((brand, index) => {
            brand.color = color[index];
        }) : setBrands([]);
    });
    axiosInstance.get(`${host}/api/Statistic/site-views/device-monthly`).then(res => {
        setDevicesView(res.data);
        setLoadingDevicesView(false);
        res.data ? res.data.forEach((device, index) => {
            device.color = color[index];
        }) : setDevicesView([]);
    });
    axiosInstance.get(`${host}/api/Statistic/orders/recent-delivered`).then(res => {
        setRecentOrder(res.data);
        setLoadingRecentOrder(false);
    });
    axiosInstance.get(`${host}/api/Statistic/shoes/most-sold-monthly`).then(res => {
        res.data = res.data.sort((a, b) => b.month - a.month);
        setMostSoldShoes(res.data);
        setLoadingMostSoldShoes(false);
    });
    axiosInstance.get(`${host}/api/Statistic/site-views/monthly`).then(res => {
        setVisits(res.data);
        setLoadingVisits(false);
    });
    }, []);

    const countPercentage = (object, key1, key2) => {
        return ((object?.[key1]?.[object[key1].length - 1]?.[key2] - object?.[key1]?.[object[key1].length - 2]?.[key2]) / object?.[key1]?.[object[key1].length - 2]?.[key2] * 100).toFixed(2);
    }
    const convertToVND = (amount) => {
        return `${new Intl.NumberFormat('vi-VN').format(amount)} VNĐ`;
    };
    return (
        <>
        {loadingTopDeals || loadingUsers || loadingOrders || loadingRevenue || loadingBrands 
        || loadingDevicesView || loadingRecentOrder || loadingMostSoldShoes || loadingVisits ? 
        <div style={{display: 'flex', justifyContent: 'center', alignItems: 'center', height: '100vh', paddingBottom: '200px'}}>
        <CircularProgress style={{height: '300px', width: '300px'}} /> 
        </div> 
        :
        <>
        <div className='home'>
        <div className='box box1'>
            <Topbox data={topDeals.slice(0, 9)} title="Top Deals" />
        </div>
        <div className='box box2'><ChartBox label="User" percentage={countPercentage(users, "usersByMonth", "totalUsers")} icon={chartBoxUser.icon} chartData={users.usersByMonth} dataKey="totalUsers" color="#8884d8" title="Users by month" number={users.totalUsers} /></div>
        <div className='box box3'><ChartBox label="Order" percentage={countPercentage(orders, "ordersByMonth", "totalOrders")} icon={chartBoxProduct.icon} chartData={orders.ordersByMonth} dataKey="totalOrders" color="#8884d8" title="Orders by month" number={orders.totalOrders} /></div>
        <div className='box box4'><PieChartBox data={devicesView} myValueKey="device" myDataKey="viewCount" title="Devices view this month" /></div>
        {/*Show most shoes sold by month*/}
        <div className='box box5'><ScrollView data={recentOrder} imgKey="avatarUrl" nameKey="profileName" dateKey="orderDate" amountKey="totalPrice" idKey="id" title="Recent Transactions" /></div>
        <div className='box box6'><ChartBox label="Revenue" percentage={countPercentage(revenue, "revenueFromOrdersByMonth", "totalRevenue")} icon={chartBoxRevenue.icon} chartData={revenue.revenueFromOrdersByMonth} dataKey="totalRevenue" color="#8884d8" title="Revenue by month" number={convertToVND(revenue.totalRevenue)} isVND={true} /></div>
        <div className='box box7'><PieChartBox data={brands} myValueKey="brand" myDataKey="totalSold" title="Brands sold this month" /></div>
        <div className='box box8'><ScrollView data={mostSoldShoes} imgKey="shoeImageUrl" nameKey="shoeName" dateKey="totalSold" amountKey="month" idKey="shoeId" title="Most Sold Shoes by month" isMonth={true} /></div>
        <div className='box box9'><BarChartBox chartData={visits} mykey="month" dataKey="viewCount" color="#8884d8" title="Visits by month" /></div>
            </div>
        </>
        }
        </>
    );       
}
export default AdminHome;