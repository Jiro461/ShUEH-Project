import React from 'react';
import './Login.scss'

const Login = () => {
    return (
        <div className="overlay">
            <div className="login-block">
                <div className="login-content">
                    <div className="logo">
                        <img className="logo" src="/shueh-logo.svg" alt=""></img>
                    </div>

                    <div className="heading">
                        <h1>Login</h1>
                    </div>

                    <form>
                        <div className="username">
                            <label>Username</label>
                            <input type="text" placeholder="Username"></input>
                        </div>
                        <div className="password">
                            <label>Password</label>
                            <input type="text" placeholder="Password"></input>
                        </div>
                        <button className="btn-submit" type="submit">Login</button>
                        <a href="#1" className="forgot-password">Forgot password?</a>
                        <span>or</span>
                        <button className="btn-create">Create a new account</button>
                    </form>
                </div>
            </div>
        </div>
    );
};

export default Login;