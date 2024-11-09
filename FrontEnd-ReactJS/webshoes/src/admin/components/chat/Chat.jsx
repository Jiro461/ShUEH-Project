import React, { useState, useEffect } from 'react';
import * as signalR from '@microsoft/signalr';
import './Chat.scss';
import axios from 'axios';

const Chat = () => {
    // Lấy giá trị API từ biến môi trường
    const myvalue = process.env.REACT_APP_API_URL;

    // Các state dùng để quản lý chat
    const [isOpen, setIsOpen] = useState(false); // Kiểm tra xem cửa sổ chat có mở hay không
    const [messages, setMessages] = useState([]); // Lưu trữ danh sách tin nhắn
    const [newMessage, setNewMessage] = useState(''); // Lưu trữ tin nhắn mới
    const [connection, setConnection] = useState(null); // Kết nối SignalR
    const userId = localStorage.getItem('userId'); // Lấy ID người dùng từ localStorage
    const page = 1; // Trang hiện tại để tải lịch sử tin nhắn
    const pageSize = 10; // Số lượng tin nhắn mỗi trang

    // useEffect để tải lịch sử tin nhắn từ server khi component được render lần đầu
    useEffect(() => {
        // Hàm tải lịch sử tin nhắn từ API
        const loadChatHistory = async () => {
            try {
                // Gọi API lấy tin nhắn
                axios.get(`${myvalue}/api/chat/user/${page}/${pageSize}`).then(res => {
                    console.log(res.data);
                    setMessages(res.data.messages || []);  // Đảm bảo messages luôn là mảng
                });
            } catch (err) {
                console.log(err);
                setMessages([]); // Nếu có lỗi, gán tin nhắn là mảng rỗng
            }
        };
        loadChatHistory();

        // Khởi tạo kết nối SignalR với Hub
        const newConnection = new signalR.HubConnectionBuilder()
            .withUrl(`${myvalue}/chatHub`) // Địa chỉ của SignalR Hub
            .withAutomaticReconnect() // Tự động kết nối lại nếu mất kết nối
            .build();

        // Lưu kết nối vào state
        setConnection(newConnection);
    }, []); // Chạy một lần khi component được render lần đầu

    // useEffect thứ hai để bắt đầu kết nối SignalR và lắng nghe tin nhắn
    useEffect(() => {
        // Kiểm tra nếu kết nối SignalR đã được khởi tạo
        if (connection) {
            connection.start()
                .then(() => {
                    console.log('Connected to SignalR');
                    
                    // Lắng nghe sự kiện "ReceiveMessage" từ server
                    connection.on('ReceiveMessage', (user, message) => {
                        console.log(messages);
                        // Thêm tin nhắn mới vào state messages
                        setMessages((prevMessages) => [...prevMessages, { from: user, message: message }]);
                    });
                })
                .catch(error => console.error('SignalR Connection Error:', error)); // Bắt lỗi nếu không kết nối được
        }
    }, [connection]); // Chạy khi kết nối SignalR thay đổi

    // Hàm gửi tin nhắn khi người dùng bấm gửi
    const sendMessage = async () => {
        // Kiểm tra tin nhắn có hợp lệ và kết nối SignalR đã sẵn sàng
        if (newMessage.trim() && connection) {
            try {
                // Gửi tin nhắn tới admin qua SignalR
                await connection.invoke('SendMessageToAdmin', newMessage);
                // Thêm tin nhắn của người dùng vào state
                setMessages((prevMessages) => [...(prevMessages || []), { from: 'You', message: newMessage }]);
                // Reset lại ô nhập tin nhắn
                setNewMessage('');
            } catch (error) {
                console.error('Send Message Error:', error); // Bắt lỗi nếu gửi tin nhắn thất bại
            }
        }
    };

    return (
        <div className='chat' onClick={() => setIsOpen(!isOpen)}> {/* Điều khiển việc mở/đóng cửa sổ chat */}
            <img src='/chat.svg' alt="" />
            {isOpen &&
            <div className='chat-container' onClick={(e) => e.stopPropagation()}> {/* Dừng sự kiện click truyền ra ngoài */}
                <div className='chat-header'>
                    <h1>Support</h1> {/* Tiêu đề chat */}
                </div>
                <div className='chat-body'>
                    <div className='chat-message-container'>
                        {messages?.map((msg, index) => (
                            <div key={index} className={`chat-message ${msg.from === 'Admin' ? 'sender' : 'receiver'}`}>
                                <img src='/user.svg' alt="" /> {/* Hiển thị hình ảnh của người gửi */}
                                <p>{msg.message}</p> {/* Hiển thị nội dung tin nhắn */}
                            </div>
                        ))}
                    </div>
                </div>
                <div className='chat-footer'>   
                    <textarea
                        placeholder='Type your message here...' // Thông báo cho người dùng
                        value={newMessage} // Lưu giá trị của tin nhắn mới
                        onChange={(e) => setNewMessage(e.target.value)} // Cập nhật khi người dùng gõ
                    />
                    <button onClick={sendMessage}><img src='/send.svg' alt="" /></button> {/* Gửi tin nhắn khi bấm nút */}
                </div>
            </div>}
        </div>
    );
};

export default Chat;
