import { useEffect, useState } from "react"
import "../stylesheets/newOrder.css"
import { getAllApples } from "../../managers/appleManager"
import { Button, Card, CardBody, CardSubtitle, CardText, CardTitle } from "reactstrap"
import { createOrderItem, getCustomerOrders, getUnsubmittedOrder, increaseOrderItem } from "../../managers/orderManager"

export const NewOrder = ({ loggedInUser }) => {
    const [apples, setApples] = useState([])
    const [order, setOrder] = useState({})

    useEffect(() => {
        getAllApples().then(setApples)
        getUnsubmittedOrder().then(setOrder)
    }, [])

    const handleDisplayedItemCost = (appleId) => {
        if (order.orderItems.some(oi => oi.appleVarietyId == appleId)) {
            let orderItem = order.orderItems.find(oi => oi.appleVarietyId == appleId)
            
            return orderItem.pounds
        }
    }

    const handleAddOrIncreaseItem = (appleId) => {
        // If the Apple is already in the Order
        if (order.orderItems.some(oi => oi.appleVarietyId == appleId)) {
            let orderItem = order.orderItems.find(oi => oi.appleVarietyId == appleId)

            increaseOrderItem(orderItem.id).then(() => {
                getUnsubmittedOrder().then(setOrder)
            })
        }
        // If the Apple is not already in the Order
        else if (!order.orderItems.some(oi => oi.appleVarietyId == appleId)) {
            let orderItem = {
                orderId: order.id,
                appleVarietyId: appleId,
                pounds: 1,
            }

            createOrderItem(orderItem).then(() => {
                getUnsubmittedOrder().then(setOrder)
            })
        }
    }

    return (
        <>
            <header className="neworder_header">
                <h1>Create New Order</h1>
                <input
                // display the total cost of the order
                />
                <Button>
                    Submit Order
                </Button>
            </header>
            <section className="neworder_body">
                {apples.map(apple => {
                    return (
                        <Card key={`apple-${apple.id}`}
                            style={{
                                width: '18rem'
                            }}
                        >
                            <img
                                alt="Sample"
                                src="https://picsum.photos/300/200"
                            />
                            <CardBody>
                                <CardTitle tag="h5">
                                    {apple.type}
                                    <button>
                                        <i className="fa-solid fa-circle-info"></i>
                                    </button>
                                </CardTitle>
                                <CardSubtitle
                                    className="mb-2 text-muted"
                                    tag="h6"
                                >
                                    ${apple.costPerPound}/lbs
                                </CardSubtitle>
                                <button onClick={() => {
                                    // remove 0.5 pounds of apples
                                }}>
                                    <i className="fa-solid fa-circle-minus"></i>
                                </button>
                                <input
                                    // display how many pounds of apples have been added to the order
                                    type="number"
                                    readOnly
                                    value={handleDisplayedItemCost(apple.id)}
                                />
                                <button onClick={() => {
                                    // add the item or increase the item by 0.5 if it already exists
                                    handleAddOrIncreaseItem(apple.id)
                                }}>
                                    <i className="fa-solid fa-circle-plus"></i>
                                </button>
                            </CardBody>
                        </Card>
                    )
                })}
            </section>
        </>
    )
}