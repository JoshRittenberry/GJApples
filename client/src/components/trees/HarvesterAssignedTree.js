import { Button, Input, Table } from "reactstrap"
import { deleteTreeHarvestReport, getAllUnassignedTrees, getHarvesterAssignment } from "../../managers/treeManager"

export const HarvesterAssignedTree = ({ loggedInUser, trees, setTrees, assignedTreeHarvestReport, setAssignedTreeHarvestReport }) => {
    return (
        <div className="harvesterhome_body_assignment">
            {assignedTreeHarvestReport.id > 0 && (
                <>
                    <header className="harvesterhome_body_assignment_header">
                        <h3>Assigned Harvests</h3>
                    </header>
                    <section className="harvesterhome_body_assignment_body">
                        <Table>
                            <thead>
                                <tr>
                                    <th>Tree Id</th>
                                    <th>Apple Variety</th>
                                    {/* Stretch Goal */}
                                    {/* <th>YTD - Pounds Produced</th> */}
                                    <th>Date Planted</th>
                                    <th>Pounds Harvested</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr key={`treeHarvestReport-${assignedTreeHarvestReport.id}`}>
                                    <th
                                        scope="row"
                                    >
                                        {assignedTreeHarvestReport.id}
                                    </th>
                                    <th>{assignedTreeHarvestReport.tree.appleVariety.type}</th>
                                    {/* <th>Pounds Produced</th> */}
                                    <th>{new Date(assignedTreeHarvestReport.tree.datePlanted).toISOString().split('T')[0]}</th>
                                    <th>
                                        <Input type="checkbox" />
                                    </th>
                                </tr>
                            </tbody>
                            <tbody>
                                <tr>
                                    <th>
                                        <Button onClick={() => {
                                            deleteTreeHarvestReport(assignedTreeHarvestReport.id).then(() => {
                                                getAllUnassignedTrees().then(setTrees)
                                                getHarvesterAssignment().then(setAssignedTreeHarvestReport)
                                            })
                                        }}>
                                            Unassign Me
                                        </Button>
                                    </th>
                                    <th></th>
                                    <th></th>
                                    <th>
                                        <Button onClick={() => {
                                            // completeOrder(assignedTreeHarvestReport.id).then(() => {
                                            //     getAllUnassignedOrders().then(setOrders)
                                            //     getOrderPickerAssignment().then(setAssignedOrder)
                                            // })
                                        }}>
                                            Complete Order
                                        </Button>
                                    </th>
                                </tr>
                            </tbody>
                        </Table>
                    </section>
                </>
            )}
            {assignedTreeHarvestReport.id == null && (
                <>
                    <h1>Assign a Tree to see this</h1>
                </>
            )}
        </div>
    )
}