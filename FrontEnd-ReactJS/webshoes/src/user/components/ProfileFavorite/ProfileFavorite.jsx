import './style.css'

function ProfileFavorite() {
    return (
        <>
            <ul className="row row-cols-3 favour">
                <li className='col favour-item'>
                    <div className="new">New</div>
                    <img src={process.env.PUBLIC_URL + `/img/revolution7.png`} alt="" />
                    <a href="">
                        <div className="favour-item-detail">
                            <h4>NIKE</h4>
                            <p>Pricing $210.00</p>
                        </div>
                    </a>
                    <div className="btn-heart">
                        <i className={`fa-solid fa-heart`}/>
                    </div>
                    <div className='add-to-cart'><button className='btn-addToCart'>Add To Cart</button></div>
                </li>

                <li className='col favour-item'>
                    <div className="new">New</div>
                    <img src={process.env.PUBLIC_URL + `/img/revolution7.png`} alt="" />
                    <a href="">
                        <div className="favour-item-detail">
                            <h4>NIKE</h4>
                            <p>Pricing $210.00</p>
                        </div>
                    </a>
                    <div className="btn-heart">
                        <i className={`fa-solid fa-heart`}/>
                    </div>
                    <div className='add-to-cart'><button className='btn-addToCart'>Add To Cart</button></div>
                </li>

                <li className='col favour-item'>
                    <div className="new">New</div>
                    <img src={process.env.PUBLIC_URL + `/img/revolution7.png`} alt="" />
                    <a href="">
                        <div className="favour-item-detail">
                            <h4>NIKE</h4>
                            <p>Pricing $210.00</p>
                        </div>
                    </a>
                    <div className="btn-heart">
                        <i className={`fa-solid fa-heart`}/>
                    </div>
                    <div className='add-to-cart'><button className='btn-addToCart'>Add To Cart</button></div>
                </li>

                <li className='col favour-item'>
                    <div className="new">New</div>
                    <img src={process.env.PUBLIC_URL + `/img/revolution7.png`} alt="" />
                    <a href="">
                        <div className="favour-item-detail">
                            <h4>NIKE</h4>
                            <p>Pricing $210.00</p>
                        </div>
                    </a>
                    <div className="btn-heart">
                        <i className={`fa-solid fa-heart`}/>
                    </div>
                    <div className='add-to-cart'><button className='btn-addToCart'>Add To Cart</button></div>
                </li>

                <li className='col favour-item'>
                    <div className="new">New</div>
                    <img src={process.env.PUBLIC_URL + `/img/revolution7.png`} alt="" />
                    <a href="">
                        <div className="favour-item-detail">
                            <h4>NIKE</h4>
                            <p>Pricing $210.00</p>
                        </div>
                    </a>
                    <div className="btn-heart">
                        <i className={`fa-solid fa-heart`}/>
                    </div>
                    <div className='add-to-cart'><button className='btn-addToCart'>Add To Cart</button></div>
                </li>

                <li className='col favour-item'>
                    <div className="new">New</div>
                    <img src={process.env.PUBLIC_URL + `/img/revolution7.png`} alt="" />
                    <a href="">
                        <div className="favour-item-detail">
                            <h4>NIKE</h4>
                            <p>Pricing $210.00</p>
                        </div>
                    </a>
                    <div className="btn-heart">
                        <i className={`fa-solid fa-heart`}/>
                    </div>
                    <div className='add-to-cart'><button className='btn-addToCart'>Add To Cart</button></div>
                </li>
            </ul>
        </>
    );
}

export default ProfileFavorite;