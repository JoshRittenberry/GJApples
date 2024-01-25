import { useEffect, useState } from "react"
import { useNavigate, useParams } from "react-router-dom"
import { cancelOrder, getOrderById, createOrderItem, decreaseOrderItem, getUnsubmittedOrder, increaseOrderItem, submitOrder, deleteOrderItem } from "../../managers/orderManager"
import { Button, Table } from "reactstrap"

export const EditOrder = ({ loggedInUser }) => {
    const [order, setOrder] = useState({})

    const navigate = useNavigate()
    const orderId = useParams().id

    useEffect(() => {
        getOrderById(orderId).then(setOrder)
    }, [])

    useEffect(() => {
        if (order.dateCompleted != null || order.employeeUserProfileId != null || order.customerUserProfileId != loggedInUser.id) {
            navigate("/orderhistory")
        }
    }, [order])

    const handleDisplayedItemPounds = (orderItemId) => {
        if (order.orderItems?.some(oi => oi.appleVarietyId == orderItemId)) {
            let orderItem = order.orderItems.find(oi => oi.appleVarietyId == orderItemId)

            return `${orderItem.pounds}/lbs`
        } else {
            return ""
        }
    }

    const handleIncreaseItem = (orderItemId) => {
        // If the Apple is already in the Order
        if (order.orderItems.some(oi => oi.appleVarietyId == orderItemId)) {
            let orderItem = order.orderItems.find(oi => oi.appleVarietyId == orderItemId)

            increaseOrderItem(orderItem.id).then(() => {
                getOrderById(orderId).then(setOrder)
            })
        }
        // If the Apple is not already in the Order
        else if (!order.orderItems.some(oi => oi.appleVarietyId == orderItemId)) {
            let orderItem = {
                orderId: order.id,
                appleVarietyId: orderItemId,
                pounds: 1,
            }

            createOrderItem(orderItem).then(() => {
                getOrderById(orderId).then(setOrder)
            })
        }
    }

    const handleDecreaseItem = (orderItemId) => {
        // If the Apple is already in the Order
        if (order.orderItems.some(oi => oi.appleVarietyId == orderItemId)) {
            let orderItem = order.orderItems.find(oi => oi.appleVarietyId == orderItemId)

            decreaseOrderItem(orderItem.id).then(() => {
                getOrderById(orderId).then(setOrder)
            })
        }
    }

    const handleDeleteItem = (orderItemId) => {
        deleteOrderItem(orderItemId).then(() => {
            getOrderById(orderId).then(setOrder)
        })
    }

    const handleSubmitOrder = () => {
        if (order.orderItems.length < 1) {
            console.log("You can't do that")
        } else {
            submitOrder(order.id).then(() => {
                navigate("/orderhistory")
            })
        }
    }

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
                            <th></th>
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
                                <th>
                                    <button onClick={() => {
                                        // remove 0.5 pounds of apples
                                        handleDecreaseItem(oi.appleVarietyId)
                                    }}>
                                        <i className="fa-solid fa-circle-minus"></i>
                                    </button>
                                    <input
                                        // display how many pounds of apples have been added to the order
                                        type="text"
                                        readOnly
                                        value={handleDisplayedItemPounds(oi.appleVarietyId)}
                                    />
                                    <button onClick={() => {
                                        // add the item or increase the item by 0.5 if it already exists
                                        handleIncreaseItem(oi.appleVarietyId)
                                    }}>
                                        <i className="fa-solid fa-circle-plus"></i>
                                    </button>
                                </th>
                                <th>${oi.appleVariety.costPerPound}</th>
                                <th>${oi.totalItemCost}</th>
                                <th>
                                    <Button onClick={() => {
                                        handleDeleteItem(oi.id)
                                    }}>
                                        Delete Item
                                    </Button>
                                </th>
                            </tr>
                        ))}
                    </tbody>
                    <tbody>
                        <tr>
                            <th></th>
                            <th></th>
                            <th></th>
                            <th>Total: ${order.totalCost}</th>
                            <th></th>
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