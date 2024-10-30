
import DataTable from "../../components/dataTable/DataTable";
import "./Orders.scss";
import { useEffect, useState } from "react";
import Add from "../../components/add/Add";
import { userRows } from "../../data";
import axios from "axios";
// import { useQuery } from "@tanstack/react-query";

const columns = [
  { field: "id", headerName: "ID", width: 90 },
  {
    field: "img",
    headerName: "Avatar",
    width: 100,
    renderCell: (params) => {
      return <img src={params.row.img || "/noavatar.png"} alt="" />;
    },
  },
  {
    field: "firstName",
    type: "string",
    headerName: "First name",
    width: 110,
  },
  {
    field: "lastName",
    type: "string",
    headerName: "Last name",
    width: 110,
  },
  {
    field: "email",
    type: "string",
    headerName: "Email",
    width: 150,
  },
  {
    field: "phone",
    type: "string",
    headerName: "Phone",
    width: 150,
  },
  {
    field: "createdAt",
    headerName: "Created At",
    width: 150,
    type: "string",
  },
  {
    field: "verified",
    headerName: "Verified",
    width: 150,
    type: "boolean",
  },
];

const Orders = () => {
  const [open, setOpen] = useState(false);
  const [data, setData] = useState([])
  const [isLoading, setIsLoading] = useState(true)

  // Gọi API trong useEffect
  useEffect(() => {
    const fetchData = async () => {
      try {
        const res = await axios.get("http://localhost:5118/api/Account/get-users-info");
        setData(res.data); // Lưu dữ liệu vào state
      } catch (err) {
        console.error(err); // Xử lý lỗi nếu có
      } finally{
        setIsLoading(false)
      }
    };

    fetchData(); // Gọi hàm fetchData
  }, []); // Chỉ chạy một lần sau khi component mount
  return (
    <div className="orders">
      <div className="info">
        <h1>Orders</h1>
        <button onClick={() => setOpen(true)}>Add New Order</button>
      </div>
      {isLoading ? (
        "Loading..."
      ) : (
        <DataTable slug="orders" columns={columns} rows={data} />
      )}
      {open && <Add slug="order" columns={columns} setOpen={setOpen} />}
    </div>
  );
};

export default Orders;