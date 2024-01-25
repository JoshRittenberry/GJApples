import { useEffect, useState } from "react"
import "../stylesheets/orderHistory.css"
import { getAllOrders } from "../../managers/orderManager"
import { Button, Table } from "reactstrap"
import { useNavigate } from "react-router-dom"

export const OrderHistory = ({ loggedInUser }) => {
    const [submittedOrders, setSubmittedOrders] = useState([])

    const navigate = useNavigate()

    useEffect(() => {
        getAllOrders().then((res) => {
            let orders = res.filter(order => order.dateOrdered !== null);
            let ordersSorted = orders.sort((a, b) => b.id - a.id)

            setSubmittedOrders(ordersSorted);
        });
    }, []);

    return (
        <div>
            <header className="orderhistory_header">
                <h1>Order History Page</h1>
            </header>
            <section className="orderhistory_body">
                <Table>
                    <thead>
                        <tr>
                            <th>Order ID</th>
                            <th>Order Date</th>
                            <th>Date Completed</th>
                            <th>Order Picker</th>
                            <th>Cost</th>
                            <th>Pounds of Apples</th>
                            <th></th>
                        </tr>
                    </thead>
                    <tbody>
                        {submittedOrders.map((o) => (
                            <tr key={`order-${o.id}`}>
                                <th
                                    scope="row"
                                >
                                    {o.id}
                                </th>
                                <th>
                                    {new Date(o.dateOrdered).toISOString().split('T')[0]}
                                </th>
                                <th>
                                    {o.canceled && ("Canceled")}
                                    {!o.canceled && o.employeeUserProfileId == null && ("Awaiting Order Picker")}
                                    {!o.canceled && o.employeeUserProfileId != null && o.dateCompleted == null && ("In Progress")}
                                    {!o.canceled && o.employeeUserProfileId != null && o.dateCompleted != null && (new Date(o.dateCompleted).toISOString().split('T')[0])}
                                </th>
                                <th>
                                    {o.employeeUserProfileId != null && (o.employeeUserProfileId)}
                                    {o.employeeUserProfileId === null && o.canceled && ("-")}
                                    {o.employeeUserProfileId === null && !o.canceled && ("N/A")}
                                </th>
                                <th>
                                    {o.canceled && ("-")}
                                    {!o.canceled && (`$${o.totalCost}`)}
                                </th>
                                <th>
                                    {o.canceled && ("-")}
                                    {!o.canceled && (`${o.orderItems.reduce((sum, item) => sum + item.pounds, 0)} lbs`)}
                                </th>
                                <th>
                                    <Button onClick={() => {
                                        navigate(`/orderhistory/view/${o.id}`)
                                    }}>
                                        View Order
                                    </Button>
                                </th>
                            </tr>
                        ))}
                    </tbody>
                </Table>
            </section>
        </div>
    )
}