import request from '../utils/request.js'

export const getProducts = async () => {
    try {
        const res = await request.get(`/api/Shoe/home`)
        return res.data.map((item) => {
            item.imageUrl = `${process.env.REACT_APP_API_URL}/${item.imageUrl}`
            item.price = item.price.toLocaleString("vi-VN")
            return item
        }) 
    } catch (error) {
        console.log(error);
    }
}

export const getProductsByBrand = async (brand) => {
    try {
        const res = await request.get(`/api/Shoe/brand?brand=${brand}`)
        return res.data.filter((item) => 
            item.name !== "Nike Downshifter 13"
            && item.name !== "Nike Youth React Presto Extreme"
            && item.name !== "NikeCourt Legacy"
            && item.name !== "PUMA x LAMELO BALL MB.03 Halloween Men's Basketball Shoes").map((item) => {
            item.imageUrl = `${process.env.REACT_APP_API_URL}/${item.imageUrl}`
            const discountedPrice = item.price;
            item.originalPrice = Math.round((discountedPrice / (1 - item.discount / 100))).toLocaleString("vi-VN")
            item.price = discountedPrice.toLocaleString("vi-VN")
            return item
        })
    } catch (error) {
        console.log(error);
    }
}

export const getCollaborationProduct = async () => {
    try {
        const res = await request.get(`/api/Shoe/collaboration`)
        return res.data  
    } catch (error) {
        console.log(error);
    }
}

export const getReviews = async () => {
    try {
        const res = await request.get(`/api/Comment/home`)
        const array = res.data.map((item) => {
            item.userAvatar = `${process.env.REACT_APP_API_URL}/${item.userAvatar}`
            return item
        })
        const randomArray = [...array].sort(() => 0.5 - Math.random())
        return randomArray.slice(0,3)    
    } catch (error) {
        console.log(error);
    }
}

