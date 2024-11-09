import DataTable from "../../components/dataTable/DataTable";
import "./Orders.scss";
import { useEffect, useState } from "react";
import { Alert, Backdrop, CircularProgress, Slide, Snackbar } from "@mui/material";
import * as adminOrdersService from "../../../services/adminOrdersService"

const columns = [
  { field: "id", headerName: "Order Id", width: 130 },
  {
    field: "userId",
    type: "string",
    headerName: "User Id",
    width: 110,
  },
  {
    field: "userName",
    type: "string",
    headerName: "User Name",
    width: 110,
  },
  {
    field: "userEmail",
    type: "string",
    headerName: "User Email",
    width: 150,
  },
  {
    field: "totalItems",
    type: "string",
    headerName: "Total Items",
    width: 90,
  },
  {
    field: "totalPrice",
    type: "string",
    headerName: "Total Price",
    width: 90,
  },
  {
    field: "status",
    type: "string",
    headerName: "Order Status",
    width: 100,
  },
  {
    field: "paymentMethod",
    type: "string",
    headerName: "Payment",
    width: 80,
  },
  {
    field: "orderDate",
    type: "string",
    headerName: "Order At",
    width: 100,
  },
];
const status = ["Pending", "Confirmed", "Shipped", "Delivered", "Canceled"]
const inputs =[
  {
    field: "status",
    type: "selectOnly",
    label: "Status",
    require: true,
    selectData: status
  },
  ]

const Orders =  () => {
  const [data, setData] = useState([])
  const [isLoading, setIsLoading] = useState(true)
  const [openBackDrop, setOpenBackDrop] = useState(false)
  const [openToastMessage, setOpenToastMessage] = useState(false)
  const [typeToastMessage, setTypeToastMessage] = useState("")
  const [titleToastMessage, setTitleToastMessage] = useState("")

  const fetchData = async () => {
    try {
      const res = await adminOrdersService.getAllOrders()
      setData(res); // Lưu dữ liệu vào state
    } catch (error) {
      console.log(error);
    }
    finally{
      setIsLoading(false)
    }
  };
  // Gọi API trong useEffect
  useEffect(() => {
    fetchData(); // Gọi hàm fetchData
  }, []); // Chỉ chạy một lần sau khi component mount
  
  function SlideTransition(props) {
    return <Slide {...props} direction="left" />;
  }

  const handleClose = (event, reason) => {
    if (reason === 'clickaway') {
      return;
    }

    setOpenToastMessage(false);
  }
  return (
    <div className="orders">
    <div className="info">
      <h1>Orders</h1>
    </div>
    {isLoading ? (
      <CircularProgress color="inherit" />
    ) : (
      <DataTable 
      slug="orders" 
      updateSlug="order"
      columns={columns} 
      rows={data}
      inputs={inputs} 
      fetchData={fetchData}
      setOpenBackDrop={setOpenBackDrop}
      setOpenToastMessage={setOpenToastMessage}
      setTypeToastMessage={setTypeToastMessage}
      setTitleToastMessage={setTitleToastMessage}
      />
    )}

    {openBackDrop && (<Backdrop
        sx={(theme) => ({ color: '#fff', zIndex: theme.zIndex.drawer + 1 })}
        open={openBackDrop}
      >
        <CircularProgress color="inherit" />
      </Backdrop>)}
   
    {openToastMessage && (<Snackbar
        open={openToastMessage}
        autoHideDuration={3000}
        onClose={handleClose}
        TransitionComponent={SlideTransition}
        anchorOrigin={{ vertical: 'top', horizontal: 'right' }}
      >
        <Alert severity={typeToastMessage} sx={{ width: '100%' }}>
          {titleToastMessage}
        </Alert>
      </Snackbar>)}
  </div>
  );
};

export default Orders;