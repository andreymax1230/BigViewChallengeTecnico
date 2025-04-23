export interface Product {
    id:string,
    name: string,
    description: string,
    price: number,
    imageUrl: string,
    active: boolean
}

export interface Car
{
    userId: string,
    productId: string,
    count: number
}

export interface User{
    name: string,
    email: string,
    active: boolean,
    id: string
}