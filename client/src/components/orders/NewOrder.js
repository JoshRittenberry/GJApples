import { useEffect, useState } from "react"
import "../stylesheets/newOrder.css"
import { getAllApples } from "../../managers/appleManager"
import { Button, Card, CardBody, CardSubtitle, CardText, CardTitle } from "reactstrap"
import { getCustomerOrders, getUnsubmittedOrder } from "../../managers/orderManager"

export const NewOrder = ({ loggedInUser }) => {
    const [apples, setApples] = useState([])
    const [order, setOrder] = useState({})

    useEffect(() => {
        getAllApples().then(setApples)
        getUnsubmittedOrder().then(setOrder)
    }, [])

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
                        <Card
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
                                        <i class="fa-solid fa-circle-info"></i>
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
                                    <i class="fa-solid fa-circle-minus"></i>
                                </button>
                                <input
                                    // display how many pounds of apples have been added to the order
                                />
                                <button onClick={() => {
                                    // add 0.5 pounds of apples
                                }}>
                                    <i class="fa-solid fa-circle-plus"></i>
                                </button>
                            </CardBody>
                        </Card>
                    )
                })}
            </section>
        </>
    )
}