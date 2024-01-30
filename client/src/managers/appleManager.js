const _apiUrl = "/api/apples"

export const getAllApples = () => {
    return fetch(_apiUrl).then((res) => res.json())
}

export const getAppleVarieties = () => {
    return fetch(_apiUrl).then((res) => res.json())
}