import React, { useState, useEffect } from 'react';
import * as signalR from '@microsoft/signalr';
import './Chat.scss';
import axios from 'axios';
const Chat = () => {
    const myvalue = process.env.REACT_APP_API_URL;
    const [isOpen, setIsOpen] = useState(false);
    const [messages, setMessages] = useState([]);
    const [newMessage, setNewMessage] = useState('');
    const [connection, setConnection] = useState(null);
    const userId = localStorage.getItem('userId');
    const page = 1;
    const pageSize = 10;
    const loadChatHistory = async () => {
        try {
            const response = await axios.get(`${myvalue}/api/chat/user/${page}/${pageSize}`);
            setMessages(response.data.messages);
        } catch (err) {
            console.log(err);
        }
    }
    useEffect(() => {
        // Khởi tạo kết nối SignalR
        const newConnection = new signalR.HubConnectionBuilder()
            .withUrl('http://localhost:5118/chatHub') // Địa chỉ Hub của bạn
            .withAutomaticReconnect()
            .build();

        setConnection(newConnection);
        loadChatHistory();
    }, []);

    useEffect(() => {
        if (connection) {
            connection.start()
                .then(() => {
                    console.log('Connected to SignalR');
                    
                    // Lắng nghe tin nhắn từ server
                    connection.on('ReceiveMessage', (user, message) => {
                        setMessages((prevMessages) => [...prevMessages, { user, message }]);
                    });
                })
                .catch(error => console.error('SignalR Connection Error:', error));
        }
    }, [connection]);

    const sendMessage = async () => {
        if (newMessage.trim() && connection) {
            try {
                await connection.invoke('SendMessageToAdmin', newMessage);
                setMessages([...messages, { user: 'You', message: newMessage }]);
                setNewMessage('');
            } catch (error) {
                console.error('Send Message Error:', error);
            }
        }
    };

    return (
        <div className='chat' onClick={() => setIsOpen(!isOpen)}>
            <img src='/chat.svg' alt="" />
            {isOpen &&
            <div className='chat-container' onClick={(e) => e.stopPropagation()}>
                <div className='chat-header'>
                    <h1>Support</h1>
                </div>
                <div className='chat-body'>
                    <div className='chat-message-container'>
                        {messages.map((msg, index) => (
                            <div key={index} className={`chat-message ${msg.fromUserName !== 'Admin' ? 'receiver' : 'sender'}`}>
                                <img src='/user.svg' alt="" />
                                <p>{msg.message}</p>
                            </div>
                        ))}
                    </div>
                </div>
                <div className='chat-footer'>   
                    <textarea
                        placeholder='Type your message here...'
                        value={newMessage}
                        onChange={(e) => setNewMessage(e.target.value)}
                    />
                    <button onClick={sendMessage}><img src='/send.svg' alt="" /></button>
                </div>
            </div>}
        </div>
    );
};

export default Chat;
