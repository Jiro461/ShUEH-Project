import { useState } from 'react';
import "./style.css";

function ProfileChangePassword() {
    const [currentPassword, setCurrentPassword] = useState("");
    const [newPassword, setNewPassword] = useState("");
    const [error, setError] = useState("");
    const [success, setSuccess] = useState(false);

    // Hàm xử lý thay đổi mật khẩu
    const handleChangePassword = async () => {
        if (!newPassword) {
            setError("Mật khẩu mới không được để trống!");
            return;
        }

        // Chuyển đổi giá trị vào URL để tránh lỗi cú pháp
        const currentPasswordParam = encodeURIComponent(currentPassword);
        const newPasswordParam = encodeURIComponent(newPassword);

        // Gọi API đổi mật khẩu
        try {
            const url = `${process.env.REACT_APP_API_URL}/api/Account/change-password?currentPassword=${currentPasswordParam}&newPassword=${newPasswordParam}`;

            const response = await fetch(url, {
                method: 'POST',
                credentials: "include",  // Đảm bảo gửi cookie nếu có
            });

            if (!response.ok) {
                throw new Error("Đổi mật khẩu thất bại. Vui lòng kiểm tra lại mật khẩu.");
            }

            // Nếu thành công, hiển thị thông báo thành công
            setSuccess(true);
            setError("");  // Xóa lỗi nếu có
        } catch (error) {
            setError(error.message || "Có lỗi xảy ra khi đổi mật khẩu.");
            setSuccess(false);
        }
    };

    return (
        <div className="profile-change-password">
            <h2>Đổi mật khẩu</h2>

            {/* Hiển thị thông báo lỗi hoặc thành công */}
            {error && <p className="error">{error}</p>}
            {success && <p className="success">Mật khẩu đã được thay đổi thành công!</p>}

            {/* Form nhập mật khẩu */}
            <div>
                <label>Mật khẩu cũ:</label>
                <input 
                    type="password" 
                    value={currentPassword} 
                    onChange={(e) => setCurrentPassword(e.target.value)} 
                    placeholder="Nhập mật khẩu cũ" 
                />
            </div>

            <div>
                <label>Mật khẩu mới:</label>
                <input 
                    type="password" 
                    value={newPassword} 
                    onChange={(e) => setNewPassword(e.target.value)} 
                    placeholder="Nhập mật khẩu mới" 
                />
            </div>

            <button onClick={handleChangePassword}>Đổi mật khẩu</button>
        </div>
    );
}

export default ProfileChangePassword;
