
import { useState, useEffect } from "react";
import "./AdminProducts.scss";
import DataTable from "../../components/dataTable/DataTable";
import Add from "../../components/add/Add";
import { GridColDef } from "@mui/x-data-grid";
import { products } from "../../data";
import axios from "axios";

const columns = [
  { field: "id", headerName: "ID", width: 90 },
  {
    field: "imageUrl",
    headerName: "Image",
    width: 100,
    renderCell: (params) => {
      return <img className="admin-product-img" src={params.row.imageUrl || "/noavatar.png"} alt="" />;
    },
  },
  {
    field: "name",
    type: "string",
    headerName: "Name",
    width: 110,
  },
  {
    field: "brand",
    type: "string",
    headerName: "Brand",
    width: 110,
  },
  {
    field: "gender",
    type: "string",
    headerName: "Gender",
    width: 100,
  },
  {
    field: "category",
    type: "string",
    headerName: "Category",
    width: 150,
  },
  {
    field: "price",
    type: "string",
    headerName: "Price",
    width: 100,
  },
  {
    field: "isSale",
    type: "boolean",
    headerName: "Is Sale",
    width: 90,
  },
  {
    field: "discount",
    type: "string",
    headerName: "Discount",
    width: 90,
  },
  {
    field: "createdAt",
    headerName: "Created At",
    width: 150,
    type: "string",
  },
];

const AdminProducts = () => {
  const [open, setOpen] = useState(false);
  const [data, setData] = useState([])
  const [isLoading, setIsLoading] = useState(true)

  // Gọi API trong useEffect
  useEffect(() => {
    const fetchData = async () => {
      try {
        const res = await axios.get("http://localhost:5118/api/Shoe/all");
        setData(validateData(res.data)); // Lưu dữ liệu vào state
      } catch (err) {
        console.error(err); // Xử lý lỗi nếu có
      } finally{
        setIsLoading(false)
      }
    };

    fetchData(); // Gọi hàm fetchData
  }, []); // Chỉ chạy một lần sau khi component mount

  function validateData(data){
    return data.map(item => {
      if(item.gender === 1){
        item.gender = "Male"
      }
      if(item.gender === 2){
        item.gender = "Female"
      }
      if(!item.imageUrl.includes("http://localhost:5118/")){
        item.imageUrl = `http://localhost:5118/${item.imageUrl}`
      }
      return item
    })
  }
  return (
    <div className="admin-products">
    <div className="info">
      <h1>Products</h1>
      <button onClick={() => setOpen(true)}>Add New Products</button>
    </div>
    {isLoading ? (
      "Loading..."
    ) : (
      <DataTable slug="products" columns={columns} rows={data} />
    )}
    {open && <Add slug="product" columns={columns} setOpen={setOpen} />}
  </div>
  );
};

export default AdminProducts;