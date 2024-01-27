import { useEffect, useState } from "react"
import "../stylesheets/newOrder.css"
import { getAllApples } from "../../managers/appleManager"
import { Button, Card, CardBody, CardFooter, CardSubtitle, CardTitle, Input } from "reactstrap"
import { createOrderItem, decreaseOrderItem, getUnsubmittedOrder, increaseOrderItem, submitOrder } from "../../managers/orderManager"
import { useNavigate } from "react-router-dom"
import { ContactUsFooter } from "../ContactUsFooter"
import { NewOrderSelections } from "./NewOrderSelections"

export const NewOrder = ({ loggedInUser }) => {
    const [apples, setApples] = useState([])
    const [order, setOrder] = useState({})

    const navigate = useNavigate()

    useEffect(() => {
        getAllApples().then(setApples)
        getUnsubmittedOrder().then(setOrder)
    }, [])

    const handleDisplayedItemPounds = (appleId) => {
        if (order.orderItems?.some(oi => oi.appleVarietyId == appleId)) {
            let orderItem = order.orderItems.find(oi => oi.appleVarietyId == appleId)

            return `${orderItem.pounds} lbs`
        } else {
            return ""
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

    const handleDecreaseItem = (appleId) => {
        // If the Apple is already in the Order
        if (order.orderItems.some(oi => oi.appleVarietyId == appleId)) {
            let orderItem = order.orderItems.find(oi => oi.appleVarietyId == appleId)

            decreaseOrderItem(orderItem.id).then(() => {
                getUnsubmittedOrder().then(setOrder)
            })
        }
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
            <header className="neworder_header">
                <h1>Create New Order</h1>
                <aside className="neworder_header_inputs">
                    <Input
                        type="text"
                        readOnly
                        value={`Total: $${order?.totalCost}`}
                    />
                    <Button onClick={() => {
                        handleSubmitOrder()
                    }}>
                        Submit Order
                    </Button>
                </aside>
            </header>
            <NewOrderSelections
                apples={apples}
                order={order}
                setOrder={setOrder}
                handleDisplayedItemPounds={handleDisplayedItemPounds}
                handleAddOrIncreaseItem={handleAddOrIncreaseItem}
                handleDecreaseItem={handleDecreaseItem}
                handleSubmitOrder={handleSubmitOrder}
            />
            <ContactUsFooter />
        </>
    )
}


// return (
//     <>
//         <header className="neworder_header">
//             <h1>Create New Order</h1>
//             <aside className="neworder_header_inputs">
//                 <Input
//                     type="text"
//                     readOnly
//                     value={`Total: $${order?.totalCost}`}
//                 />
//                 <Button onClick={() => {
//                     handleSubmitOrder()
//                 }}>
//                     Submit Order
//                 </Button>
//             </aside>
//         </header>
//         <section className="neworder_body">
//             {apples.map(apple => {
//                 return (
//                     <Card key={`apple-${apple.id}`} className="neworder_body_card">
//                         <img
//                             alt="Sample"
//                             src={apple.imageUrl}
//                             className="neworder_body_card_img"
//                         />
//                         <CardBody>
//                             <CardTitle tag="h5">
//                                 {apple.type}
//                                 {/* Stretch Goal */}
//                                 {/* <button>
//                                     <i className="fa-solid fa-circle-info"></i>
//                                 </button> */}
//                             </CardTitle>
//                             <CardSubtitle
//                                 className="mb-2 text-muted"
//                                 tag="h6"
//                             >
//                                 ${apple.costPerPound}/lbs
//                             </CardSubtitle>
//                             <CardFooter className="neworder_body_card_cardfooter">
//                                 <button className="neworder_body_card_cardfooter_subtract" onClick={() => {
//                                     // remove 0.5 pounds of apples
//                                     handleDecreaseItem(apple.id)
//                                 }}>
//                                     <i className="fa-solid fa-circle-minus"></i>
//                                 </button>
//                                 <Input
//                                     // display how many pounds of apples have been added to the order
//                                     type="text"
//                                     readOnly
//                                     value={handleDisplayedItemPounds(apple.id)}
//                                     className="neworder_body_card_cardfooter_input"
//                                 />
//                                 <button className="neworder_body_card_cardfooter_add" onClick={() => {
//                                     // add the item or increase the item by 0.5 if it already exists
//                                     handleAddOrIncreaseItem(apple.id)
//                                 }}>
//                                     <i className="fa-solid fa-circle-plus"></i>
//                                 </button>
//                             </CardFooter>
//                         </CardBody>
//                     </Card>
//                 )
//             })}
//         </section>
//         <ContactUsFooter />
//     </>
// )