import { useEffect, useState } from "react"
import { Button, Table } from "reactstrap"
import { assignOrderPicker, getAllUnassignedOrders, getOrderPickerAssignment } from "../../managers/orderManager"

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
                <div className="orderpickerhome_body_list">
                    <Table>
                        <thead>
                            <tr>
                                <th>Order ID</th>
                                <th>Order Date</th>
                                <th></th>
                            </tr>
                        </thead>
                        <tbody>
                            {orders?.map((o) => (
                                <tr key={`order-${o.id}`}>
                                    <th
                                        scope="row"
                                    >
                                        {o.id}
                                    </th>
                                    <th>{new Date(o.dateOrdered).toISOString().split('T')[0]}</th>
                                    <th>
                                        {assignedOrder.id == null && (
                                            <Button onClick={() => {
                                                assignOrderPicker(o.id, loggedInUser.id).then(() => {
                                                    getOrderPickerAssignment().then(setAssignedOrder)
                                                })
                                            }}>
                                                Assign Me
                                            </Button>
                                        )}
                                    </th>
                                </tr>
                            ))}
                        </tbody>
                    </Table>
                </div>
                <div className="orderpickerhome_body_assignment">
                    <header className="orderpickerhome_body_assignment">
                        <h3>Order #{assignedOrder.id}</h3>
                        <h3>Customer Id #{assignedOrder.customerUserProfileId}</h3>
                        <h5>Phone: (XXX)-XXX-XXXX</h5>
                        <h5>Email: xxx@xxxx.com</h5>
                    </header>
                    <section className="vieworder_body">
                        <Table>
                            <thead>
                                <tr>
                                    <th>Apple Variety</th>
                                    <th>Pounds</th>
                                </tr>
                            </thead>
                            <tbody>
                                {assignedOrder.orderItems?.map((oi) => (
                                    <tr key={`orderitem-${oi.id}`}>
                                        <th
                                            scope="row"
                                        >
                                            {oi.appleVariety?.type}
                                        </th>
                                        <th>{oi.pounds} lbs</th>
                                    </tr>
                                ))}
                            </tbody>
                            <tbody>
                                <tr>
                                    <th>Total: ${assignedOrder.totalCost}</th>
                                    <th>
                                        <Button>
                                            Complete Order
                                        </Button>
                                    </th>
                                </tr>
                            </tbody>
                        </Table>
                    </section>
                </div>
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