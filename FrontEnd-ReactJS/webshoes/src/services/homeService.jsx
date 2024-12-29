import request from "../utils/request.js";

// Hàm lấy danh sách sản phẩm từ API
export const getProducts = async () => {
  try {
    // Gửi yêu cầu GET đến API để lấy dữ liệu sản phẩm
    const res = await request.get(`/api/Shoe/home`);
    return res.data.map((item) => {
      // Thêm đường dẫn đầy đủ cho ảnh sản phẩm
      item.imageUrl = `${process.env.REACT_APP_API_URL}/${item.imageUrl}`;
      // Chuyển giá sản phẩm sang định dạng VND (việt nam đồng)
      item.price = item.price.toLocaleString("vi-VN");
      return item; // Trả về thông tin sản phẩm đã xử lý
    });
  } catch (error) {
    console.log(error); // In lỗi nếu có
  }
};

// Hàm lấy sản phẩm theo thương hiệu từ API
export const getProductsByBrand = async (brand) => {
  try {
    // Gửi yêu cầu GET đến API để lấy sản phẩm theo thương hiệu
    const res = await request.get(`/api/Shoe/brand?brand=${brand}`);
    // Lọc ra các sản phẩm không nằm trong danh sách loại trừ và giới hạn số lượng 6 sản phẩm
    return res.data
      .filter(
        (item) =>
          item.name !== "Nike Downshifter 13" &&
          item.name !== "Nike Youth React Presto Extreme" &&
          item.name !== "NikeCourt Legacy" &&
          item.name !==
            "PUMA x LAMELO BALL MB.03 Halloween Men's Basketball Shoes"
      )
      .slice(0, 6) // Lấy 6 sản phẩm đầu tiên
      .map((item) => {
        // Thêm đường dẫn đầy đủ cho ảnh sản phẩm
        item.imageUrl = `${process.env.REACT_APP_API_URL}/${item.imageUrl}`;
        // Tính giá gốc từ giá đã giảm
        const discountedPrice = item.price;
        item.originalPrice = discountedPrice.toLocaleString("vi-VN");
        item.price = Math.round(
          discountedPrice * (1 - item.discount / 100)
        ).toLocaleString("vi-VN");
        return item; // Trả về thông tin sản phẩm đã xử lý
      });
  } catch (error) {
    console.log(error); // In lỗi nếu có
  }
};

// Hàm lấy sản phẩm hợp tác từ API
export const getCollaborationProduct = async () => {
  try {
    // Gửi yêu cầu GET đến API để lấy sản phẩm hợp tác
    const res = await request.get(`/api/Shoe/collaboration`);
    return res.data; // Trả về dữ liệu sản phẩm hợp tác
  } catch (error) {
    console.log(error); // In lỗi nếu có
  }
};

// Hàm lấy các đánh giá từ API
export const getReviews = async () => {
  try {
    // Gửi yêu cầu GET để lấy đánh giá từ API
    const res = await request.get(`/api/Comment/home`);
    // Xử lý và thêm đường dẫn cho avatar người dùng
    const array = res.data.map((item) => {
      item.userAvatar = `${process.env.REACT_APP_API_URL}/${item.userAvatar}`;
      return item; // Trả về đánh giá đã xử lý
    });
    // Trộn ngẫu nhiên mảng đánh giá và lấy 3 đánh giá đầu tiên
    const randomArray = [...array].sort(() => 0.5 - Math.random());
    return randomArray.slice(0, 3); // Trả về 3 đánh giá ngẫu nhiên
  } catch (error) {
    console.log(error); // In lỗi nếu có
  }
};
