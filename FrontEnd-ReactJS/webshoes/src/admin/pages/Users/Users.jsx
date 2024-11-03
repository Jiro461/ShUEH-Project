
import DataTable from "../../components/dataTable/DataTable";
import "./Users.scss";
import { useEffect, useState } from "react";
import Add from "../../components/add/Add";
import { Alert, Backdrop, CircularProgress, Slide, Snackbar } from "@mui/material";
import * as adminUsersService from "../../../services/adminUsersService"
// import { useQuery } from "@tanstack/react-query";

const columns = [
  { field: "id", headerName: "ID", width: 130 },
  {
    field: "avatarUrl",
    headerName: "Avatar",
    width: 80,
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
    field: "emailConfirmed",
    type: "boolean",
    headerName: "Email Confirmed",
    width: 80,
  },
  {
    field: "isExternalLogin",
    type: "boolean",
    headerName: "External Login",
    width: 80,
  },
  {
    field: "role",
    type: "string",
    headerName: "Role",
    width: 100,
  },
  {
    field: "createDate",
    headerName: "Created At",
    width: 110,
    type: "string",
  },
];

const roles = ["Admin", "User"]
const inputs =[
  {
    field: "firstname",
    type: "text",
    headerName: "First name",
  },
  {
    field: "lastname",
    type: "text",
    headerName: "Last name",
  },
  {
    field: "email",
    type: "text",
    headerName: "Email",
  },
  {
    field: "phone",
    type: "text",
    headerName: "Phone",
  },
  {
    field: "role",
    label: "role",
    type: "selectOnly",
    selectData: roles,
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
      const res = await adminUsersService.getAllUsers()
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
    <div className="admin-products">
    <div className="info">
      <h1>Users</h1>
      <button onClick={() => setOpen(true)}>Add New User</button>
    </div>
    {isLoading ? (
      <CircularProgress color="inherit" />
    ) : (
      <DataTable 
      slug="user" 
      updateSlug="user"
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
    slug="user" 
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