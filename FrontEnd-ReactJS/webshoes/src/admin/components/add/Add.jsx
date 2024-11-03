import "./add.scss";
import OutlinedInput from '@mui/material/OutlinedInput';
import InputLabel from '@mui/material/InputLabel';
import MenuItem from '@mui/material/MenuItem';
import FormControl from '@mui/material/FormControl';
import Select from '@mui/material/Select';
import React, { useState } from "react";
import TextField from '@mui/material/TextField';
import Backdrop from '@mui/material/Backdrop';
import CircularProgress from '@mui/material/CircularProgress';
import * as adminProductsService from "../../../services/adminProductsService"
import { Alert, InputAdornment, Slide, Snackbar } from "@mui/material";

const Add = (props) => {
  const [genderUi, setGenderUi] = useState()
  const [shoeData, setShoeData] = useState({
    name: '',
    brand: '',
    gender: 0,
    materials: [],
    category: '',
    imageUrl: '',
    description: '',
    price: 0,
    isSale: false,
    discount: 0,
    colors: [],
    seasons: [],
    sizes: [
      {
        size: 36,
        quantity: 0
      },
      {
        size: 37,
        quantity: 0
      },
      {
        size: 38,
        quantity: 0
      },
      {
        size: 39,
        quantity: 0
      },
      {
        size: 40,
        quantity: 0
      },
      {
        size: 41,
        quantity: 0
      },
      {
        size: 42,
        quantity: 0
      },
      {
        size: 43,
        quantity: 0
      },
      {
        size: 44,
        quantity: 0
      },
      {
        size: 45,
        quantity: 0
      },
    ],
    mainImage: null, // State for the main image
    additionalImages: [],
  });
  const [users, setUsers] = useState()
console.log(shoeData);
  const ITEM_HEIGHT = 48;
const ITEM_PADDING_TOP = 8;
const MenuProps = {
  PaperProps: {
    style: {
      maxHeight: ITEM_HEIGHT * 4.5 + ITEM_PADDING_TOP,
      width: 250,
    },
  },
};
const handleMainImageChange = (e) => {
  const selectedFile = e.target.files[0];
  if (selectedFile && (selectedFile.name.endsWith('png') || 
                       selectedFile.name.endsWith('jpg') || 
                       selectedFile.name.endsWith('jpeg'))) {
    setShoeData((prevData) => ({
      ...prevData,
      imageUrl: URL.createObjectURL(selectedFile),
      mainImage: selectedFile,
    }));
  }
};
const handleAdditionalImagesChange = (e) => {
  const files = Array.from(e.target.files);
  const validImages = files.filter(file => 
    file.name.endsWith('png') || 
    file.name.endsWith('jpg') || 
    file.name.endsWith('jpeg')
  );
  
  const imageUrls = validImages.map(file => URL.createObjectURL(file));
  
  setShoeData((prevData) => ({
    ...prevData,
    additionalImages: files ? Array.from(files) : [],
  }));
};

const handleInputChange = (event) => {
  const { name, value } = event.target;
  setShoeData((prevValues) => ({
    ...prevValues,
    [name]: value,
  }));
};

const handlePriceDiscountChange = (event) => {
  const { name, value } = event.target;

  if (name === "price") {
    // Loại bỏ dấu phẩy khỏi chuỗi trước khi kiểm tra
    const rawValue = value.replace(/,/g, "");
    
    // Chỉ cho phép nhập số nguyên dương hoặc chuỗi rỗng
    if (/^\d*$/.test(rawValue)) {
      setShoeData((prevValues) => ({
        ...prevValues,
        [name]: rawValue, // Lưu trữ giá trị thô không có dấu phẩy
      }));
    }
  } else if (name === "discount") {
    // Xử lý discount cho giá trị từ 1 đến 100
    const numValue = parseInt(value, 10);
    if ((/^\d*$/.test(value) && value === "") || (numValue >= 1 && numValue <= 100)) {
      setShoeData((prevValues) => ({
        ...prevValues,
        [name]: value,
      }));
    }
  }
};


const handleSelectOnlyChange = (event, fieldName) => {
  const { value } = event.target;
  if (fieldName === "gender"){
    setGenderUi(value)
    if (value === "Female"){
      setShoeData((prevValues) => ({
        ...prevValues,
        [fieldName]: 0,
      }));
    } else if (value === "Male"){
      setShoeData((prevValues) => ({
        ...prevValues,
        [fieldName]: 1,
      }));
    } else {
      setShoeData((prevValues) => ({
        ...prevValues,
        [fieldName]: 2,
      }));
    }
  } else {
    setShoeData((prevValues) => ({
      ...prevValues,
      [fieldName]: value,
    }));
  }
};

const handleSelectMultipleChange = (event, field, few) => {
  const value = event.target.value; // Get the selected seasons
  const newArray = value.map(item => ({ [few] : item })); // Create objects with key 'season'
  setShoeData((prevValues) => ({
    ...prevValues,
    [field]: newArray, // Update the seasons state
  }));
};


const handleSizeChange = (index, field) => (event) => {
  const { value } = event.target; // Lấy giá trị mới từ ô input
  if (/^\d*$/.test(value) || value === '') { // Cho phép chỉ số và trường trống
    const numValue = Number(value);
    if (value === '' || (Number.isInteger(numValue) && numValue > 0)) {
      setShoeData((prevData) => {
        const updatedSizes = [...prevData.sizes];
        updatedSizes[index] = {
          ...updatedSizes[index],
          [field]: value,
        };
        return {
          ...prevData,
          sizes: updatedSizes,
        };
      });
    }
  }
};

  const handleSubmit = async (e) => {
    e.preventDefault();
    props.setOpenBackDrop(true)

    const res = await adminProductsService.addNewProduct(shoeData)  
    //goi api khac
    
    await props.fetchData()
    props.setOpenToastMessage(true) 
    props.setTypeToastMessage(res.type)
    props.setTitleToastMessage(res.message)
    props.setOpenBackDrop(false)
    if (res.status !== 400){
      props.setOpen(false)
    }
  };
  return (
    <div className="add">
      <div className="add-modal">
        <span className="close" onClick={() => props.setOpen(false)}>
          X
        </span>
        <h1>Add new {props.slug}</h1>
        <form onSubmit={handleSubmit}>  
          {props.inputs
            .filter((item) => item.field !== "id" && item.field !== "img")
            .map((input, index) => (
              <div key={index} className="item">

              {input.type === "text" && input.field !== "price-discount" && (
                <>
                  <label>
                    {input.headerName}
                    {input.require && <span style={{color: "red"}}> *</span>}
                  </label>                  
                  <TextField
                          label={input.field}
                          type="text"
                          variant="outlined"
                          name={input.field}
                          value={shoeData[input.field] || ''}
                          onChange={handleInputChange} // Cập nhật quantity
                        />
                </>
              )}

              {input.type === "text" && input.field === "price-discount" && (
                <div style={{display: "flex", gap: 10}}>
                  <div style={{display: "flex", flexDirection: "column", gap: 10}}>
                  <label>
                    {input.headerName_price}
                    {input.require && <span style={{color: "red"}}> *</span>}
                  </label> 
                  <TextField
                          sx={{width: "150px"}}
                          label={input.field_price}
                          type="text"
                          variant="outlined"
                          name={input.field_price}
                          value={shoeData[input.field_price] ? shoeData.price.replace(/\B(?=(\d{3})+(?!\d))/g, ",") : ''}
                          slotProps={{
                            input: {
                              endAdornment: <InputAdornment position="end">vnđ</InputAdornment>,
                            },
                          }}
                          onChange={handlePriceDiscountChange} // Cập nhật quantity
                        />
                  </div>

                  <div style={{display: "flex", flexDirection: "column", gap: 10}}>
                  <label>{input.headerName_discount}</label>
                  <TextField
                          sx={{width: "100px"}}
  
                          type="text"
                          variant="outlined"
                          name={input.field_discount}
                          value={shoeData[input.field_discount] || ''}
                          slotProps={{
                            input: {
                              endAdornment: <InputAdornment position="end">%</InputAdornment>,
                            },
                          }}
                          onChange={handlePriceDiscountChange} // Cập nhật quantity
                        />
                  </div>
                </div>
              )}

              {input.type === "selectOnly" && input.field !== "gender" && (
                <>
                <label>
                    {input.label}
                    {input.require && <span style={{color: "red"}}> *</span>}
                  </label> 
                  <FormControl sx={{ width: 300 }}>
                <InputLabel id={`label-${input.field}`}>{input.field}</InputLabel>
                <Select
                  labelId={`label-${input.field}`}
                  id={`select-${input.field}`}
                  name={input.field}
                  value={shoeData[input.field] || ""}
                  onChange={(e) => handleSelectOnlyChange(e, input.field)}
                  input={<OutlinedInput label={input.label} />}
                  MenuProps={MenuProps}
                >
                  {input.selectData.map((select) => (
                    <MenuItem
                      key={select}
                      value={select}
                    >
                      {select}
                    </MenuItem>
                  ))}
                </Select>
              </FormControl>
                </>
              )}

              {input.type === "selectOnly" && input.field === "gender" && (
                <>
                <label>
                    {input.label}
                    {input.require && <span style={{color: "red"}}> *</span>}
                  </label> 
                  <FormControl sx={{ width: 300 }}>
                <InputLabel id={`label-${input.field}`}>{input.field}</InputLabel>
                <Select
                  labelId={`label-${input.field}`}
                  id={`select-${input.field}`}
                  name={input.field}
                  value={genderUi || ""}
                  onChange={(e) => handleSelectOnlyChange(e, input.field)}
                  input={<OutlinedInput label={input.label} />}
                  MenuProps={MenuProps}
                >
                  {input.selectData.map((select) => (
                    <MenuItem
                      key={select}
                      value={select}
                    >
                      {select}
                    </MenuItem>
                  ))}
                </Select>
              </FormControl>
                </>
              )}

              {input.type === "selectMultiple" && input.field !== "sizes" && (
                <>
                <label>
                    {input.label}
                    {input.require && <span style={{color: "red"}}> *</span>}
                  </label> 
                <FormControl sx={{ width: 300 }}>
                <InputLabel id={`label-${input.field}`}>{input.field}</InputLabel>
                <Select
                  labelId={`label-${input.field}`}
                  id={`select-${input.field}`}
                  multiple
                  name={input.field}
                  value={shoeData[input.field].map(item => item[input.few]) || []}
                  onChange={(e) => handleSelectMultipleChange(e, input.field, input.few)}
                  input={<OutlinedInput label={input.label} />}
                  MenuProps={MenuProps}
                >
                  {input.selectData.map((select) => (
                    <MenuItem
                      key={select}
                      value={select}
                    >
                      {select}
                    </MenuItem>
                  ))}
                </Select>
              </FormControl>
                </>
              )}

              {input.field === "sizes" && (
                <>
                <label>
                    {input.label}
                    {input.require && <span style={{color: "red"}}> *</span>}
                  </label> 
                <div className="sizes">
                  {shoeData?.sizes.map((item, index) => (
                    <div key={index} className="size-item">
                        <TextField
                          id="quantities-per-size"
                          label={item.size}
                          type="number"
                          variant="outlined"
                          value={item?.quantity}
                          slotProps={{
                            pattern: "[0-9]*"
                          }}
                          onChange={handleSizeChange(index, 'quantity')} // Cập nhật quantity
                        />
                      </div>
                  ))}
                  </div>
                </>
              )}

              {input.type === "file" && (
                  <>
                    <label>Upload Images</label>
                      <div className="file-container">
                        <div className="file-item">
                          <label htmlFor="mainImage" className="preview preview-main-image">
                          {shoeData.mainImage ? <img style={{background: "orange"}} src={shoeData.imageUrl} alt="Main preview" /> : <i className="fa-solid fa-cloud-arrow-up"></i>}
                          <span>{shoeData.mainImage ? "" : "Upload Main Image Here"}</span>
                          </label>
                          <input type="file" id="mainImage" hidden onChange={handleMainImageChange} />
                        </div>

                        <div className="file-item">
                          <label htmlFor="additionalImages" className="preview preview-additional-images">
                          {shoeData.additionalImages.length > 0 ? (
                            <></>
                          ) : (
                            <i className="fa-solid fa-cloud-arrow-up"></i>
                          )}
                          <span>{shoeData.additionalImages.length > 0 ? `${shoeData.additionalImages.length} Files Uploaded` : "Upload Sub Images"}</span>
                          </label>
                          <input type="file" id="additionalImages" hidden multiple onChange={handleAdditionalImagesChange} />
                        </div>
                      </div>
                  </>
                )}
              </div>
            ))}

          <button>Send</button>
        </form>
      </div>
    </div>
  );
};

export default Add;