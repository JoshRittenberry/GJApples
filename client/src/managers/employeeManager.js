export const getAllOrderPickers = () => {
    return fetch(`/api/orderpickers`).then((res) => res.json())
}

export const getAllHarvesters = () => {
    return fetch(`/api/harvesters`).then((res) => res.json())
}

export const getAllRoles = () => {
    return fetch(`/api/userprofiles/roles`).then((res) => res.json())
}

export const getEmployeeById = (employeeId) => {
    return fetch(`/api/userprofiles/${employeeId}`).then((res) => res.json())
}

export const updateEmployee = (employeeId, update) => {
    return fetch(`/api/userprofiles/${employeeId}`, {
        method: "PUT",
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify(update),
    })
}