import React, { useState, useEffect } from 'react';
import './AdminLogin.scss';
import Footer from '../../components/footer/Footer';
import { TextField, Button } from '@mui/material';
import axios from 'axios';
import { useNavigate } from 'react-router-dom';
const AdminLogin = () => {
    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');
    const host = process.env.REACT_APP_API_URL;
    const navigate = useNavigate();
    const handleLogin = () => {
            var request = {
                username: username,
                password: password,
                rememberMe: false
            }
            axios.post(`${host}/api/account/login`, request, {
                headers: {
                  'Content-Type': 'application/json'
                },
                withCredentials: true
            })
            .then(response => {
                if(response.status === 200) {
                    navigate('/admin');
                }
            })
            .catch(error => {
                if (error.response) {
                    console.log("Error response:", error.response);
                } else if (error.request) {
                    console.log("Error request:", error.request);
                } else {
                    console.log("Error:", error.message);
                }
            });
    }
    return (
        <div className='admin-login'>
            <div className='admin-login-container'>
                <div className='admin-login-form'>
                    <div className='admin-login-form-title'>
                    <h1>Log in.</h1>
                </div>
                <div className='admin-login-form-content'>
                    <div className='admin-login-form-content-item'>
                        <TextField id="outlined-basic" label="Username" onChange={(e) => setUsername(e.target.value)} />
                    </div>
                    <div className='admin-login-form-content-item'>
                        <TextField id="outlined-basic" label="Password" type='password' margin='normal' fullWidth onChange={(e) => setPassword(e.target.value)} />
                    </div>
                    <div className='admin-login-form-content-item'>
                        <Button variant="contained" fullWidth onClick={handleLogin}>Log in</Button>
                    </div>
                    <div className='forgot-password'>
                        <a href='#'>Forgot password?</a>
                        </div>
                    </div>
                </div>
            </div>
            <div className='admin-login-footer'>
                <Footer />
            </div>
        </div>
    );
};

export default AdminLogin;