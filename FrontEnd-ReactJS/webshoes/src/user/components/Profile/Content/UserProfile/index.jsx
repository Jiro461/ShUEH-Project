import React, { useState } from "react";
import './style.css'

function Profile() {
    const [userInfo, setUserInfo] = useState({
        fullName: 'Nguyễn Văn A', // Tên người dùng
        email: 'nguyenvana@example.com', // Địa chỉ email
        phone: '0123456789', // Số điện thoại
        avatar: null, // Để lưu ảnh đại diện
        gender: 'Male', // Giới tính mặc định là Nam
        dateOfBirth: '2004-09-29', // Ngày sinh
    });
    const [isEditing, setIsEditing] = useState(false);
    const [updatedInfo, setUpdatedInfo] = useState(userInfo);

    const handleUpdate = (e) => {
        e.preventDefault();
        setUserInfo(updatedInfo);
        setIsEditing(false);
    }

    const handleFileChange = (e) => {
        const file = e.target.files[0];
        if (file) {
            const reader = new FileReader();
            reader.onloadend = () => {
                setUpdatedInfo({ ...updatedInfo, avatar: reader.result });
            }
            reader.readAsDataURL(file);
        }
    }

    return (
        <>
            <div className="container user-profile">
                {
                    isEditing ? (
                        <div className="edit">
                            <div>
                                {/* Hình ảnh (Avatar) */}
                                <div className="mb-3 form-ava">
                                    <label htmlFor="avatar" className="form-label"><img src={updatedInfo.avatar} alt=""/></label>
                                    <input
                                        type="file"
                                        className="form-control"
                                        id="avatar"
                                        accept="image/*"
                                        onChange={handleFileChange}
                                    />
                                </div>
                            </div>
                            
                            <form onSubmit={handleUpdate}>
                                {/* Tên người dùng */}
                                <div className="mb-3 form">
                                    <label htmlFor="fullName" className="form-label"><strong>Username</strong></label>
                                    <input
                                        type="text"
                                        className="form-control"
                                        id="fullName"
                                        value={updatedInfo.fullName}
                                        onChange={(e) => setUpdatedInfo({ ...updatedInfo, fullName: e.target.value })}
                                        required
                                    />
                                </div>

                                {/* Email */}
                                <div className="mb-3 form">
                                    <label htmlFor="email" className="form-label"><strong>Email</strong></label>
                                    <input
                                        type="email"
                                        className="form-control"
                                        id="email"
                                        value={updatedInfo.email}
                                        onChange={(e) => setUpdatedInfo({ ...updatedInfo, email: e.target.value })}
                                        required
                                    />
                                </div>

                                {/* Number */}
                                <div className="mb-3 form">
                                    <label htmlFor="phone" className="form-label"><strong>Number</strong></label>
                                    <input
                                        type="text"
                                        className="form-control"
                                        id="phone"
                                        value={updatedInfo.phone}
                                        onChange={(e) => setUpdatedInfo({ ...updatedInfo, phone: e.target.value })}
                                        required
                                    />
                                </div>

                                {/* Giới tính (Gender) */}
                                <div className="mb-3 form">
                                    <label className="form-label"><strong>Gender</strong></label>
                                    <div>
                                        <input
                                            type="radio"
                                            id="male"
                                            name="gender"
                                            value="Male"
                                            checked={updatedInfo.gender === 'Male'}
                                            onChange={(e) => setUpdatedInfo({ ...updatedInfo, gender: e.target.value })}
                                        />
                                        <label htmlFor="male">Male</label>

                                        <input
                                            type="radio"
                                            id="female"
                                            name="gender"
                                            value="Female"
                                            checked={updatedInfo.gender === 'Female'}
                                            onChange={(e) => setUpdatedInfo({ ...updatedInfo, gender: e.target.value })}
                                            style={{ marginLeft: '10px' }}
                                        />
                                        <label htmlFor="female">Female</label>
                                    </div>
                                </div>

                                {/* Ngày sinh (Date of Birth) */}
                                <div className="mb-3 form">
                                    <label htmlFor="dateOfBirth" className="form-label"><strong>Date of Birth</strong></label>
                                    <input
                                        type="date"
                                        className="form-control"
                                        id="dateOfBirth"
                                        value={updatedInfo.dateOfBirth}
                                        onChange={(e) => setUpdatedInfo({ ...updatedInfo, dateOfBirth: e.target.value })}
                                        required
                                    />
                                </div>

                                <button type="submit" className="btn-update">Update</button>
                                <button type="button" className="btn-cancel" onClick={() => setIsEditing(false)}>Cancel</button>
                            </form>
                        </div>

                    ) : (
                        <>
                            <div className="row user-info">
                                <img className="col-md-2 col-sm-12"
                                    src={userInfo.avatar} // Hiển thị ảnh đại diện
                                    alt="Avatar"
                                />

                                <div className="col info">
                                    <div className="col-md-3 col-sm-3">
                                        {/* Hiển thị thông tin người dùng */}
                                        <p><strong>Full Name:</strong></p>
                                        <p><strong>Email:</strong></p>
                                        <p><strong>Phone:</strong></p>
                                        <p><strong>Gender:</strong></p>
                                        <p><strong>Date of Birth:</strong></p>
                                    </div>

                                    <div className="col-md-4 col-sm-8">
                                        <p>{userInfo.fullName}</p>
                                        <p>{userInfo.email}</p>
                                        <p>{userInfo.phone}</p>
                                        <p>{userInfo.gender}</p>
                                        <p>{userInfo.dateOfBirth}</p>
                                    </div>
                                </div>

                                
                            </div>
                            {/* Nút để chuyển sang chế độ chỉnh sửa */}
                            <button className="btn-edit" onClick={() => setIsEditing(true)}>Edit</button>
                        </>
                    )
                }
            </div>
        </>
    );
}

export default Profile;
