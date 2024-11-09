import request from "../utils/request.js"

export const getAllOrders = async () => {
    try {
        var status = ["Pending", "Confirmed", "Shipped", "Delivered", "Canceled"]
        var payment = ["Vnpay", "Cash"]
        const res = await request.get("/api/Order/all") 
        return res?.data?.orderDTOs?.map((item) => {
            item.imageUrl = `${process.env.REACT_APP_API_URL}/${res.data.imageUrl}`
            if (item.status === 0) item.status = "Pending"
            if (item.status === 1) item.status = "Confirmed"
            if (item.status === 2) item.status = "Shipped"
            if (item.status === 3) item.status = "Delivered"
            if (item.status === 4) item.status = "Canceled"
            if (item.paymentMethod === 0) item.paymentMethod = "Vnpay"
            if (item.paymentMethod === 1) item.paymentMethod = "Cash"
            return item
        })
    } catch (error) {
        console.log(error);
    }
}

export const getOrderById = async (id) => {
    try {
        const res = await request.get(`/api/Order/${id}`)
        if (res.data.status === 0) res.data.status = "Pending"
        if (res.data.status === 1) res.data.status = "Confirmed"
        if (res.data.status === 2) res.data.status = "Shipped"
        if (res.data.status === 3) res.data.status = "Delivered"
        if (res.data.status === 4) res.data.status = "Canceled"
        console.log(res);
        return res.data
    } catch (error) {
        console.log(error);
    }
}

export const updateOrder = async (id, status) => {
    var message = "Update order successfully"
    var type = "success"
    try {
        const res = await request.put(`/api/Order/update/${id}/${status}`)
        return {
            res: res,
            status: res.status,
            type: type,
            message: message
        }
    } catch (error) {
        if (error.status === 400){
            return { 
                error: error,
                status: error.status,
                type: "warning",
                message: "Please fill out required fields",
            }
        }
        return {
            error: error,
            status: error.status,
            type: "error",
            message: "Update order failed"
        }
    }
}

export const deleteOrder = async (id) => {
    var message = "Delete order successfully"
    var type = "success"
    try {
        const res = await request.delete(`/api/Order/delete/${id}`);   
        return {
            res: res,
            status: res.status,
            type: type,
            message: message
        }
    } catch (error) {
        return {
            error: error,
            status: error.status,
            type: "error",
            message: "Delete order failed"
        }
    }
}

