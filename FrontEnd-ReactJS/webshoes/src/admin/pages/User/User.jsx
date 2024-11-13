import { useParams } from "react-router-dom"
import Single from "../../components/single/Single"
import { singleUser } from "../../data"
import "./User.scss"
import { useEffect, useState } from "react"
import * as singleService from "../../../services/singleService"
import { CircularProgress } from "@mui/material"

const User = () => {
  const {id} = useParams()
  const [data, setData] = useState({})
  const [isLoading, setIsLoading] = useState(true)

  // Gọi API trong useEffect
  useEffect(() => {
    const fetchData = async () => {
      try {
      const res = await singleService.getSingleUser(id)
      
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
  
  //Fetch data and send to Single Component
  
  return (
    <div className="user">
        {isLoading ? (
      <CircularProgress color="inherit" />
    ) : (
      <Single {...data} />
    )}
    </div>
  )
}

export default User