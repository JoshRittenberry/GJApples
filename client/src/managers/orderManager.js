const _apiUrl = "/api/orders"

export const getAllOrders = () => {

}

export const getCustomerOrders = () => {
    return fetch(_apiUrl).then((res) => res.json())
}

export const getUnsubmittedOrder = () => {
    return fetch(`${_apiUrl}/unsubmitted`).then((res) => res.json())
}

export const createOrderItem = (orderItem) => {
    return fetch(`${_apiUrl}/orderitem`, {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify(orderItem),
    })
}

export const increaseOrderItem = (orderItemId) => {
    return fetch(`${_apiUrl}/orderitem/${orderItemId}/increase`, {
        method: "PUT",
        headers: {
            "Content-Type": "application/json",
        }
    })
}

export const getOrderById = () => {

}