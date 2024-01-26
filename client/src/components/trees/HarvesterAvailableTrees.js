import { Button, Table } from "reactstrap"
import { createNewTreeHarvestReport, getAllUnassignedTrees } from "../../managers/treeManager"

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
            // Running the code below causes errors... I put a band-aid on it with the reload page
            // getAllUnassignedTrees().then(setTrees())
            window.location.reload()
        })
    }

    return (
        <div className="orderpickerhome_body_list">
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
        </div>
    )
}