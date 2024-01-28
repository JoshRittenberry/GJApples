import { useEffect, useState } from "react"
import "../stylesheets/cart.css"
import { decreaseOrderItem, deleteOrderItem, getOrderById, getUnsubmittedOrder, increaseOrderItem, submitOrder } from "../../managers/orderManager"
import { Button, Dropdown, DropdownToggle, Input, Table } from "reactstrap"
import { Footer } from "../Footer"
import { useNavigate } from "react-router-dom"

export const Cart = ({ loggedInUser }) => {
    const [order, setOrder] = useState({})

    const navigate = useNavigate()

    useEffect(() => {
        getUnsubmittedOrder().then(order => {
            setOrder(order)
        })
    })

    const handleDisplayedItemPounds = (orderItemId) => {
        if (order.orderItems?.some(oi => oi.appleVarietyId == orderItemId)) {
            let orderItem = order.orderItems.find(oi => oi.appleVarietyId == orderItemId)

            return `${orderItem.pounds} lbs`
        }
    }

    const handleIncreaseItem = (orderItemId) => {
        // Make sure the Apple is already in the Order
        if (order.orderItems.some(oi => oi.id == orderItemId)) {
            increaseOrderItem(orderItemId).then(() => {
                getOrderById(order.id).then(setOrder)
            })
        }
    }

    const handleDecreaseItem = (orderItemId) => {
        // Make sure the Apple is already in the Order
        if (order.orderItems.some(oi => oi.id == orderItemId)) {
            let orderItem = order.orderItems.find(oi => oi.id == orderItemId)
            if (orderItem.pounds > 1) {
                decreaseOrderItem(orderItem.id).then(() => {
                    getOrderById(order.id).then(setOrder)
                })
            }
        }
    }

    const handleDeleteItem = (orderItemId) => {
        deleteOrderItem(orderItemId).then(() => {
            getOrderById(order.id).then(setOrder)
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
            <div className="cart">
                <header className="cart_header">
                    <h3>My Cart</h3>
                </header>
                <section className="cart_body">
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
                                    <th className="cart_body_buttons">
                                        <button className="cart_body_buttons_subtract" onClick={() => {
                                            // remove 0.5 pounds of apples
                                            handleDecreaseItem(oi.id)
                                        }}>
                                            <i className="fa-solid fa-circle-minus"></i>
                                        </button>
                                        <Input
                                            // display how many pounds of apples have been added to the order
                                            type="text"
                                            readOnly
                                            value={handleDisplayedItemPounds(oi.appleVarietyId)}
                                            className="cart_body_buttons_input"
                                        />
                                        <button className="cart_body_buttons_add" onClick={() => {
                                            // add the item or increase the item by 0.5 if it already exists
                                            handleIncreaseItem(oi.id)
                                        }}>
                                            <i className="fa-solid fa-circle-plus"></i>
                                        </button>
                                    </th>
                                    <th>${oi.appleVariety.costPerPound}</th>
                                    <th>${oi.totalItemCost}</th>
                                    <th className="cart_body_options">
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
                                <th className="cart_footer_options">
                                    <Button onClick={() => {
                                        handleSubmitOrder()
                                    }}>
                                        Submit
                                    </Button>
                                </th>
                            </tr>
                        </tbody>
                    </Table>
                </section>
            </div>
            <Footer />
        </>
    )
}