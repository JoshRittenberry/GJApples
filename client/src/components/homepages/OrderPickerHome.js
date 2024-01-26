import { useEffect, useState } from "react"
import { Button, Table } from "reactstrap"
import { getAllUnassignedOrders } from "../../managers/orderManager"

export const OrderPickerHome = ({ loggedInUser }) => {
    const [orders, setOrders] = useState([])

    useEffect(() => {
        getAllUnassignedOrders().then(setOrders)
    }, [])

    return (
        <>
            <header className="orderpickerhome_header">
                <h1>Order Picker Home Page</h1>
            </header>
            <section className="orderpickerhome_body">
                <div>
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
                                        <Button>
                                            Something
                                        </Button>
                                    </th>
                                </tr>
                            ))}
                        </tbody>
                    </Table>
                </div>
                <div>
                    Order Info
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