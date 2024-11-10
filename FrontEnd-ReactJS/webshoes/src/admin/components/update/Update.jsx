import "../add/add.scss";
import OutlinedInput from '@mui/material/OutlinedInput';
import InputLabel from '@mui/material/InputLabel';
import MenuItem from '@mui/material/MenuItem';
import FormControl from '@mui/material/FormControl';
import Select from '@mui/material/Select';
import React, { useEffect, useState } from "react";
import TextField from '@mui/material/TextField';
import * as adminProductsService from "../../../services/adminProductsService"
import * as adminUsersService from "../../../services/adminUsersService"
import * as adminOrdersService from "../../../services/adminOrdersService"
import * as adminDiscountsService from "../../../services/adminDiscountsService"
import { InputAdornment } from "@mui/material";

const Update = (props) => {
  const [genderUi, setGenderUi] = useState("Male")
  const [bindingAddImages, setBindingAddImages] = useState([])
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
  console.log(shoeData);
  const [user, setUser] = useState({
    email: "",
    firstName: "",
    lastName: "",
    profileName: "",
    dateOfBirth: "",
    gender: "",
    role: ""
  })
  const [orderStatus, setOrderStatus] = useState("")
  const [discount, setDiscount] = useState({
    code: "",
    amount: "",
    minimumOrder: "",
    percentage: "",
    maximumDiscount: "",
    quantity: "",
    type: "",
    isPublic: "",
    expiryDate: ""
  })
  useEffect(() => {
    props.setOpenBackDrop(true)
    const fetchData = async () => {
      if (props.slug === "product"){
        const res = await adminProductsService.getProductById(props.id)
        console.log(res);
        setShoeData((prevData) => {
        const updatedSizes = prevData.sizes.map(sizeObj => {
          const foundSize = res.shoeDetails.find(detail => detail.size === sizeObj.size);
          return {
            size: sizeObj.size,
            quantity: foundSize ? foundSize.quantity : 0, // Nếu không tìm thấy, gán quantity là 0
          };
        });
  
        return {
          ...prevData,
          name: res.name,
          brand: res.brand,
          gender: res.gender,
          materials: res.material.replace(', and ', ', ').split(', ').map(material => ({
            material: material.charAt(0).toUpperCase() + material.slice(1)
          })),
          category: res.category,
          description: res.description,
          price: res.price.toString(),
          discount: res.discount,
          colors: res.colors,
          seasons: res.seasons,
          sizes: updatedSizes, // Cập nhật kích thước ở đây
          imageUrl: res.imageUrl,
          mainImage: null,
          additionalImages: res.otherImages,
        };
      });
      setBindingAddImages(res.otherImages)
      if (res.gender === 0) {
        setGenderUi("Female");
      } else if (res.gender === 1) {
        setGenderUi("Male");
      } else {
        setGenderUi("Unisex");
      }
    }

    if (props.slug === "user"){
      const res = await adminUsersService.getUserById(props.id)
      setUser((prevData) => {
        return {
          ...prevData,
          email: res.email,
          firstName: res.firstName,
          lastName: res.lastName,
          profileName: res.profileName,
          dateOfBirth: res.dateOfBirth.split('T')[0],
          gender: res.gender === 1 ? "Male" : "Female",
          role: res.role,
          imageUrl: res.avatarUrl
        }
      })
      console.log(user);
    }
    
    if (props.slug === "order"){
      const res = await adminOrdersService.getOrderById(props.id)
      console.log(res);
      setOrderStatus(res.status)
    }

    if (props.slug === "discount"){
      const res = await adminDiscountsService.getDiscountById(props.id)
      console.log(res);
      setDiscount((prevData) => {
        return {
          ...prevData,
          code: res.code,
          amount: res.amount,
          minimumOrder: res.minimumOrder,
          percentage: res.percentage || "",
          maximumDiscount: res.maximumDiscount || "",
          quantity: res.quantity,
          type: res.type === 0 ? "Ship" : "Order",
          isPublic: res.isPublic ? "Public" : "Non Public",
          expiryDate: res.expiryDate.split('T')[0]
        }
      })
    }
    props.setOpenBackDrop(false)

    }
    fetchData()
  }, [])

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
if (props.slug === "user"){
  if (props.inputs.length === 8){
    props.inputs.splice(5, 0, {
      field: "profileName",
      headerName: "Profile Name",
      type: "text",
    })
  }
  if (props.inputs.length === 9){
    props.inputs.push({
      field: "avatar",
      label: "Avatar",
      type: "file"
    })
  }
}
function formatDateString(dateString) {
  // Tách chuỗi theo dấu "-"
  const parts = dateString?.split("-");
  // Đảm bảo rằng chúng ta có đúng 3 phần
  if (parts.length === 3) {
      // Đổi thứ tự và nối lại bằng "/"
      return `${parts[2]}/${parts[1]}/${parts[0]}`;
  }
  // Nếu chuỗi không đúng định dạng, trả về null hoặc thông báo lỗi
  return null;
}

const handleInputChange = (event) => {
  const { name, value } = event.target;
  if (props.slug === "product"){
    setShoeData((prevValues) => ({
      ...prevValues,
      [name]: value,
    }));
  }
  if (props.slug === "user"){
    setUser((prevValues) => ({
      ...prevValues,
      [name]: value,
    }));
  }
  if (props.slug === "discount"){
    if (name === "amount" && (discount.percentage || discount.maximumDiscount)) {
      props.setOpenToastMessage(true)
      props.setTypeToastMessage("warning")
      props.setTitleToastMessage("Only discount by percentage or amount can be entered.")
      return;
    }
    if ((name === "percentage" || name === "maximumDiscount") && discount.amount) {
      props.setOpenToastMessage(true)
      props.setTypeToastMessage("warning")
      props.setTitleToastMessage("Only discount by percentage or amount can be entered.")
      return;
    }
    setDiscount((prevValues) => ({
      ...prevValues,
      [name]: value,
    }));
  }
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
  if (props.slug === "product"){
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
  }
  if (props.slug === "user"){
    setUser((prevValues) => ({
      ...prevValues,
      [fieldName]: value
    }));
  }
  if (props.slug === "order"){
    setOrderStatus(value)
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

const handleMainImageChange = (e) => {
  const selectedFile = e.target.files[0];
  if (selectedFile && (selectedFile.name.endsWith('png') || 
                       selectedFile.name.endsWith('jpg') || 
                       selectedFile.name.endsWith('jpeg'))) {
    if (props.slug === "product"){
      setShoeData((prevData) => ({
        ...prevData,
        imageUrl: URL.createObjectURL(selectedFile),
        mainImage: selectedFile,
      }));
    }
    if (props.slug === "user"){
      setUser((prevData) => ({
        ...prevData,
        imageUrl: URL.createObjectURL(selectedFile),
        avatar: selectedFile,
      }));
    }
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

  const handleSubmit = async (e) => {
    e.preventDefault();
    props.setOpenBackDrop(true)
    var res = {}
    if (props.slug === "product"){
      const updateShoe = {
        ...shoeData,
        discount: parseInt(shoeData.discount, 10),
        price: parseInt(shoeData.price, 10),
        sizes: shoeData.sizes.map(size => ({
          ...size,
          quantity: parseInt(size.quantity, 10)
        })),
        additionalImages: Array.isArray(shoeData.additionalImages) && 
        shoeData.additionalImages.every(img => img instanceof File) 
        ? shoeData.additionalImages 
        : [],
        mainImage: null,
      }
      console.log(updateShoe);
      res = await adminProductsService.updateProduct(props.id, updateShoe)  
    }
    if (props.slug === "user"){
      const updatedUser = {
        ...user,
        gender: user.gender === "Male" ? true : user.gender === "Female" ? false : "", // Gán giá trị true/false dựa trên giới tính thực tế
        dateOfBirth: formatDateString(user?.dateOfBirth), // Đảm bảo định dạng đúng
        role: user.role.toLowerCase() || "" // Chuyển đổi role về chữ thường
      };
      res = await adminUsersService.updateUser(props.id, updatedUser)
    }

    if (props.slug === "order"){
      var status = ""
      if (orderStatus === "Pending") status = 0
      if (orderStatus === "Confirmed") status = 1
      if (orderStatus === "Shipped") status = 2
      if (orderStatus === "Delivered") status = 3
      if (orderStatus === "Canceled") status = 4
      res = await adminOrdersService.updateOrder(props.id,status)
    }
    if (props.slug === "discount"){
      if (discount.amount && discount.percentage){
        props.setOpenToastMessage(true) 
        props.setTypeToastMessage("warning")
        props.setTitleToastMessage("Only discount by percentage or amount")
        props.setOpenBackDrop(false)
      }
      const formatDiscount = {
        ...discount,
        amount: discount?.amount,
        percentage: discount.percentage === "" ? 0 : parseInt(discount.percentage),
        quantity: parseInt(discount.quantity),
        maximumDiscount: discount.maximumDiscount === "" ? 0 : parseInt(discount.maximumDiscount),
        minimumOrder: parseInt(discount.minimumOrder),
        isPublic: discount.isPublic === "Public",
        type: discount.type === "Ship" ? 1 : 0,
        expiryDate: discount.expiryDate
    };
      res = await adminDiscountsService.addNewDiscount(formatDiscount)
    }
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
        <h1>Update {props.slug}</h1>
        <form className={props.slug === "order" ? "form-order" : ""} onSubmit={handleSubmit}>  
          {props.inputs
            .filter((item) => item.field !== "id" && item.field !== "img")
            .map((input, index) => (
              <div key={index} className="item">

              {(input.type === "text" || input.type === "password") && input.field !== "price-discount" && (
                <>
                  <label>
                    {input.headerName}
                    {input.require && <span style={{color: "red"}}> *</span>}
                  </label>                  
                  <TextField
                          label={input.field}
                          type={input.type}
                          variant="outlined"
                          disabled={input.isUpdateDisable || false}
                          name={input.field}
                          value={props.slug === "product" ? shoeData[input.field] : props.slug === "user" ? user[input.field] : discount[input.field]}
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
                  value={props.slug === "product" ? shoeData[input.field] : props.slug === "user" ? user[input.field] : props.slug === "order" ? orderStatus : discount[input.field]}
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
                  value={props.slug === "product" ? genderUi : user?.gender}
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

              {input.type === "file" && input.field !== "avatar" && (
                  <>
                    <label>Upload Images</label>
                      <div className="file-container">
                        <div className="file-item">
                          <label htmlFor="mainImage" className="preview preview-main-image">
                          {shoeData.imageUrl ? <img style={{background: "orange"}} src={shoeData.imageUrl} alt="Main preview" /> : <i className="fa-solid fa-cloud-arrow-up"></i>}
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

                {input.type === "file" && input.field === "avatar" && (
                  <>
                    <label>Upload Avatar</label>
                      <div className="file-container">
                        <div className="file-item">
                          <label htmlFor="mainImage" className="preview preview-main-image" style={{width: 150, height: 150}}>
                          {user.imageUrl ? <img style={{background: "orange"}} src={user.imageUrl} alt="Main preview" /> : <i className="fa-solid fa-cloud-arrow-up"></i>}
                          <span>{user.avatar ? "" : "Upload Avatar Here"}</span>
                          </label>
                          <input type="file" id="mainImage" hidden onChange={handleMainImageChange} />
                        </div>     
                      </div>
                  </>
                )}

                {input.type === "date" && (
                <>
                  <label>
                    {input.headerName}
                    {input.require && <span style={{color: "red"}}> *</span>}
                  </label>                  
                  <TextField
                          type="date"
                          variant="outlined"
                          name={input.field}
                          value={props.slug === "product" ? shoeData[input.field] : props.slug === "user" ? user[input?.field] : discount[input.field]}
                          onChange={handleInputChange} // Cập nhật quantity
                        />
                </>
              )}
              </div>
            ))}

          <button>Update</button>
        </form>
      </div>
    </div>
  );
};

export default Update;