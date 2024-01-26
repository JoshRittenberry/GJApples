import { Button, Table } from "reactstrap"
import { createNewTreeHarvestReport, getAllUnassignedTrees, getHarvesterAssignment } from "../../managers/treeManager"

export const HarvesterAvailableTrees = ({ loggedInUser, trees, setTrees, assignedTreeHarvestReport, setAssignedTreeHarvestReport }) => {

    const lastHarvestDate = (treeHarvestReports) => {
        let harvest = treeHarvestReports.reduce((prev, current) => prev.id > current.id ? prev : current)
        return new Date(harvest.harvestDate).toISOString().split('T')[0]
    }

    const handleAssignTree = (treeId) => {
        let newTreeHarvestReport = {
            treeId: treeId,
            employeeUserProfileId: loggedInUser.id,
        }

        createNewTreeHarvestReport(newTreeHarvestReport).then(() => {
            getAllUnassignedTrees().then(setTrees)
            getHarvesterAssignment().then(setAssignedTreeHarvestReport)
        })
    }

    return (
        <div className="harvesterhome_body_list">
            <header className="harvesterhome_body_list_header">
                <h3>Available Harvests</h3>
            </header>
            <section className="harvesterhome_body_list_body">
                <Table>
                    <thead>
                        <tr>
                            <th>Tree Id</th>
                            <th>Apple Variety</th>
                            <th>Last Harvest Date</th>
                            <th></th>
                        </tr>
                    </thead>
                    <tbody>
                        {trees?.map((t) => (
                            <tr key={`order-${t.id}`}>
                                <th
                                    scope="row"
                                >
                                    {t.id}
                                </th>
                                <th>{t.appleVariety.type}</th>
                                <th>{lastHarvestDate(t.treeHarvestReports)}</th>
                                <th>
                                    {assignedTreeHarvestReport?.id == null && (
                                        <Button onClick={() => {
                                            handleAssignTree(t.id)
                                        }}>
                                            Assign Me
                                        </Button>
                                    )}
                                </th>
                            </tr>
                        ))}
                    </tbody>
                </Table>
            </section>
        </div>
    )
}