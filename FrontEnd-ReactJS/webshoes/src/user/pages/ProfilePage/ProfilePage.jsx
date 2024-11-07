import "./style.css"
import { Outlet, Link } from 'react-router-dom';

function ProfilePage() {
    return (
        <>
            <div className="row profile">
                {/* Sidebar */}
                <div className="col-lg-3 col-12 sidebar">
                    <Link className="sidebar-selection" to=''>Profile</Link>
                    <Link className="sidebar-selection" to='favour'>Favorite</Link>
                    <Link className="sidebar-selection" to='ordered'>Ordered</Link>
                </div>

                {/* Content */}
                <div className="col-lg-7 col-12 content-profile-page">
                    <Outlet/>
                </div>
            </div>
        </>
    );
}

export default ProfilePage;