import { Button, Input, Table } from "reactstrap"
import { completeOrder, getAllUnassignedOrders, unassignOrderPicker, getOrderPickerAssignment } from "../../managers/orderManager"

export const OrderPickerAssignedOrder = ({ loggedInUser, assignedOrder, setOrders, setAssignedOrder }) => {
    return (
        <div className="orderpickerhome_body_assignment">
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
                    <h3>Assign an order to see this</h3>
                </>
            )}
        </div>
    )
}