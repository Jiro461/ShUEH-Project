import './ChatAdmin.scss';
import { useState, useEffect, useRef } from 'react';
import { HubConnectionBuilder, LogLevel } from '@microsoft/signalr';
import axios from 'axios';

const ChatAdmin = (props) => {
    var myvalue = process.env.REACT_APP_API_URL; // Lấy giá trị URL API từ biến môi trường
    const [message, setMessage] = useState(''); // Trạng thái lưu trữ tin nhắn đang nhập
    const [messages, setMessages] = useState([]); // Trạng thái lưu trữ danh sách tin nhắn
    const [connection, setConnection] = useState(null); // Trạng thái lưu trữ kết nối SignalR
    const [user, setUser] = useState(null); // Trạng thái lưu trữ thông tin người dùng (không sử dụng trong đoạn mã này)
    const latestMessages = useRef(null); // Reference để lưu trữ tin nhắn mới nhất
    const [page, setPage] = useState(1); // Trang hiện tại để tải lịch sử tin nhắn
    const [pageSize, setPageSize] = useState(10); // Số lượng tin nhắn mỗi trang
    latestMessages.current = messages; // Gán tin nhắn hiện tại vào latestMessages để truy cập sau này

    // useEffect để kết nối với SignalR và tải lịch sử tin nhắn khi component được render lần đầu
    useEffect(() => {
        // Hàm tải lịch sử tin nhắn
        const loadChatHistory = async () => {
            try {
                const response = await axios.get(`${myvalue}/api/chat/history/${props.userId}/${page}/${pageSize}`);
                setMessages(response.data.messages); // Lưu tin nhắn vào state
            } catch (err) {
                console.log(err); // Bắt lỗi nếu có sự cố
            }
        }

        // Tạo kết nối SignalR
        const connect = new HubConnectionBuilder()
            .withUrl(`${myvalue}/chathub`) // Địa chỉ Hub của SignalR
            .configureLogging(LogLevel.Information) // Cấu hình mức độ log cho SignalR
            .build();

        setConnection(connect); // Lưu kết nối vào state

        // Bắt đầu kết nối với Hub
        connect.start()
            .then(() => {
                console.log('Connected to SignalR Hub');
                
                // Sau khi kết nối, tải lịch sử tin nhắn
                loadChatHistory();
            })
            .catch(err => console.log('Error connecting to hub:', err)); // Bắt lỗi nếu kết nối thất bại

        // Lắng nghe sự kiện "ReceiveMessage" từ SignalR
        connect.on("ReceiveMessage", (fromUser, message) => {
            const updatedMessages = [...latestMessages.current, { from: fromUser, message: message }];
            setMessages(updatedMessages); // Cập nhật tin nhắn
        });

        // Cleanup khi component bị unmount
        return () => {
            if (connection) {
                connection.stop(); // Dừng kết nối khi component không còn tồn tại
            }
        };
    }, []); // useEffect này chạy một lần khi component được render lần đầu

    // Hàm đóng cửa sổ chat
    const handleCloseChat = () => {
        props.setIsOpen(false); // Gọi hàm từ props để đóng cửa sổ chat
    }

    // Hàm gửi tin nhắn
    const handleSendMessage = async () => {
        if (message.trim() !== '' && connection) {
            try {
                // Gửi tin nhắn tới người dùng qua SignalR
                await connection.invoke("SendMessageToUser", props.userId, message);
                console.log("Da gui message");

                // Cập nhật danh sách tin nhắn với tin nhắn mới
                const updatedMessages = [...latestMessages.current];
                updatedMessages.push({ 
                    fromUserName: "Admin", // Tên người gửi
                    message: message,
                    from: "Admin" // Tên người gửi là "Admin"
                });
                setMessages(updatedMessages); // Lưu lại tin nhắn vào state
                setMessage(''); // Reset tin nhắn sau khi gửi
            } catch (err) {
                console.log(err); // Bắt lỗi nếu gửi tin nhắn thất bại
            }
        }
    };

    return (
        <div className='chat-admin-container'>
            {/* Header của chat */}
            <div className='chat-admin-header'>
                <div className='chat-admin-header-left'>
                    <img src="user.svg" alt="" /> {/* Hình ảnh đại diện của người dùng */}
                </div>
                <div className='chat-admin-header-center'>
                    <h1>{props.userName || "User Name"}</h1> {/* Hiển thị tên người dùng */}
                </div>
                <div className='chat-admin-header-right'>
                    <button onClick={handleCloseChat}>X</button> {/* Nút đóng cửa sổ chat */}
                </div>
            </div>

            {/* Body của chat */}
            <div className='chat-admin-body'>
                <div className='chat-admin-message-container'>
                    {messages.map((msg, index) => (
                        <div key={index} 
                             className={`chat-admin-message-content ${msg.from !== 'Admin' ? 'sender' : 'receiver'}`}>
                            <img src={msg.fromUserImage || '/user.svg'} alt="" /> {/* Hình ảnh người gửi */}
                            <p>{msg.message}</p> {/* Nội dung tin nhắn */}
                        </div>
                    ))}
                </div>
            </div>

            {/* Footer của chat, nơi người dùng nhập tin nhắn */}
            <div className='chat-admin-footer'>
                <textarea 
                    value={message} // Hiển thị giá trị tin nhắn đang nhập
                    onChange={(e) => setMessage(e.target.value)} // Cập nhật giá trị khi người dùng nhập
                    placeholder='Type your message here...'
                    onKeyDown={(e) => {
                        // Gửi tin nhắn khi nhấn Enter (không cần nhấn Shift)
                        if(e.key === 'Enter' && !e.shiftKey) {
                            e.preventDefault(); // Ngừng việc xuống dòng
                            handleSendMessage(); // Gửi tin nhắn
                        }
                    }}
                />
                <button onClick={handleSendMessage}> {/* Nút gửi tin nhắn */}
                    <img src='/send.svg' alt="" />
                </button>
            </div>
        </div>
    );
}

export default ChatAdmin;
