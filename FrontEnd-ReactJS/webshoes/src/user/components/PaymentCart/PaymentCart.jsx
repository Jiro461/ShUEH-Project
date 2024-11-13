import React, { useEffect, useState } from 'react';
import config from "../../../config/config.json";

const PaymentCart = () => {
    const [cartItems, setCartItems] = useState([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);

    useEffect(() => {
        const fetchCartItems = async () => {
            try {
                const response = await fetch(`${process.env.REACT_APP_API_URL}/api/Cart/get`, {
                    method: 'GET',
                    credentials: 'include',
                });
                
                if (!response.ok) {
                    throw new Error('Failed to fetch cart items');
                }
                
                const data = await response.json();
                setCartItems(data);
            } catch (err) {
                setError(err.message);
            } finally {
                setLoading(false);
            }
        };

        fetchCartItems();
    }, []);

    const handleDelete = async (itemId) => {
        try {
            const response = await fetch(`${process.env.REACT_APP_API_URL}/api/Cart/delete?id=${itemId}`, {
                method: 'DELETE',
                credentials: 'include',
            });

            if (!response.ok) {
                throw new Error('Failed to delete item');
            }

            // Remove the deleted item from the cartItems array
            setCartItems(prevItems => prevItems.filter(item => item.itemId !== itemId));
        } catch (err) {
            setError(err.message);
        }
    };

    if (loading) {
        return <div>Loading...</div>;
    }

    if (error) {
        return <div>Error: {error}</div>;
    }

    return (
        <div className="row cart-product">
            <div className="col"></div>
            <div className="col-10">
                <h1>Your Shopping Cart</h1>
                <div className="cart">
                    {cartItems.map((item) => (
                        <div key={item.itemId} className="row cart-item">
                            <div className="col-xl-2 col-4 image">
                                <div><img src={`${process.env.REACT_APP_API_URL}/${item.shoeImage}`} alt="Product" style={{width: "100%"}}/></div>
                            </div>
                            <div className="col-xl-9 col-5" style={{alignContent: "center"}}>
                                <div className="row cart-item-info">
                                    <div className="col-xl-4 col-7 cart-item-name">
                                        <h3>{item.shoeName}</h3>
                                        <h4>Size {item.size}</h4>
                                    </div>

                                    <div className="col-xl-2 col-5 cart-item-color">
                                        {/* Render colors */}
                                        {item.colors.map((color, index) => (
                                            <h3 key={index}>{color.color}</h3>
                                        ))}
                                    </div>

                                    {/* <div className="col-xl-3 col-12 amount-adjust">
                                        <div className='adjust'><i className="fa-solid fa-minus"></i></div>
                                        <div>{item.quantity}</div>
                                        <div className='adjust'><i className="fa-solid fa-plus"></i></div>
                                    </div> */}

                                    <div className="col-xl-3 col-12 cart-item-price">
                                        <h4>Pricing ${(item.price * item.quantity) ? (item.price * item.quantity).toFixed(2) : "0.00"}</h4>
                                    </div>
                                </div>
                            </div>
                            <div className="col-1 btn-delete" onClick={() => handleDelete(item.itemId)}>
                                <i className="fa-solid fa-xmark"></i>
                            </div>
                        </div>
                    ))}
                </div>
            </div>
            <div className="col"></div>
        </div>
    );
};

export default PaymentCart;
