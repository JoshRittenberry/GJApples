import { useEffect, useState } from "react"
import { useNavigate, useParams } from "react-router-dom"
import { cancelOrder, getOrderById, createOrderItem, decreaseOrderItem, getUnsubmittedOrder, increaseOrderItem, submitOrder, deleteOrderItem } from "../../managers/orderManager"
import { Button, Table, Dropdown, DropdownToggle, DropdownMenu, DropdownItem } from "reactstrap";
import { getAllApples } from "../../managers/appleManager"

export const EditOrder = ({ loggedInUser }) => {
    const [order, setOrder] = useState({})
    const [apples, setApples] = useState([])
    const [newOrderItem, setNewOrderItem] = useState({})
    const [isOpen, setIsOpen] = useState(false)

    const navigate = useNavigate()
    const orderId = useParams().id

    useEffect(() => {
        getOrderById(orderId).then(order => {
            setOrder(order)
            getAllApples().then(apples => {
                let filteredApples = apples.filter(apple => !order.orderItems.some(oi => oi.appleVarietyId == apple.id))
                setApples(filteredApples)
            })
            setNewOrderItem({
                orderId: order.id,
                appleVarietyId: null,
                pounds: 1,
            })
        })

    }, [])

    useEffect(() => {
        if (order.dateCompleted != null || order.employeeUserProfileId != null) {
            navigate("/orderhistory")
        }
    }, [order])

    if (order.orderItems?.length < 1) {
        cancelOrder(orderId).then(() => {
            navigate("/orderhistory")
        })
    }

    const toggleDropdown = () => {
        setIsOpen(!isOpen)
    }

    const handleDisplayedItemPounds = (orderItemId) => {
        if (order.orderItems?.some(oi => oi.appleVarietyId == orderItemId)) {
            let orderItem = order.orderItems.find(oi => oi.appleVarietyId == orderItemId)

            return `${orderItem.pounds}/lbs`
        }
    }

    const handleIncreaseItem = (orderItemId) => {
        // Make sure the Apple is already in the Order
        if (order.orderItems.some(oi => oi.appleVarietyId == orderItemId)) {
            let orderItem = order.orderItems.find(oi => oi.appleVarietyId == orderItemId)

            increaseOrderItem(orderItem.id).then(() => {
                getOrderById(orderId).then(setOrder)
            })
        }
    }

    const handleDecreaseItem = (orderItemId) => {
        // Make sure the Apple is already in the Order
        if (order.orderItems.some(oi => oi.appleVarietyId == orderItemId)) {
            let orderItem = order.orderItems.find(oi => oi.appleVarietyId == orderItemId)
            if (orderItem.pounds > 1) {
                decreaseOrderItem(orderItem.id).then(() => {
                    getOrderById(orderId).then(setOrder)
                })
            }
        }
    }

    const handleDeleteItem = (orderItemId) => {
        deleteOrderItem(orderItemId).then(() => {
            getOrderById(orderId).then(setOrder)
        })
    }

    const handleAddNewItem = () => {
        createOrderItem(newOrderItem).then(() => {
            getOrderById(orderId).then(order => {
                setOrder(order)
                getAllApples().then(apples => {
                    let filteredApples = apples.filter(apple => !order.orderItems.some(oi => oi.appleVarietyId == apple.id))
                    setApples(filteredApples)
                })
                setNewOrderItem({
                    orderId: order.id,
                    appleVarietyId: null,
                    pounds: 1,
                })
            })
        })
    }

    return (
        <>
            <header className="editorder_header">
                <h1>Edit Order</h1>
                <h3>Order #{order.id}</h3>
                <h3>Customer Id #{order.customerUserProfileId}</h3>
                <h5>Phone: (XXX)-XXX-XXXX</h5>
                <h5>Email: xxx@xxxx.com</h5>
            </header>
            <section className="editorder_body">
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
                        <tr>
                            <th>
                                <Dropdown isOpen={isOpen} toggle={toggleDropdown}>
                                    <DropdownToggle caret>
                                        {newOrderItem.appleVarietyId == null ? "Select an Apple" : apples.find(apple => apple.id === newOrderItem.appleVarietyId).type}
                                    </DropdownToggle>
                                    <DropdownMenu>
                                        {apples.map(apple => (
                                            <DropdownItem key={apple.id} onClick={() => {
                                                let update = {...newOrderItem}
                                                update.appleVarietyId = apple.id
                                                setNewOrderItem(update)
                                            }}>
                                                {apple.type}
                                            </DropdownItem>
                                        ))}
                                    </DropdownMenu>
                                </Dropdown>
                            </th>
                            <th>
                                {newOrderItem.appleVarietyId == null && ("-")}
                                {newOrderItem.appleVarietyId != null && (
                                    `${newOrderItem.pounds} lbs`
                                )}
                            </th>
                            <th>
                                {newOrderItem.appleVarietyId == null && ("-")}
                                {newOrderItem.appleVarietyId != null && (
                                    apples.find(apple => apple.id === newOrderItem.appleVarietyId).costPerPound
                                )}
                            </th>
                            <th>
                                {newOrderItem.appleVarietyId == null && ("-")}
                                {newOrderItem.appleVarietyId != null && (
                                    apples.find(apple => apple.id === newOrderItem.appleVarietyId).costPerPound
                                )}
                            </th>
                            <th>
                                <Button onClick={() => {
                                    handleAddNewItem()
                                }}>
                                    Add New Item
                                </Button>
                            </th>
                        </tr>
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
            <footer className="editorder_footer">
                <h3>Contact Us</h3>
                <div className="editorder_footer_address">
                    <p>2584 Orchard Lane</p>
                    <p>Mount Juliet, TN 37122</p>
                </div>
                <div className="editorder_footer_contactinfo">
                    <p>Phone Number: (615) 502-7483</p>
                    <p>Email: contact@garyjonesappleorchard.com</p>
                </div>
            </footer>
        </>
    )
}