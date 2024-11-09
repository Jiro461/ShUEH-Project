import { useState, useEffect } from 'react';
import config from "../../config/config.json";

const useFetchUserID = () => {
    const { SERVER_API } = config;
    const [userID, setUserID] = useState(null);

    {/*
        1) useEffect - một Hook trong React - cho phép thực hiện các thao tác phụ (side effects) khi component được render.
        2) tham số [] - biểu thị hiệu ứng chỉ được chạy một lần khi component được mount (render lần đầu), không chạy lại khi có thay đổi khác.
    */}
    useEffect(() => {

        {/*
            hàm bất đồng bộ (async function) - gọi API lấy thông tin userID từ server.
        */}
        const fetchUserID = async () => {
            try {

                {/*
                    1) sử dụng fetch để gửi một yêu cầu HTTP GET tới API cookieGetById để lấy thông tin người dùng.
                    2) credentials: 'include' - cho phép gửi các cookie đi kèm yêu cầu này, giúp server nhận dạng người dùng qua cookie đã được lưu trước đó.
                */}
                const response = await fetch(`${SERVER_API}/api/Account/cookieGetById`, {
                    method: 'GET',
                    credentials: 'include',
                });

                {/*
                    1) response.ok - kiểm tra trạng thái của phản hồi
                    2) Nếu phản hồi thành công (status: 200-299) => lấy dữ liệu từ phản hồi =>
                    Dữ liệu JSON từ phản hồi được chuyển đổi thành đối tượng JavaScript (data) =>
                    cập nhật state userID của component.
                    3) Nếu phản hồi thất bại => log: Failed to fetch user ID
                */}
                if (response.ok) {
                    const data = await response.json();
                    setUserID(data.id);
                } else {
                    console.error("Không thể lấy thông tin user ID");
                }
            } catch (error) {
                console.error("Lỗi khi lấy user ID:", error);
            }
        };

        {/*
            bắt đầu quá trình lấy userID ngay khi useEffect được kích hoạt.
        */}
        fetchUserID();
    }, [SERVER_API]);

    return userID;
};

export default useFetchUserID;
