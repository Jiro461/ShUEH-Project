import React, { useState } from 'react';
import './Register.scss'
import { registerUser } from "../../../redux/request";
import { useDispatch } from "react-redux";
import { useNavigate } from "react-router-dom";
import * as authService from "../../../services/authService"

const Register = (props) => {
    const dispatch = useDispatch()
    const navigate = useNavigate()
    const [registerUser, setRegisterUser] = useState({
        username: "",
        password: "",
        email: "",
        firstName: "",
        lastName: "",
        dateOfBirth: "",
        gender: "",
        confirm: false,
    });

    function formatDateString(dateString) {
        const parts = dateString?.split("-");
        if (parts.length === 3) {
            return `${parts[2]}/${parts[1]}/${parts[0]}`;
        }
        return null;
    }

    const handleChange = (e) => {
        const { name, value, checked } = e.target;

        if (name === "male" || name === "female") {
            setRegisterUser((prev) => ({
                ...prev,
                gender: name, // Cập nhật giá trị giới tính dựa vào tên checkbox
            }));
        } else {
            setRegisterUser((prev) => ({
                ...prev,
                [name]: name === "confirm" ? checked : value, // Xử lý checkbox cho 'confirm'
            }));
        }
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        const formatUser = {
            ...registerUser,
            dateOfBirth: formatDateString(registerUser?.dateOfBirth),
        };
        authService.registerUser(formatUser);
        props.setOpen(false);
    };

    return (
        <div className="overlay" onClick={() => props.setOpenRegister(false)}>
            <div className="register-block" onClick={(e) => e.stopPropagation()}>
                <div className="register-content">
                    <div className="close" onClick={() => props.setOpenRegister(false)}>
                        <i className="fa-solid fa-xmark"></i>
                    </div>
                    <div className="logo">
                        <img className="logo" src="/shueh-logo.svg" alt=""></img>
                    </div>

                    <div className="heading">
                        <h1>Register</h1>
                    </div>

                    <form onSubmit={handleSubmit}>
                        <div className="form-item username">
                            <label>Username</label>
                            <input type="text" name="username" placeholder="Username" onChange={handleChange}></input>
                        </div>
                        <div className="form-item password">
                            <label>Password</label>
                            <input type="password" name="password" placeholder="Password" onChange={handleChange}></input>
                        </div>

                        <div className="form-item require">
                            <label>Required</label>
                            <label>X Minimum of 8 characters</label>
                            <label>X Uppercase, lowercase letters, and one number</label>
                        </div>
                        <div className="form-item email">
                            <label>Email</label>
                            <input type="text" name="email" placeholder="Email" onChange={handleChange}></input>
                        </div>
                        <div className="form-item name">
                            <div className="first-name">
                                <label>First name</label>
                                <input type="text" name="firstName" placeholder="First name" onChange={handleChange}></input>
                            </div>
                            <div className="last-name">
                                <label>Last name</label>
                                <input type="text" name="lastName" placeholder="Last name" onChange={handleChange}></input>
                            </div>
                        </div>
                        <div className="form-item birth">
                            <label>Date of birth</label>
                            <div className="birth-info">
                                <input type="date" name="dateOfBirth" onChange={handleChange}></input>
                            </div>
                        </div>

                        <div className="form-item gender">
                            <label>Gender</label>
                            <div className="gender-info">
                                <div className="male">
                                    <input
                                        className="btn-check-box"
                                        type="checkbox"
                                        name="male"
                                        checked={registerUser.gender === "male"}
                                        onChange={handleChange}
                                    ></input>
                                    <label>Male</label>
                                </div>
                                <div className="female">
                                    <input
                                        className="btn-check-box"
                                        type="checkbox"
                                        name="female"
                                        checked={registerUser.gender === "female"}
                                        onChange={handleChange}
                                    ></input>
                                    <label>Female</label>
                                </div>
                            </div>
                        </div>
                        <div className="form-item confirm">
                            <input
                                className="btn-check-box confirm-checkbox"
                                type="checkbox"
                                name="confirm"
                                onChange={handleChange}
                            ></input>
                            <span>
                                I agree to Shueh's <span>Privacy Policy</span> and <span>Terms of Use</span>
                            </span>
                        </div>
                        <button className="btn-submit" type="submit">
                            Register
                        </button>
                    </form>
                </div>
            </div>
        </div>
    );
};

export default Register;
