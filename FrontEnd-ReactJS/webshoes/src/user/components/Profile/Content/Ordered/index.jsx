import './style.css'

function Ordered() {
    return (
        <>
            <div className="col ordered">
                <div className="order">
                    <div className="order-status">
                        <h2 className="code">Order: 12345</h2>
                        <h2 className="status">Successfull Delivery</h2>
                    </div>

                    <div className="item">
                        <div className="image"><img src={process.env.PUBLIC_URL + "/img/show.png"} alt="" /></div>

                        <div className="item-info">
                            <div className="info">
                                <h3>NIKE AIR VAPORMAX</h3>
                                <p>Size 8.5</p>
                                <p>Orange</p>
                                <h3>x2</h3>
                            </div>
                            <p className="item-price">$210</p>
                        </div>
                    </div>

                    <p className="total">Total <span>$210</span></p>
                    <div className="buy-back"><button type="button" className="btn-buyBack">Buy Back</button></div>
                </div>

                <div className="order">
                    <div className="order-status">
                        <h2 className="code">Order: 12345</h2>
                        <h2 className="status">Successfull Delivery</h2>
                    </div>

                    <div className="item">
                        <div className="image"><img src={process.env.PUBLIC_URL + "/img/show.png"} alt="" /></div>

                        <div className="item-info">
                            <div className="info">
                                <h3>NIKE AIR VAPORMAX</h3>
                                <p>Size 8.5</p>
                                <p>Orange</p>
                                <h3>x2</h3>
                            </div>
                            <p className="item-price">$210</p>
                        </div>
                    </div>

                    <div className="item">
                        <div className="image"><img src={process.env.PUBLIC_URL + "/img/show.png"} alt="" /></div>

                        <div className="item-info">
                            <div className="info">
                                <h3>NIKE AIR VAPORMAX</h3>
                                <p>Size 8.5</p>
                                <p>Orange</p>
                                <h3>x2</h3>
                            </div>
                            <p className="item-price">$210</p>
                        </div>
                    </div>

                    <p className="total">Total <span>$210</span></p>
                    <div className="buy-back"><button type="button" className="btn-buyBack">Buy Back</button></div>
                </div>
            </div>
        </>
    );
}

export default Ordered;