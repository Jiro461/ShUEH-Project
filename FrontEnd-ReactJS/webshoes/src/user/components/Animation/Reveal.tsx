import React, { useEffect, useRef } from 'react';
import { motion, useInView, useAnimation } from 'framer-motion'

interface Props {
    children: JSX.Element; // Dữ liệu con sẽ được truyền vào component này
    width?: "fit-content" | "100%"; // Chiều rộng của phần tử, có thể là 'fit-content' hoặc '100%'
}

export const Reveal = ({children, width = "fit-content"}) => {
    const ref = useRef(null); // Dùng để tham chiếu đến phần tử trong DOM
    const isInView = useInView(ref); // Kiểm tra xem phần tử có trong viewport không

    const mainControls = useAnimation(); // Điều khiển animation chính (opacity và y)
    const slideControls = useAnimation(); // Điều khiển animation phụ (gradient di chuyển từ trái qua phải)

    useEffect(() => {
        if (isInView){ // Nếu phần tử đã vào trong viewport
            mainControls.start("visible"); // Bắt đầu animation chính (hiển thị và di chuyển theo trục y)
            slideControls.start("visible"); // Bắt đầu animation phụ (di chuyển gradient)
        }else{ 
            mainControls.start("hidden"); // Nếu phần tử ra khỏi viewport, ẩn animation chính
            slideControls.start("hidden"); // Ẩn animation phụ
        }
    }, [isInView]) // Chạy lại khi giá trị của isInView thay đổi

    return (
        <div ref={ref} style={{position: "relative", width, overflow: "hidden"}}> {/* Đặt kiểu position là relative để chứa gradient */}
            <motion.div
                variants={{
                    hidden: {opacity: 0, y: 75}, // Nếu phần tử không hiển thị thì opacity = 0 và y = 75 (đẩy xuống dưới)
                    visible: {opacity: 1, y: 0}   // Nếu phần tử hiển thị thì opacity = 1 và y = 0 (vị trí ban đầu)
                }}
                initial="hidden" // Bắt đầu với trạng thái "hidden"
                animate={mainControls} // Điều khiển animation chính
                transition={{ duration: 0.5, delay: 0.25 }}> {/* Thời gian transition là 0.5s và delay 0.25s */}
                    {children} {/* Dữ liệu con sẽ được hiển thị tại đây */}
            </motion.div>
            <motion.div
                variants={{
                    hidden: {left: 0}, // Nếu không hiển thị thì gradient sẽ ở vị trí left = 0
                    visible: {left: "100%"} // Nếu hiển thị thì gradient sẽ di chuyển ra ngoài với left = 100%
                }}
                initial="hidden" // Bắt đầu với trạng thái "hidden"
                animate={slideControls} // Điều khiển animation phụ
                transition={{duration: 0.5, ease: "easeIn"}} // Thời gian transition là 0.5s và easing là "easeIn"
                style={{
                    position: "absolute", // Đặt position là absolute để gradient có thể di chuyển tự do trong container
                    top: 4,
                    bottom: 4,
                    left: 0,
                    right: 0,
                    background: "linear-gradient(to right,rgba(255, 100, 107, 1), rgba(252, 171, 115, 1))", // Màu gradient của background
                    zIndex: 20 // Đảm bảo gradient luôn hiển thị trên các phần tử khác
                }}>
            </motion.div>
        </div>
    );
};
