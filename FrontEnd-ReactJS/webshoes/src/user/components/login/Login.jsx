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
                        <button className="btn-login-google">
                            <img src="data:image/svg+xml,%3csvg%20width='18'%20height='18'%20viewBox='0%200%2018%2018'%20xmlns='http://www.w3.org/2000/svg'%3e%3cg%20transform=''%3e%3cg%20fill-rule='evenodd'%3e%3cpath%20d='m17.64%209.2a10.341%2010.341%200%200%200%20-.164-1.841h-8.476v3.481h4.844a4.14%204.14%200%200%201%20-1.8%202.716v2.264h2.909a8.777%208.777%200%200%200%202.687-6.62z'%20fill='%234285f4'/%3e%3cpath%20d='m9%2018a8.592%208.592%200%200%200%205.956-2.18l-2.909-2.258a5.43%205.43%200%200%201%20-8.083-2.852h-3.007v2.332a9%209%200%200%200%208.043%204.958z'%20fill='%2334a853'/%3e%3cpath%20d='m3.964%2010.71a5.321%205.321%200%200%201%200-3.42v-2.332h-3.007a9.011%209.011%200%200%200%200%208.084z'%20fill='%23fbbc05'/%3e%3cpath%20d='m9%203.58a4.862%204.862%200%200%201%203.44%201.346l2.581-2.581a8.649%208.649%200%200%200%20-6.021-2.345%209%209%200%200%200%20-8.043%204.958l3.007%202.332a5.364%205.364%200%200%201%205.036-3.71z'%20fill='%23ea4335'/%3e%3c/g%3e%3cpath%20d='m0%200h18v18h-18z'%20fill='none'/%3e%3c/g%3e%3c/svg%3e" alt=""></img>
                            <span>Login with Google</span>
                        </button>
                    </form>
                </div>
            </div>
        </div>
    );
};

export default Login;