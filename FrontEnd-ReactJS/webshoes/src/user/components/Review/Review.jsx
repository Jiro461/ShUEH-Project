import RatingStars from "../RatingStars/RatingStars";
import "./style.css";

function Review({cmt}) {
    
    return (
        <div key={cmt.UserId} className="row user-review">
            <div className="row user-review-content">
                <div className="col-3 user-ava">
                    <div><img src={process.env.PUBLIC_URL + '/img/airford1.png'} alt="" /></div>
                </div>

                <div className="col-8 review">
                    <div className="row review-status">
                        <div className="col-5"><p className="status">Really good</p></div>
                        <div className="col-6"><p className="date">Bao Nguyen - 12/2/2024</p></div>
                    </div>
                    <div className="row review-rating">
                        <RatingStars rating={cmt.Rate}/>
                    </div>
                    <div className="row comment">
                        <p>{cmt.Description}</p>
                    </div>
                    <div className="row like">
                        <p><i className="fa-solid fa-thumbs-up"></i> {cmt.TotalLike}</p>
                    </div>
                    <div className="row seller-feedback">
                        <p>{cmt.GeneralReview}</p>
                    </div>
                </div>
            </div>
        </div>
    )
}

export default Review;