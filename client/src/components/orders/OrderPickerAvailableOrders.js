import { Button, Table } from "reactstrap"
import { assignOrderPicker, getOrderPickerAssignment } from "../../managers/orderManager"

export const OrderPickerAvailableOrders = ({ loggedInUser, orders, assignedOrder, setAssignedOrder }) => {
    return (
        <div className="orderpickerhome_body_list">
            <header className="orderpickerhome_body_list_header">
                <h3>Orders Needing Completed</h3>
            </header>
            <Table>
                <thead>
                    <tr>
                        <th>Order ID</th>
                        <th>Order Date</th>
                        {assignedOrder.id == null && <th></th>}
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
                            {assignedOrder?.id == null && (
                                <th>
                                    <Button onClick={() => {
                                        assignOrderPicker(o.id, loggedInUser.id).then(() => {
                                            // Running the code below causes errors... I put a band-aid on it with the reload page
                                            // getOrderPickerAssignment().then(setAssignedOrder())
                                            window.location.reload()
                                        })
                                    }}>
                                        Assign Me
                                    </Button>
                                </th>
                            )}
                        </tr>
                    ))}
                </tbody>
            </Table>
        </div>
    )
}