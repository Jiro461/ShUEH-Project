import React, { useState } from 'react';
import './UserProductCustom.scss'

const data = [
    {id:1,src:"/product-1.svg", srcTrans: "/product-1-transparent.png"},
    {id:2,src:"/product-2.svg", srcTrans: "/product-2-transparent.png"},
    {id:3,src:"/product-3.svg", srcTrans: "/product-3-transparent.png"},
    {id:4,src:"/product-4.svg", srcTrans: "/product-4-transparent.png"},
    {id:5,src:"/product-5.svg", srcTrans: "/product-5-transparent.png"},
]

const UserProductCustom = () => {
    // Khởi tạo state cho src ảnh chính
    const [mainImageSrc, setMainImageSrc] = useState("/product-2.png");

    // Khởi tạo state cho danh sách ảnh để đổi src của ảnh trong img-list
    const [imageList, setImageList] = useState(data);
   
    const handleClick = (index) => {
        //Đổi lại src ảnh img-select thành transparent
        const updatedImageList = [...imageList];
        updatedImageList[index].src = updatedImageList[index].srcTrans;
        setImageList(updatedImageList);
     
        //Thêm class css để transition phóng to ảnh
    
        //Đổi lại src của ảnh main
        // Lấy ảnh từ data theo index
        const transImg = data[index].srcTrans;

        // Đổi lại src ảnh chính
        setMainImageSrc(transImg);
    
        //Đổi lại vị trí của thẻ div trong img-list
    }
   
    return (
        <div className="user-home-custom">
            <img className="img-main" src={mainImageSrc} alt=""></img>
            <div className="img-list">
                {/* <img className="img-item" src="/product-1.svg" alt=""></img>
                <img className="img-item" src="/product-2.svg" alt=""></img>
                <img className="img-item" src="/product-3.svg" alt=""></img>
                <img className="img-item" src="/product-4.svg" alt=""></img>
                <img className="img-item" src="/product-5.svg" alt=""></img> */}
                {
                    data.map((item, index) => {
                        return <img className="img-item" src={item.src} alt="" onClick={()=>handleClick(index)}></img>
                    })
                }
            </div>
        </div>
    );
};

export default UserProductCustom;