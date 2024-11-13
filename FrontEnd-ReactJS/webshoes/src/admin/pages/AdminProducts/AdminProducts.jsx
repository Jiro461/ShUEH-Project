
import { useState, useEffect } from "react";
import "./AdminProducts.scss";
import DataTable from "../../components/dataTable/DataTable";
import Add from "../../components/add/Add";
import * as adminProductsService from "../../../services/adminProductsService"
import { Alert, Backdrop, CircularProgress, Slide, SliderRail, Snackbar } from "@mui/material";

const columns = [
  { field: "id", headerName: "ID", width: 130 },
  {
    field: "imageUrl",
    headerName: "Image",
    width: 80,
    renderCell: (params) => {
      return <img className="admin-product-img" src={params.row.imageUrl || "/noavatar.png"} alt="" />;
    },
  },
  {
    field: "name",
    type: "string",
    headerName: "Name",
    width: 150,
    editable: true
  },
  {
    field: "brand",
    type: "string",
    headerName: "Brand",
    width: 80,
  },
  {
    field: "price",
    type: "string",
    headerName: "Price",
    width: 100,
  },
  {
    field: "sold",
    type: "string",
    headerName: "Sold",
    width: 60,
  },
  {
    field: "discount",
    type: "string",
    headerName: "Discount",
    width: 80,
  },
  {
    field: "isSale",
    type: "boolean",
    headerName: "Is Sale",
    width: 80,
  },
  {
    field: "averageRating",
    type: "string",
    headerName: "Average Rating",
    width: 80,
  },
  {
    field: "totalRatings",
    type: "string",
    headerName: "Total Ratings",
    width: 80,
  },
];

const genders = ["Female", "Male", "Unisex"]
  const sizes = ["36", "37", "38", "39", "40", "41", "42", "43", "44", "45"]
  const brands = ["Nike", "Adidas", "Puma", "Reebok", "Under Armour", "Converse"];
  const materials = ["Leather", "Fabric", "Foam", "Synthetic", "Mesh", "Canvas", "Rubber"];
  const categories = ["Running", "Football", "Basketball", "Tennis", "Gym & Training"];
  const seasons = ["Spring","Summer", "Fall", "Winter"];
  const colors = ["Blue", "Black", "White", "Purple", "Red", "Green", "Yellow", "Orange", "Pink", "Grey", "Brown"];
  const inputs =[
    {
      field: "name",
      type: "text",
      headerName: "Name",
      require: true
    },
    {
      field: "description",
      type: "text",
      headerName: "Description",
      require: true
    },
    {
      field: "price-discount",
      field_price: "price",
      headerName_price: "Price",
      field_discount: "discount",
      headerName_discount: "Discount",
      type: "text",
      require: true
    },
    {
      field: "brand",
      type: "selectOnly",
      label: "Brand",
      selectData: brands,
      require: true
    },
    {
      field: "gender",
      label: "Gender",
      type: "selectOnly",
      selectData: genders,
      require: true
    },
    {
      field: "category",
      label: "Category",
      type: "selectOnly",
      selectData: categories,
      require: true
    },
    {
      field: "colors",
      label: "Colors",
      few: "color",
      type: "selectMultiple",
      selectData: colors,
      require: true
    },
    {
      field: "materials",
      label: "Materials",
      few: "material",
      type: "selectMultiple",
      selectData: materials,
      require: true
    },
    {
      field: "seasons",
      label: "Seasons",
      few: "season",
      type: "selectMultiple",
      selectData: seasons,
      require: true
    },
    {
      field: "sizes",
      label: "Quantities per size",
      type: "selectMultiple",
      selectData: sizes,
      require: true
    },
    {
      field_mainImage: "mainImage",
      label_mainImage: "Main Image",
      field_additionalImages: "additionalImages",
      label_additionalImages: "Additional Images",
      type: "file",
    },
    ]

const AdminProducts = () => {
  const [open, setOpen] = useState(false);
  const [data, setData] = useState([])
  const [isLoading, setIsLoading] = useState(true)
  const [openBackDrop, setOpenBackDrop] = useState(false)
  const [openToastMessage, setOpenToastMessage] = useState(false)
  const [typeToastMessage, setTypeToastMessage] = useState("")
  const [titleToastMessage, setTitleToastMessage] = useState("")

  const fetchData = async () => {
    try {
      const res = await adminProductsService.getAllProducts()
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
      <h1>Products</h1>
      <button onClick={() => setOpen(true)}>Add New Product</button>
    </div>
    {isLoading ? (
      <CircularProgress color="inherit" />
    ) : (
      <DataTable 
      slug="products" 
      updateSlug="product"
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
    slug="product" 
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

export default AdminProducts;