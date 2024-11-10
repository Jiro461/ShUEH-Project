import request from "../utils/request.js"

// Hàm tạo FormData từ dữ liệu sản phẩm giày
const createProductFormData = (shoeData) => {
    var formData = new FormData();
    // Thêm các thuộc tính của sản phẩm vào FormData
    formData.append('Name', shoeData.name);  // Tên sản phẩm
    formData.append('Brand', shoeData.brand); // Thương hiệu sản phẩm
    formData.append('Gender', shoeData.gender); // Giới tính (nam/nữ/unisex)
    formData.append('Material', shoeData.materials.map((item) => item.material).join(', ')); // Vật liệu sản phẩm
    formData.append('Category', shoeData.category); // Loại sản phẩm
    formData.append('ImageUrl', ""); // Đường dẫn ảnh (rỗng tại thời điểm này)
    formData.append('Description', shoeData.description); // Mô tả sản phẩm
    formData.append('Price', parseInt(shoeData.price, 10)); // Giá sản phẩm
    formData.append('IsSale', parseInt(shoeData.discount, 10) > 0 ? true : false); // Kiểm tra nếu sản phẩm có giảm giá
    formData.append('Discount', parseInt(shoeData.discount, 10) > 0 ? parseInt(shoeData.discount, 10) : 0); // Giảm giá sản phẩm

    // Thêm ảnh chính nếu có
    if (shoeData.mainImage) formData.append('MainImage', shoeData.mainImage);

    // Thêm màu sắc của sản phẩm vào FormData
    shoeData.colors.forEach((item, index) => formData.append(`colors[${index}][color]`, item.color));
    
    // Thêm mùa của sản phẩm vào FormData
    shoeData.seasons.forEach((item, index) => formData.append(`seasons[${index}][season]`, item.season));
    
    // Thêm kích cỡ và số lượng của sản phẩm vào FormData
    shoeData.sizes.forEach((item, index) => {
        formData.append(`shoeDetails[${index}][size]`, item.size);
        formData.append(`shoeDetails[${index}][quantity]`, item.quantity);
    });

    // Thêm ảnh bổ sung nếu có và là kiểu File
    if (shoeData.additionalImages && Array.isArray(shoeData.additionalImages)) {
        shoeData.additionalImages.forEach(image => {
            // Kiểm tra nếu image là một File
            if (image instanceof File) {
                formData.append('AdditionalImages', image);
            }
        });
    }

    return formData; // Trả về FormData đã tạo
};

// Hàm thêm sản phẩm mới
export const addNewProduct = async (shoeData) => {
    console.log("shoeAdd", shoeData); // Log dữ liệu sản phẩm
    const formData = createProductFormData(shoeData); // Tạo FormData từ shoeData
    // Log các khóa và giá trị của FormData
    for (let [key, value] of formData.entries()) {
        console.log(key, value);
    }
    var message = "Add new product successfully"; // Thông báo thành công
    var type = "success"; // Kiểu thông báo thành công
    try {
        // Gửi yêu cầu POST để thêm sản phẩm mới
        const res = await request.post("/api/Shoe/create", formData, {
            headers: {
              'Content-Type': 'multipart/form-data', // Cần thiết cho việc tải lên tệp
            }
          });   
        return {
            res: res,
            status: res.status,
            type: type,
            message: message
        };
    } catch (error) {
        // Xử lý lỗi nếu có
        if (error.status === 400){
            return { 
                error: error,
                status: error.status,
                type: "warning",
                message: "Please fill out required fields", // Thông báo nếu thiếu trường
            };
        }
        return {
            error: error,
            status: error.status,
            type: "error", // Kiểu thông báo lỗi
            message: "Add new product failed" // Thông báo nếu thêm sản phẩm thất bại
        };
    }
}

// Hàm lấy tất cả sản phẩm
export const getAllProducts = async () => {
    try {
        // Gửi yêu cầu GET để lấy tất cả sản phẩm
        const res = await request.get("/api/Shoe/all");
        // Xử lý dữ liệu trả về
        return res?.data?.map(item => {
            if (item.discount){
              item.discount = `${item.discount}%`; // Hiển thị giảm giá dưới dạng phần trăm
            }
            if(!item.imageUrl.includes(`${process.env.REACT_APP_API_URL}`)){
              item.imageUrl = `${process.env.REACT_APP_API_URL}/${item.imageUrl}`; // Đảm bảo đường dẫn ảnh đúng
            }
            if (item.price){
                item.price = item.price.toLocaleString("vi-VN"); // Định dạng giá theo kiểu Việt Nam
            }
            return item;
          });
    } catch (error) {
        console.log(error); // Log lỗi nếu có
    }
}

// Hàm lấy thông tin sản phẩm theo ID
export const getProductById = async (id) => {
    try {
        // Gửi yêu cầu GET để lấy thông tin sản phẩm theo ID
        const res = await request.get(`/api/Shoe/${id}`);
        // Kiểm tra và bổ sung đường dẫn ảnh nếu cần
        if (!res?.data?.imageUrl?.includes(process.env.REACT_APP_API_URL)){
            res.data.imageUrl = `${process.env.REACT_APP_API_URL}/${res.data.imageUrl}`;
          }
        return res.data; // Trả về dữ liệu sản phẩm
    } catch (error) {
        console.log(error); // Log lỗi nếu có
    }
}

// Hàm cập nhật thông tin sản phẩm
export const updateProduct = async (id, shoeData) => {
    console.log("shoeService", shoeData); // Log dữ liệu sản phẩm
    var formData = createProductFormData(shoeData); // Tạo FormData từ shoeData
    // Log các khóa và giá trị của FormData
    for (let [key, value] of formData.entries()) {
        console.log(key, value);
    }
    var message = "Update product successfully"; // Thông báo thành công
    var type = "success"; // Kiểu thông báo thành công
    try {
        // Gửi yêu cầu PUT để cập nhật sản phẩm
        const res = await request.put(`/api/Shoe/${id}`, formData, {
            headers: {
              'Content-Type': 'multipart/form-data', // Cần thiết cho việc tải lên tệp
            }
        });
        return {
            res: res,
            status: res.status,
            type: type,
            message: message
        };
    } catch (error) {
        // Xử lý lỗi nếu có
        if (error.status === 400){
            return { 
                error: error,
                status: error.status,
                type: "warning",
                message: "Please fill out required fields", // Thông báo nếu thiếu trường
            };
        }
        return {
            error: error,
            status: error.status,
            type: "error", // Kiểu thông báo lỗi
            message: "Update product failed" // Thông báo nếu cập nhật sản phẩm thất bại
        };
    }
}

// Hàm xóa sản phẩm theo ID
export const deleteProduct = async (id) => {
    var message = "Delete product successfully"; // Thông báo thành công
    var type = "success"; // Kiểu thông báo thành công
    try {
        // Gửi yêu cầu DELETE để xóa sản phẩm
        const res = await request.delete(`/api/Shoe/${id}`);
        return {
            res: res,
            status: res.status,
            type: type,
            message: message
        };
    } catch (error) {
        return {
            error: error,
            status: error.status,
            type: "error", // Kiểu thông báo lỗi
            message: "Delete product failed" // Thông báo nếu xóa sản phẩm thất bại
        };
    }
}
