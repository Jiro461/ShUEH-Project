import request from '../../src/utils/request.js'

export const getProducts = async (number) => {
    try {
        const res = await request.get(`Shoe/home/${number}`)
        return res.data
    } catch (error) {
        console.log(error);
    }
}