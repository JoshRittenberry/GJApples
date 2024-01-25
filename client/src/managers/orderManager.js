const _apiUrl = "/api/orders"

export const getAllOrders = () => {

}

export const getCustomerOrders = () => {
    return fetch(_apiUrl).then((res) => res.json())
}

export const getUnsubmittedOrder = () => {
    return fetch(`${_apiUrl}/unsubmitted`).then((res) => res.json())
}

export const getOrderById = () => {

}