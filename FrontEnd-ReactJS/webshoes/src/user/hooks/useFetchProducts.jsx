// useFetchProducts.js
import { useEffect, useState } from 'react';
import config from "../../config/config.json";

export const useFetchProducts = () => {
    const [products, setProducts] = useState([]);
    const { SERVER_API } = config;

    useEffect(() => {
        fetch(`${SERVER_API}/api/Shoe/all`)
            .then((response) => response.json())
            .then((data) => {
                setProducts(data.map(product => ({
                    id: product.id,
                    name: product.name,
                    price: product.price,
                    brand: product.brand,
                    gender: product.gender,
                    sport: product.category,
                    shoeDetails: product.shoeDetails,
                    colors: product.colors,
                    isSale: product.isSale,
                    imageUrl: product.imageUrl,
                    isNew: product.isNew
                })));
            })
            .catch(error => console.error('Error fetching data:', error));
    }, [SERVER_API]);

    return products;
};
