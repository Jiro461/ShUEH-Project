import request from "../utils/request.js"

const createProductFormData = (shoeData) => {
    const formData = new FormData();
    formData.append('Name', shoeData.name);
    formData.append('Brand', shoeData.brand);
    formData.append('Gender', shoeData.gender);
    formData.append('Material', shoeData.materials.map((item) => item.material).join(', '));
    formData.append('Category', shoeData.category);
    formData.append('ImageUrl', "");
    formData.append('Description', shoeData.description);
    formData.append('Price', parseInt(shoeData.price, 10));
    formData.append('IsSale', shoeData.discount > 0 ? true : false);
    formData.append('Discount', shoeData.discount > 0 ? parseInt(shoeData.discount) : 0);

    if (shoeData.mainImage) formData.append('MainImage', shoeData.mainImage);

    shoeData.colors.forEach((item, index) => formData.append(`colors[${index}][color]`, item.color));
    shoeData.seasons.forEach((item, index) => formData.append(`seasons[${index}][season]`, item.season));
    shoeData.sizes.forEach((item, index) => {
        formData.append(`shoeDetails[${index}][size]`, item.size);
        formData.append(`shoeDetails[${index}][quantity]`, item.quantity);
    });
    shoeData.additionalImages.forEach(image => formData.append('AdditionalImages', image));

    return formData;
};


export const addNewProduct = async (shoeData) => {
    const formData = createProductFormData(shoeData);
    var message = "Add new product successfully"
    var type = "success"
    try {
        
        const res = await request.post("/api/Shoe/create", formData, {
            headers: {
              'Content-Type': 'multipart/form-data', // Necessary for file uploads
            }
          });   
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
            message: "Add new product failed"
        }
    }
}

export const getAllProducts = async () => {
    try {
        const res = await request.get("/api/Shoe/all")
        return res?.data?.map(item => {
            if (item.discount){
              item.discount = `${item.discount}%`
            }
            if(!item.imageUrl.includes(`${process.env.REACT_APP_API_URL}`)){
              item.imageUrl = `${process.env.REACT_APP_API_URL}/${item.imageUrl}`
            }
            if (item.price){
                item.price = item.price.toLocaleString("vi-VN")
            }
            return item
          })
    } catch (error) {
        console.log(error);
    }
}

export const getProductById = async (id) => {
    try {
        const res = await request.get(`/api/Shoe/${id}`)
        if (!res?.data?.imageUrl?.includes(process.env.REACT_APP_API_URL)){
            res.data.imageUrl = `${process.env.REACT_APP_API_URL}/${res.data.imageUrl}`
          }
        return res.data
    } catch (error) {
        console.log(error);
    }
}

export const updateProduct = async (id, shoeData) => {
    const formData = createProductFormData(shoeData);
    var message = "Update product successfully"
    var type = "success"
    try {
        const res = await request.put(`/api/Shoe/${id}`, formData, {
            headers: {
              'Content-Type': 'multipart/form-data', // Necessary for file uploads
            }
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
            message: "Update product failed"
        }
    }
}

export const deleteProduct = async (id) => {
    var message = "Delete product successfully"
    var type = "success"
    try {
        const res = await request.delete(`/api/Shoe/${id}`);   
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
            message: "Delete product failed"
        }
    }
}

