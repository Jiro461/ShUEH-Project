import request from "../utils/request.js"

const createProductFormData = (user) => {
    const formData = new FormData();
    formData.append('FirstName', user.firstName);
    formData.append('LastName', user.lastName);
    formData.append('Email', user.email);
    formData.append('ProfileName', user.profileName);
    formData.append('Gender', user.gender);
    formData.append('Role', user.role);
    formData.append('DateOfBirth', user.dateOfBirth);

    if (user.avatar) formData.append('Avatar', user.avatar);
    return formData;
};

export const addNewUser = async (user) => {
    var type = "success"
    var message = "Add new user successfully"
    try {
        const res = await request.post("/api/Account/add", user);    
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
            message: "Add new user failed"
        }
    }
}

export const getAllUsers = async () => {
    try {
        const res = await request.get("/api/Account/get-users-info")
        return res.data.map((item) => {
            item.avatarUrl = `${process.env.REACT_APP_API_URL}/${item.avatarUrl}`
            return item
        })
    } catch (error) {
        console.log(error);
    }
}

export const getUserById = async (id) => {
    try {
        const res = await request.get(`/api/Account/user/${id}`)
        res.data.avatarUrl = `${process.env.REACT_APP_API_URL}/${res.data.avatarUrl}` 
        return res.data
    } catch (error) {
        console.log(error);
}
}

export const updateUser = async (id, user) => {
    const formData = createProductFormData(user)
    var type = "success"
    var message = "Update user successfully"
    try {
        const res = await request.put(`/api/Account/${id}`, formData, {
            headers: "multipart/form-data"
        })
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
            message: "Update user failed"
        }
    }
}

export const deleteUser = async (id) => {
    var type = "success"
    var message = "Delete user successfully"
    try {
        const res = await request.delete(`/api/Account/admin/delete/${id}`);    
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
            message: "Delete user failed"
        }
    }
}

