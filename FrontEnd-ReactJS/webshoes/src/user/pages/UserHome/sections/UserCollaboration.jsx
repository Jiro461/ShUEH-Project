import React from 'react';
import './UserCollaboration.scss'
import SectionTitle from "../../../components/SectionTitle/SectionTitle";

const UserCollaboration = () => {
    return (
        <div className="collaboration">
            <SectionTitle title="COLLABORATION."></SectionTitle>
            <div className="collaboration-img">
                <img src="/collab-img-1.svg" alt=""></img>
                <img src="/collab-img-2.svg" alt=""></img>
            </div>
        </div>
    );
};

export default UserCollaboration;