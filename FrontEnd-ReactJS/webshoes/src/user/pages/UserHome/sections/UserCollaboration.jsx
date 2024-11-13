import React, { useEffect, useState } from 'react';
import './UserCollaboration.scss'
import SectionTitle from "../../../components/SectionTitle/SectionTitle";
import { useNavigate } from "react-router-dom"
import * as homeService from "../../../../services/homeService"
import {Reveal} from "../../../components/Animation/Reveal.tsx";

const UserCollaboration = () => {
    const navigate = useNavigate()
    const [id, setId] = useState()
    useEffect(() => {
        const fetchData = async () => {
            const res = await homeService.getCollaborationProduct()
            setId(res.id)
        }
        fetchData()
    }, [])
    return (
        <div className="collaboration">
            <Reveal>
            <SectionTitle title="COLLABORATION."></SectionTitle>
            </Reveal>
            <div className="collaboration-img" onClick={() => navigate(`/product/${id}`)}>
                <img src="/collab-img-1.svg" alt=""></img>
                <img src="/collab-img-2.svg" alt=""></img>
            </div>
        </div>
    );
};

export default UserCollaboration;