import DataTable from "../../components/dataTable/DataTable";
import "./Discounts.scss";
import { useEffect, useState } from "react";
import Add from "../../components/add/Add";
import { Alert, Backdrop, CircularProgress, Slide, Snackbar } from "@mui/material";
import * as adminDiscountsService from "../../../services/adminDiscountsService"

const columns = [
  { field: "id", headerName: "ID", width: 130 },
  {
    field: "code",
    type: "string",
    headerName: "Code",
    width: 110,
  },
  {
    field: "percentage",
    type: "string",
    headerName: "Percentage",
    width: 100,
  },
  {
    field: "isPublic",
    type: "boolean",
    headerName: "Is Public",
    width: 80,
  },
  {
    field: "amount",
    type: "string",
    headerName: "Amount",
    width: 80,
  },
  {
    field: "type",
    type: "string",
    headerName: "Type",
    width: 80,
  },
  {
    field: "quantity",
    type: "string",
    headerName: "Quantity",
    width: 80,
  },
  {
    field: "maximumDiscount",
    type: "string",
    headerName: "Maximum Discount",
    width: 100,
  },
  {
    field: "minimumOrder",
    type: "string",
    headerName: "Minimum Order",
    width: 100,
  },
  {
    field: "expiryDate",
    headerName: "Expiry Date",
    width: 120,
    type: "string",
  },
];
const isPublic = ["Public", "Non Public"]
const types = ["Ship", "Order"]
const inputs =[
  {
    field: "code",
    type: "text",
    headerName: "Code",
    require: true,
  },
  {
    field: "amount",
    type: "text",
    headerName: "Amount",
    require: true,
  },
  {
    field: "minimumOrder",
    type: "text",
    headerName: "Minimum Order",
    require: true,
  },
  {
    field: "percentage",
    type: "text",
    headerName: "Percentage",
    require: true,
  },
  {
    field: "maximumDiscount",
    type: "text",
    headerName: "Maximum Discount",
    require: true,
  },
  {
    field: "quantity",
    type: "text",
    headerName: "Quantity",
    require: true,
  },
  {
    field: "type",
    type: "selectOnly",
    label: "Type",
    selectData: types,
    require: true,
  },
  {
    field: "isPublic",
    type: "selectOnly",
    label: "Is Public",
    selectData: isPublic,
    require: true,
  },
  {
    field: "expiryDate",
    type: "date",
    headerName: "Expiry Date",
    require: true,
  },
  ]

const Users =  () => {
  const [open, setOpen] = useState(false);
  const [data, setData] = useState([])
  const [isLoading, setIsLoading] = useState(true)
  const [openBackDrop, setOpenBackDrop] = useState(false)
  const [openToastMessage, setOpenToastMessage] = useState(false)
  const [typeToastMessage, setTypeToastMessage] = useState("")
  const [titleToastMessage, setTitleToastMessage] = useState("")

  const fetchData = async () => {
    try {
      const res = await adminDiscountsService.getAllDiscounts()
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
    <div className="discounts">
    <div className="info">
      <h1>Discounts</h1>
      <button onClick={() => setOpen(true)}>Add New Discount</button>
    </div>
    {isLoading ? (
      <CircularProgress color="inherit" />
    ) : (
      <DataTable 
      slug="discounts" 
      updateSlug="discount"
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
    {open && <Add 
    slug="discount" 
    setOpen={setOpen} 
    fetchData={fetchData}
    setOpenBackDrop={setOpenBackDrop}
    setOpenToastMessage={setOpenToastMessage}
    setTypeToastMessage={setTypeToastMessage}
    setTitleToastMessage={setTitleToastMessage}
    inputs={inputs}/>}

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

export default Users;