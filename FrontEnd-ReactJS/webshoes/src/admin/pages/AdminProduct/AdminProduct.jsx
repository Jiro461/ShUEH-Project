import { useEffect, useState } from "react";
import Single from "../../components/single/Single"
import { singleProduct } from "../../data"
import "./AdminProduct.scss"
import axios from "axios";
import { useParams } from "react-router-dom";
import * as singleService from "../../../services/singleService"
import { CircularProgress } from "@mui/material";

const Product = () => {
  const {id} = useParams()
  const [data, setData] = useState({})
  const [isLoading, setIsLoading] = useState(true)

  // Gọi API trong useEffect
  useEffect(() => {
    const fetchData = async () => {
      try {
        const res = await singleService.getSingleProduct(id)
        console.log(res);
        setData(res); // Lưu dữ liệu vào state
      } catch (err) {
        console.error(err); // Xử lý lỗi nếu có
      } finally{
        setIsLoading(false)
      }
    };

    fetchData(); // Gọi hàm fetchData
  }, []); // Chỉ chạy một lần sau khi component mount

  return (
    <div className="admin-product">
        {isLoading ? (
      <CircularProgress color="inherit" />
    ) : (
      <Single {...data} />
    )}
    </div>
  )
}

export default Product