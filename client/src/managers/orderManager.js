const _apiUrl = "/api/orders"

export const getAllOrders = () => {

}

export const getCustomerOrders = () => {
    return fetch(_apiUrl).then((res) => res.json())
}

export const getOrderById = () => {

}

export const createOrder = () => {

}