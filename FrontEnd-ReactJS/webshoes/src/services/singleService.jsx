import request from '../utils/request.js'

export const getSingleProduct = async (id) => {
    try {
        const res = await request.get(`/api/Shoe/admin/${id}`)
        return {
            id: res.data.shoeDTO.id,
            name: res.data.shoeDTO.name,
            imageUrl: `${process.env.REACT_APP_API_URL}/${res.data.shoeDTO.imageUrl}`,
            info: {
                brand: res.data.shoeDTO.brand,
                price: res.data.shoeDTO.price,
                salePrice: res.data.shoeDTO.salePrice,
                material: res.data.shoeDTO.material,
                category: res.data.shoeDTO.category,
                averageRating: res.data.shoeDTO.averageRating,
                sold: res.data.shoeDTO.sold,
            },
            chart: {
                dataKeys: [
                    { name: "visits", color: "#82ca9d" },
                    { name: "orders", color: "#8884d8" },
                ],
                data: res.data.chart
            }
        }
    } catch (error) {
        console.log(error);
    }
}

export const getSingleUser = async (id) => {
    const compareDates = (dateString) => {
        // Chuyển chuỗi thành đối tượng Date
        const inputDate = new Date(dateString);
        
        // Lấy ngày hiện tại
        const currentDate = new Date();
        
        // Tính sự khác biệt giữa ngày hiện tại và ngày đã cho (theo mili giây)
        const diffInTime = currentDate - inputDate;
        
        // Chuyển mili giây thành ngày
        const diffInDays = Math.floor(diffInTime / (1000 * 3600 * 24));
      
        // Trả về số ngày
        return diffInDays;
      };
    try {
        const activities = await request.get(`/api/Notification/admin/user/${id}`)
        const user = await request.get(`/api/Account/user/${id}`)
        return {
            id: user.data.id,
            name: user.data.profileName,
            imageUrl: `${process.env.REACT_APP_API_URL}/${user.data.avatarUrl}`,
            info: {
                firstname: user.data.firstName,
                lastname: user.data.lastName,
                email: user.data.email,
                gender: user.data.gender ? "Male" : "Female",
                
              },
              activities: activities.data.map((activity) => {
                const daysAgo = compareDates(activity.createDate);
                return {
                    text: activity.adminMessage,
                    time: activity.createDate
                }
              }),
        }
    } catch (error) {
        console.log(error);
    }
}