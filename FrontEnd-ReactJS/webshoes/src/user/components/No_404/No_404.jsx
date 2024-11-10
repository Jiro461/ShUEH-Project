import React from "react";
import { Link } from "react-router-dom"; // Import Link để quay lại trang chính hoặc trang khác

function No_404() {
    return (
        <div style={styles.container}>
            <h1 style={styles.header}>404 - Page Not Found</h1>
            <p style={styles.message}>Oops! The page you are looking for does not exist.</p>
            <Link to="/" style={styles.link}>Go back to Home</Link>
        </div>
    );
}

const styles = {
    container: {
        textAlign: "center",
        paddingBottom: "500px",
        backgroundImage: `url(${process.env.PUBLIC_URL}/img/404.png)`
    },
    header: {
        fontSize: "48px",
        color: "#fff",
    },
    message: {
        fontSize: "24px",
        color: "#fff",
    },
    link: {
        fontSize: "18px",
        color: "#007bff",
        textDecoration: "none",
        marginTop: "20px",
        display: "inline-block",
    }
};

export default No_404;
