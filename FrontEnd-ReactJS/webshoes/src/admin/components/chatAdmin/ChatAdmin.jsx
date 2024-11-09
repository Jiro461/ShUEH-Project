import './ChatAdmin.scss';
import { useState, useEffect, useRef } from 'react';
import { HubConnectionBuilder, LogLevel } from '@microsoft/signalr';
import axios from 'axios';

const ChatAdmin = (props) => {
    var myvalue = process.env.REACT_APP_API_URL;
    const [message, setMessage] = useState('');
    const [messages, setMessages] = useState([]);
    const [connection, setConnection] = useState(null);
    const [user, setUser] = useState(null);
    const latestMessages = useRef(null);
    const [page, setPage] = useState(1);
    const [pageSize, setPageSize] = useState(10);
    latestMessages.current = messages;
    // {
    //     "userId": "AdminGroup",
    //     "messages": [
    //       {
    //         "message": "chào bạn",
    //         "from": "machgiahuy",
    //         "time": "2024-11-09T12:16:59Z"
    //       },
    //       {
    //         "message": "hellooooo\n",
    //         "from": "machgiahuy",
    //         "time": "2024-11-09T12:16:59Z"
    //       },
    //       {
    //         "message": "chào em, anh là",
    //         "from": "machgiahuy",
    //         "time": "2024-11-09T15:24:45Z"
    //       }
    //     ]
    //   }
    useEffect(() => {
        // Load chat history
        const loadChatHistory = async () => {
            try {
                const response = await axios.get(`${myvalue}/api/chat/history/${props.userId}/${page}/${pageSize}`);
                setMessages(response.data.messages);
            } catch (err) {
                console.log(err);
            }
        }
        console.log(props.userId);
        // Create SignalR connection
        const connect = new HubConnectionBuilder()
            .withUrl(`${myvalue}/chathub`)
            .configureLogging(LogLevel.Information)
            .build();

        setConnection(connect);

        // Start connection
        connect.start()
            .then(() => {
                console.log('Connected to SignalR Hub');
                
                // Load chat history after connection
                loadChatHistory();
            })
            .catch(err => console.log('Error connecting to hub:', err));

        // Handle receiving messages
        connect.on("ReceiveMessage", (fromUser, message) => {
            const updatedMessages = [...latestMessages.current, { from: fromUser, message: message }];
            setMessages(updatedMessages);
        });

        // Cleanup on unmount
        return () => {
            if (connection) {
                connection.stop();
            }
        };
    }, []);

    const handleCloseChat = () => {
        props.setIsOpen(false);
    }

    const handleSendMessage = async () => {
        if (message.trim() !== '' && connection) {
            try {
                // Gửi message qua SignalR
                await connection.invoke("SendMessageToUser", props.userId, message); // Chỉ cần userId và message
                console.log("Da gui message");
                const updatedMessages = [...latestMessages.current];
                updatedMessages.push({ 
                    fromUserName: "Admin",
                    message: message,
                    from: "Admin"
                });
                setMessages(updatedMessages);
                setMessage(''); // Xóa message sau khi gửi
            } catch (err) {
                console.log(err);
            }
        }
    };

    return (
        <div className='chat-admin-container'>
            <div className='chat-admin-header'>
                <div className='chat-admin-header-left'>
                    <img src="user.svg" alt="" />
                </div>
                <div className='chat-admin-header-center'>
                    <h1>{props.userName || "User Name"}</h1>
                </div>
                <div className='chat-admin-header-right'>
                    <button onClick={handleCloseChat}>X</button>
                </div>
            </div>
            <div className='chat-admin-body'>
                <div className='chat-admin-message-container'>
                    {messages.map((msg, index) => (
                        <div key={index} 
                             className={`chat-admin-message-content ${msg.from !== 'Admin' ? 'sender' : 'receiver'}`}>
                            <img src={msg.fromUserImage || '/user.svg'} alt="" />
                            <p>{msg.message}</p>
                        </div>
                    ))}
                </div>
            </div>
            <div className='chat-admin-footer'>
                <textarea 
                    value={message}
                    onChange={(e) => setMessage(e.target.value)}
                    placeholder='Type your message here...'
                    onKeyDown={(e) => {
                        if(e.key === 'Enter' && !e.shiftKey) {
                            e.preventDefault();
                            handleSendMessage();
                        }
                    }}
                />
                <button onClick={handleSendMessage}>
                    <img src='/send.svg' alt="" />
                </button>
            </div>
        </div>
    );
}

export default ChatAdmin;