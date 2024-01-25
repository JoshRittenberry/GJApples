import { useEffect, useState } from "react"
import { useNavigate, useParams } from "react-router-dom"
import { cancelOrder, getOrderById } from "../../managers/orderManager"
import { Button, Table } from "reactstrap"

export const EditOrder = ({ loggedInUser }) => {
    const [order, setOrder] = useState({})

    const navigate = useNavigate()
    const orderId = useParams().id

    useEffect(() => {
        getOrderById(orderId).then(setOrder)
    }, [])

    return (
        <>
            <header className="vieworder_header">
                <h1>Edit Order</h1>
                <h3>Order #{order.id}</h3>
                <h3>Customer Id #{order.customerUserProfileId}</h3>
                <h5>Phone: (XXX)-XXX-XXXX</h5>
                <h5>Email: xxx@xxxx.com</h5>
                {!order.canceled && order.employeeUserProfileId === null && order.dateCompleted === null && (
                    <>
                        <Button onClick={() => {

                        }}>
                            Discard Changes
                        </Button>
                        <Button onClick={() => {

                        }}>
                            Save Changes
                        </Button>
                    </>
                )}
            </header>
            <section className="vieworder_body">
                <Table>
                    <thead>
                        <tr>
                            <th>Apple Variety</th>
                            <th>Pounds</th>
                            <th>Item Cost (Per Pound)</th>
                            <th>Item Cost (Total)</th>
                        </tr>
                    </thead>
                    <tbody>
                        {order.orderItems?.map((oi) => (
                            <tr key={`orderitem-${oi.id}`}>
                                <th
                                    scope="row"
                                >
                                    {oi.appleVariety?.type}
                                </th>
                                <th>{oi.pounds} lbs</th>
                                <th>${oi.appleVariety.costPerPound}</th>
                                <th>${oi.totalItemCost}</th>
                            </tr>
                        ))}
                    </tbody>
                    <tbody>
                        <tr>
                            <th></th>
                            <th></th>
                            <th></th>
                            <th>Total: ${order.totalCost}</th>
                        </tr>
                    </tbody>
                </Table>
            </section>
            <footer className="vieworder_footer">
                <h3>Contact Us</h3>
                <div className="vieworder_footer_address">
                    <p>2584 Orchard Lane</p>
                    <p>Mount Juliet, TN 37122</p>
                </div>
                <div className="vieworder_footer_contactinfo">
                    <p>Phone Number: (615) 502-7483</p>
                    <p>Email: contact@garyjonesappleorchard.com</p>
                </div>
            </footer>
        </>
    )
}