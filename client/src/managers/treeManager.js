const _apiUrl = "/api/trees"

export const getAllTrees = () => {
    return fetch(_apiUrl).then((res) => res.json())
}

export const getAllUnassignedTrees = () => {
    return fetch(`${_apiUrl}?needsHarvested=true`).then((res) => res.json())
}
