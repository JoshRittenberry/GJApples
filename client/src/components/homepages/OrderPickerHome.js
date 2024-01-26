import { useEffect, useState } from "react"
import "../stylesheets/orderPickerHomePage.css"
import { getAllUnassignedOrders, getOrderPickerAssignment } from "../../managers/orderManager"
import { OrderPickerAvailableOrders } from "../orders/OrderPickerAvailableOrders"
import { OrderPickerAssignedOrder } from "../orders/OrderPickerAssignedOrder"
import { ContactUsFooter } from "../ContactUsFooter"

export const OrderPickerHome = ({ loggedInUser }) => {
    const [orders, setOrders] = useState([])
    const [assignedOrder, setAssignedOrder] = useState({})

    useEffect(() => {
        getAllUnassignedOrders().then(setOrders)
        getOrderPickerAssignment().then(setAssignedOrder)
    }, [])

    console.log(loggedInUser.id)

    return (
        <>
            <header className="orderpickerhome_header">
                <h1>Order Picker Home Page</h1>
            </header>
            <section className="orderpickerhome_body">
                <OrderPickerAvailableOrders loggedInUser={loggedInUser} orders={orders} assignedOrder={assignedOrder} setAssignedOrder={setAssignedOrder} />
                <OrderPickerAssignedOrder loggedInUser={loggedInUser} assignedOrder={assignedOrder} setOrders={setOrders} setAssignedOrder={setAssignedOrder} />
            </section>
            <ContactUsFooter />
        </>
    )
}