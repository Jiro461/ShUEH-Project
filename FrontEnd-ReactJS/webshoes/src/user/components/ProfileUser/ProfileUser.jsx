import React, { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import './style.css';

function ProfileUser() {
    const navigate = useNavigate();
    const [userInfo, setUserInfo] = useState({
        avatarUrl: "",
        dateOfBirth: "",
        email: "",
        firstName: "",
        gender: "Male",
        lastName: "",
        phoneNumber: "",
        profileName: "",
        role: "",
    });
    const [isEditing, setIsEditing] = useState(false);
    const [updatedInfo, setUpdatedInfo] = useState(userInfo);

    useEffect(() => {
        const fetchUserData = async () => {
            try {
                const response = await fetch(`${process.env.REACT_APP_API_URL}/api/Account/cookieGetById`, { credentials: "include" });
                if (!response.ok) throw new Error("Không thể lấy thông tin người dùng");

                const data = await response.json();
                const userId = data.id;

                if (!userId) {
                    navigate("/login");
                    return;
                }

                const userResponse = await fetch(`${process.env.REACT_APP_API_URL}/api/Account/user/${userId}`);
                const userData = await userResponse.json();
                console.log("userData: ", userData);

                setUserInfo({
                    avatarUrl: userData.avatarUrl,
                    dateOfBirth: userData.dateOfBirth === null ? "Chưa cập nhật" : userData.dateOfBirth.split('T')[0],
                    email: userData.email,
                    firstName: userData.firstName,
                    gender: userData.gender === null ? "Chưa cập nhật" : (userData.gender ? 'Male' : 'Female'),
                    lastName: userData.lastName,
                    phoneNumber: userData.phoneNumber,
                    profileName: userData.profileName,
                    role: userData.role,
                });
            } catch (error) {
                console.error("Error fetching user data:", error);
                navigate("/login");
            }
        };

        fetchUserData();
    }, [navigate]);

    useEffect(() => {
        setUpdatedInfo(userInfo);
    }, [userInfo]);

    const handleUpdate = async (e) => {
        e.preventDefault();

        if (!updatedInfo.firstName.trim() || !updatedInfo.lastName.trim() || !updatedInfo.profileName.trim()) {
            alert("Các trường 'First Name', 'Last Name', và 'Profile Name' không thể để trống hoặc chỉ chứa khoảng trắng.");
            return;
        }

        const genderValue = updatedInfo.gender === 'Male' ? true : false;

        // Chuyển đổi định dạng ngày sinh từ yyyy-mm-dd thành dd/mm/yy
        const dateParts = updatedInfo.dateOfBirth.split('-');
        const formattedDate = `${dateParts[2]}/${dateParts[1]}/${dateParts[0]}`; // dd/mm/yy

        const updatedData = {
            ...updatedInfo,
            gender: genderValue,
            dateOfBirth: formattedDate, // Gán giá trị đã được định dạng lại
        };

        try {
            const formData = new FormData();

            formData.append("firstName", updatedData.firstName);
            formData.append("lastName", updatedData.lastName);
            formData.append("profileName", updatedData.profileName);
            formData.append("email", updatedData.email);
            formData.append("phoneNumber", updatedData.phoneNumber);
            formData.append("gender", updatedData.gender);
            formData.append("dateOfBirth", updatedData.dateOfBirth);

            if (updatedData.avatarUrl instanceof File) {
                formData.append("avatar", updatedData.avatarUrl);
            }

            const response = await fetch(`${process.env.REACT_APP_API_URL}/api/Account`, {
                method: "PUT",
                body: formData,
            });

            if (!response.ok) {
                console.log(updatedData);
                throw new Error("Không thể cập nhật thông tin người dùng.");
            }

            setUserInfo(updatedData);
            setIsEditing(false);
        } catch (error) {
            console.error("Error updating user data:", error);
            alert("Có lỗi xảy ra khi cập nhật thông tin.");
        }
    };

    // Modify the handleFileChange function to handle image preview and validation
    const handleFileChange = (e) => {
        const selectedFile = e.target.files[0];
        if (selectedFile && (selectedFile.name.endsWith('png') ||
            selectedFile.name.endsWith('jpg') ||
            selectedFile.name.endsWith('jpeg'))) {
            setUpdatedInfo((prevData) => ({
                ...prevData,
                avatarUrl: URL.createObjectURL(selectedFile), // Use object URL for preview
            }));
        } else {
            alert("Chỉ chấp nhận các file hình ảnh với định dạng .png, .jpg, .jpeg.");
        }
    };

    const handleGenderChange = (e) => {
        setUpdatedInfo({ ...updatedInfo, gender: e.target.value });
    };

    if (!userInfo) return <p>Loading...</p>;

    return (
        <div className="user-profile">
            {isEditing ? (
                <div className="edit-profile">
                    <div className="mb-3 form-ava">
                        <label htmlFor="avatar" className="form-label">
                            <img src={updatedInfo.avatarUrl || `${process.env.REACT_APP_API_URL}/images/avatars/noavatar.png`} alt="Avatar" />
                        </label>
                        <input
                            type="file"
                            className="form-control"
                            id="avatar"
                            accept="image/*"
                            onChange={handleFileChange}
                        />
                    </div>

                    <form onSubmit={handleUpdate}>
                        <div className="mb-3 form">
                            <label htmlFor="firstname" className="form-label"><strong>First Name</strong></label>
                            <input
                                type="text"
                                className="form-control"
                                id="firstname"
                                value={updatedInfo.firstName || ""}
                                onChange={(e) => setUpdatedInfo({ ...updatedInfo, firstName: e.target.value })}
                                required
                            />
                        </div>
                        <div className="mb-3 form">
                            <label htmlFor="lastname" className="form-label"><strong>Last Name</strong></label>
                            <input
                                type="text"
                                className="form-control"
                                id="lastname"
                                value={updatedInfo.lastName || ""}
                                onChange={(e) => setUpdatedInfo({ ...updatedInfo, lastName: e.target.value })}
                                required
                            />
                        </div>

                        <div className="mb-3 form">
                            <label htmlFor="fullName" className="form-label"><strong>Profile Name</strong></label>
                            <input
                                type="text"
                                className="form-control"
                                id="fullName"
                                value={updatedInfo.profileName || ""}
                                onChange={(e) => setUpdatedInfo({ ...updatedInfo, profileName: e.target.value })}
                                required
                            />
                        </div>

                        <div className="mb-3 form">
                            <label htmlFor="email" className="form-label"><strong>Email</strong></label>
                            <input
                                type="email"
                                className="form-control"
                                id="email"
                                value={updatedInfo.email || ""}
                                onChange={(e) => setUpdatedInfo({ ...updatedInfo, email: e.target.value })}
                                required
                            />
                        </div>

                        <div className="mb-3 form">
                            <label htmlFor="phone" className="form-label"><strong>Number</strong></label>
                            <input
                                type="text"
                                className="form-control"
                                id="phone"
                                value={updatedInfo.phoneNumber || ""}
                                onChange={(e) => setUpdatedInfo({ ...updatedInfo, phoneNumber: e.target.value })}
                                required
                            />
                        </div>

                        <div className="mb-3 form">
                            <label className="form-label"><strong>Gender</strong></label>
                            <div>
                                <input
                                    type="radio"
                                    id="male"
                                    name="gender"
                                    value="Male"
                                    checked={updatedInfo.gender === 'Male'}
                                    onChange={handleGenderChange}
                                />
                                <label htmlFor="male">Male</label>

                                <input
                                    type="radio"
                                    id="female"
                                    name="gender"
                                    value="Female"
                                    checked={updatedInfo.gender === 'Female'}
                                    onChange={handleGenderChange}
                                />
                                <label htmlFor="female">Female</label>
                            </div>
                        </div>

                        <div className="mb-3 form">
                            <label htmlFor="dateOfBirth" className="form-label"><strong>Date of Birth</strong></label>
                            <input
                                type="date"
                                className="form-control"
                                id="dateOfBirth"
                                value={updatedInfo.dateOfBirth || ""}
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
                        <img
                            className="col-md-2 col-sm-12"
                            src={userInfo.avatarUrl ? `${process.env.REACT_APP_API_URL}${userInfo.avatarUrl}` : `${process.env.REACT_APP_API_URL}/images/avatars/noavatar.png`}
                            alt="Avatar"
                        />
                        <div className="col info">
                            <div className="col-md-3 col-sm-3">
                                <p><strong>ProfileName:</strong></p>
                                <p><strong>Email:</strong></p>
                                <p><strong>Phone:</strong></p>
                                <p><strong>Gender:</strong></p>
                                <p><strong>DateOfBirth:</strong></p>
                            </div>

                            <div className="col-md-4 col-sm-8">
                                <p>{userInfo.firstName} {userInfo.lastName}</p>
                                <p>{userInfo.email}</p>
                                <p>{userInfo.phoneNumber ? userInfo.phoneNumber : "Chưa cập nhật"}</p>
                                <p>{userInfo.gender}</p>
                                <p>{userInfo.dateOfBirth}</p>
                            </div>
                        </div>

                    </div>
                    <div className="btn-edit"><button onClick={() => setIsEditing(true)}>Edit</button></div>
                </>
            )}
        </div>
    );
}

export default ProfileUser;
