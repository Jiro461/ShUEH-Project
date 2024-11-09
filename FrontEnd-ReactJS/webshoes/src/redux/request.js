import axios from "axios";
import request from "../utils/request";
import { loginFailed, loginStart, loginSuccess } from "./authSlice";

export const loginUser = async (user, dispatch, navigate) => {
    dispatch(loginStart())
    try {
        await request.post("/api/Account/login", user)
        const res = await request.get("/api/Account/cookieGetById")
        dispatch(loginSuccess(res.data))
        navigate("/")
    } catch (error) {
        dispatch(loginFailed())
    }
}