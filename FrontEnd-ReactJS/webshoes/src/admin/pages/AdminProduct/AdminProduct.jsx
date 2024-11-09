import { useEffect, useState } from "react";
import Single from "../../components/single/Single"
import { singleProduct } from "../../data"
import "./AdminProduct.scss"
import axios from "axios";
import { useParams } from "react-router-dom";

const Product = () => {
  const {id} = useParams()
  const [open, setOpen] = useState(false);
  const [data, setData] = useState({})
  const [isLoading, setIsLoading] = useState(true)

  // Gọi API trong useEffect
  useEffect(() => {
    const fetchData = async () => {
      try {
        const url = `http://localhost:5118/api/shoe/${id}`
        const res = await axios.get(url);
        setData(validateData(res.data)); // Lưu dữ liệu vào state
      } catch (err) {
        console.error(err); // Xử lý lỗi nếu có
      } finally{
        setIsLoading(false)
      }
    };

    fetchData(); // Gọi hàm fetchData
  }, []); // Chỉ chạy một lần sau khi component mount
  //Fetch data and send to Single Component
  function validateData(data){
      if(!data.imageUrl.includes("http://localhost:5118/")){    
        return data.imageUrl = `http://localhost:5118/${data.imageUrl}`
      }
  }
  return (
    <div className="product">
        {false ? (
      <p>Loading...</p> // Hiển thị loading khi đang tải dữ liệu
    ) : (
      <Single {...singleProduct} />
    )}
    </div>
  )
}

export default Product