const _apiUrl = "/api/trees"

export const getAllTrees = () => {
    return fetch(_apiUrl).then((res) => res.json())
}

export const getAllUnassignedTrees = () => {
    return fetch(`${_apiUrl}?needsHarvested=true`).then((res) => res.json())
}

export const getHarvesterAssignment = () => {
    return fetch(`${_apiUrl}/assignment`).then((res) => res.json())
}

export const createNewTreeHarvestReport = (treeHarvestReport) => {
    return fetch(`${_apiUrl}/harvestreports`, {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify(treeHarvestReport),
    })
}

export const completeHarvesterAssignment = (treeHarvestReportId, treeHarvestReport) => {
    return fetch(`${_apiUrl}/harvestreports/${treeHarvestReportId}`, {
        method: "PUT",
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify(treeHarvestReport),
    })
}

export const deleteTreeHarvestReport = (treeHarvestReportId) => {
    return fetch(`${_apiUrl}/harvestreports/${treeHarvestReportId}`, {
        method: "DELETE"
    })
}