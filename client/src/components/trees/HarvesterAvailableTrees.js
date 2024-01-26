import { Button, Input, Table } from "reactstrap"

export const HarvesterAvailableTrees = ({ loggedInUser, trees, assignedTree, setAssignedTree }) => {

    const lastHarvestDate = (treeHarvestReports) => {
        let harvest = treeHarvestReports.reduce((prev, current) => prev.id > current.id ? prev : current)
        return new Date(harvest.harvestDate).toISOString().split('T')[0]
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
                                {assignedTree?.id == null && (
                                    <Button onClick={() => {

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