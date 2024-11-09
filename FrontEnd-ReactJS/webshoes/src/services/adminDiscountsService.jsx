import request from "../utils/request.js"

export const addNewDiscount = async (discount) => {
    var message = "Add new discount successfully"
    var type = "success"
    // const userData = {
    //     userName: user.userName, // "string"
    //     password: user.password, // "string"
    //     email: user.email, // "string"
    //     firstName: user.firstName, // "string"
    //     lastName: user.lastName, // "string"
    //     dateOfBirth: user.dateOfBirth, // "string" (dạng yyyy-MM-dd, ví dụ: "2024-11-05")
    //     gender: user.gender, // true/false
    //     role: user.role // "string"
    // };
    try {
        const res = await request.post("/api/Discount/add", discount);    
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
            message: "Add new discount failed"
        }
    }
}

export const getAllDiscounts = async () => {
    try {
        const res = await request.get("/api/Discount/all")
        return res.data.map((item) => {
            if (item.percentage){
                item.percentage = `${item.percentage}%`
            }
            if (item.type === 0){
                item.type = "Ship"
            } else if (item.type === 1){
                item.type = "Order"
            }
            return item
        })
    } catch (error) {
        console.log(error);
    }
}

export const getDiscountById = async (id) => {
    try {
        const res = await request.get(`/api/Discount/${id}`)
        return res.data
    } catch (error) {
        console.log(error);
    }
}

export const updateDiscount = async (id, discount) => {
    var message = "Update discount successfully"
    var type = "success"
    try {
        const res = await request.put(`/api/Discount/update/${id}`, discount)
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
            message: "Update discount failed"
        }
    }
}

export const deleteDiscount = async (id) => {
    var message = "Delete discount successfully"
    var type = "success"
    try {
        const res = await request.delete(`/api/Discount/delete/${id}`);    
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
            message: "Delete discount failed"
        }
    }
}

