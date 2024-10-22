import React from 'react';
import './Register.scss'

//Tại sao push k viết hoa folder ?
const Register = () => {
    return (
        <div className="overlay">
            <div className="register-block">
                <div className="register-content">
                    <div className="logo">
                        <img className="logo" src="/shueh-logo.svg" alt=""></img>
                    </div>

                    <div className="heading">
                        <h1>Register</h1>
                    </div>

                    <form>
                        <div className="form-item email">
                            <label>Email</label>
                            <input type="text" placeholder="Email"></input>
                        </div>
                        <div className="form-item phone-number">
                            <label>Phone Number</label>
                            <input type="text" placeholder="Phone Number"></input>
                        </div>
                        <div className="form-item name">
                            <div className="first-name">
                                <label>First name</label>
                                <input type="text" placeholder="First name"></input>
                            </div>
                            <div className="last-name">
                                <label>Last name</label>
                                <input type="text" placeholder="Last name"></input>
                            </div>
                        </div>
                        <div className="form-item password">
                            <label>Password</label>
                            <input type="text" placeholder="Password"></input>
                        </div>

                        <div className="form-item require">
                            <label>Required</label>
                            <label>X Minimum of 8 characters</label>
                            <label>X Uppercase, lowercase letters, and one number</label>
                        </div>

                        <div className="form-item birth">
                            <label>Date of birth</label>
                            <div className="birth-info">
                                <input type="number" placeholder="Day" min="1" max="31"></input>
                                <input type="number" placeholder="Month" min="1" max="12"></input>
                                <input type="number" placeholder="Year" min="1950" max="2024" defaultValue="2024"></input>
                            </div>
                        </div>

                        <div className="form-item gender">
                            <label>Gender</label>
                            <div className="gender-info">
                                <div className="male">
                                    <input className="btn-check-box" type="checkbox"></input>
                                    <label>Male</label>
                                </div>
                                <div className="female">
                                    <input className="btn-check-box" type="checkbox"></input>
                                    <label>Female</label>
                                </div>
                            </div>
                        </div>
                        <div className="form-item confirm">
                            <input className="btn-check-box confirm-checkbox" type="checkbox"></input>
                            <p>I agree to Shueh's <span>Privacy Policy</span> and <span>Terms of Use</span></p>
                        </div>
                        <button className="btn-submit" type="submit">Register</button>
                    </form>
                </div>
            </div>
        </div>
    );
};

export default Register;