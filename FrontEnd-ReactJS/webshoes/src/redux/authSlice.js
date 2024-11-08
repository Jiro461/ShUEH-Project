import { createSlice } from "@reduxjs/toolkit"
import * as authService from "../services/authService"

const authSlice = createSlice({
    name: "auth",
    initialState: {
        login: {
            currentUser: null,
            isFetching: false,
            error: false,
        }
    },
    reducers: {
        loginStart: (state) => {
            state.login.isFetching = true
        },
        loginSuccess: (state, action) => {
            state.login.isFetching = false
            state.login.error = false
            state.login.currentUser = action.payload
        },
        loginFailed: (state) => {
            state.login.isFetching = false
            state.login.error = true
        },
        logoutSuccess: (state) => {
            state.login.currentUser = null
        }
    }
})

export const {
    loginStart,
    loginFailed,
    loginSuccess,
    logoutSuccess
} = authSlice.actions

export default authSlice.reducer