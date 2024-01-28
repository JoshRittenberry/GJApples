import { Button, Input, Table } from "reactstrap"
import { completeOrder, getAllUnassignedOrders, unassignOrderPicker, getOrderPickerAssignment } from "../../managers/orderManager"
import { useEffect, useState } from "react";

export const OrderPickerAssignedOrder = ({ loggedInUser, assignedOrder, setOrders, setAssignedOrder }) => {
    const [screenWidth, setScreenWidth] = useState(window.innerWidth)

    useEffect(() => {
        // Function to update screenWidth state when the window is resized
        const handleResize = () => {
            setScreenWidth(window.innerWidth);
        };

        // Attach the event listener for window resize
        window.addEventListener('resize', handleResize);

        // Clean up the event listener when the component unmounts
        return () => {
            window.removeEventListener('resize', handleResize);
        };
    }, []); // Empty dependency array means this effect runs once after initial render

    return (
        <div className="orderpickerhome_body_assignment" style={{ display: assignedOrder.id == null && screenWidth <= 1200 && 'none' }}>
            {assignedOrder.id > 0 && (
                <>
                    <header className="orderpickerhome_body_assignment_header">
                        <div className="orderpickerhome_body_assignment_header_top">
                            <h3>Order #{assignedOrder.id}</h3>
                        </div>
                        <h5>Customer #{assignedOrder.customerUserProfileId}</h5>
                        <div className="orderpickerhome_body_assignment_header_bottom">
                            <h5>Phone: (XXX)-XXX-XXXX</h5>
                            <h5>Email: xxx@xxxx.com</h5>
                        </div>
                    </header>
                    <section className="orderpickerhome_body_assignment_body">
                        <Table>
                            <thead>
                                <tr>
                                    <th style={{ textAlign: `left` }}>Apple Variety</th>
                                    <th style={{ textAlign: `center` }}>Pounds</th>
                                    <th style={{ textAlign: `right` }}>Filled</th>
                                </tr>
                            </thead>
                            <tbody>
                                {assignedOrder.orderItems?.map((oi) => (
                                    <tr key={`orderitem-${oi.id}`}>
                                        <th
                                            scope="row"
                                            style={{ textAlign: `left` }}
                                        >
                                            {oi.appleVariety?.type}
                                        </th>
                                        <th style={{ textAlign: `center` }}>{oi.pounds} lbs</th>
                                        <th style={{textAlign: `right`}}>
                                            <Input type="checkbox" />
                                        </th>
                                    </tr>
                                ))}
                            </tbody>
                        </Table>
                        <div className="orderpickerhome_body_assignment_body_button_container">
                            <Button onClick={() => {
                                unassignOrderPicker(assignedOrder.id, loggedInUser.id).then(() => {
                                    getAllUnassignedOrders().then(setOrders)
                                    getOrderPickerAssignment().then(setAssignedOrder)
                                })
                            }}>
                                Unassign Me
                            </Button>
                            <Button onClick={() => {
                                completeOrder(assignedOrder.id).then(() => {
                                    getAllUnassignedOrders().then(setOrders)
                                    getOrderPickerAssignment().then(setAssignedOrder)
                                })
                            }}>
                                Complete Order
                            </Button>
                        </div>
                    </section>
                </>
            )}
            {assignedOrder.id == null && (
                <>
                    <h3>Assign an order to see the complete order view</h3>
                </>
            )}
        </div>
    )
}