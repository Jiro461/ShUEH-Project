export const shoes = [
    {
        id: "shoes" + 1,
        name: 'Nike Revolution 7',
        price: 150,
        brand: 'Nike',
        category: 'Basketball',
        description: 'Comfortable and durable basketball shoes',
        images: '/images/shoe.png',
        colors: [
            {
                color: 'Black',
                sizes: [
                    { size: 40, stock: 10 },
                    { size: 41, stock: 15 },
                    { size: 42, stock: 5 }
                ]
            },
            {
                color: 'White',
                sizes: [
                    { size: 40, stock: 8 },
                    { size: 41, stock: 10 },
                    { size: 42, stock: 7 }
                ]
            }
        ],
        rating: 4.5,
        reviews: [
            {
                user: 'John Doe',
                comment: 'Great shoes for playing basketball!',
                rating: 5
            }
        ],
    },
];