import request from "../utils/request.js"

export const addNewUser = async (formData) => {
    try {
        const res = await request.post("/api/Account/get-users-info", formData, {
            headers: {
              'Content-Type': 'multipart/form-data', // Necessary for file uploads
            }
          });    
        return res.data
    } catch (error) {
        console.log(error);
    }
}

export const getAllUsers = async () => {
    try {
        const res = await request.get("/api/Account/get-users-info")
        return res.data
    } catch (error) {
        console.log(error);
    }
}

export const updateUser = async (id, formData) => {
    try {
        const res = await request.put(`Account/${id}`)
        return res.data
    } catch (error) {
        console.log(error);
    }
}

export const deleteUser = async (id) => {
    try {
        const res = await request.delete(`/Account/${id}`);    
        return res.data
    } catch (error) {
        console.log(error);
    }
}

