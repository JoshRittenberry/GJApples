export const getAllOrderPickers = () => {
    return fetch(`/api/orderpickers`).then((res) => res.json())
}

export const getAllHarvesters = () => {
    return fetch(`/api/harvesters`).then((res) => res.json())
}