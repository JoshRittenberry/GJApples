import { useEffect, useState } from "react"
import { getAllUnassignedOrders, getOrderPickerAssignment } from "../../managers/orderManager"
import { OrderPickerAvailableOrders } from "../orders/OrderPickerAvailableOrders"
import { OrderPickerAssignedOrder } from "../orders/OrderPickerAssignedOrder"

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
            <footer className="orderpickerhome_footer">
                <h3>Contact Us</h3>
                <div className="orderpickerhome_footer_address">
                    <p>2584 Orchard Lane</p>
                    <p>Mount Juliet, TN 37122</p>
                </div>
                <div className="orderpickerhome_footer_contactinfo">
                    <p>Phone Number: (615) 502-7483</p>
                    <p>Email: contact@garyjonesappleorchard.com</p>
                </div>
            </footer>
        </>
    )
}