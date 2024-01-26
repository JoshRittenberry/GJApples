import { Button, Input, Table } from "reactstrap"
import { completeHarvesterAssignment, deleteTreeHarvestReport, getAllUnassignedTrees, getHarvesterAssignment } from "../../managers/treeManager"
import { useEffect, useState } from "react"

export const HarvesterAssignedTree = ({ loggedInUser, trees, setTrees, assignedTreeHarvestReport, setAssignedTreeHarvestReport }) => {
    const [thr, setTHR] = useState({})

    useEffect(() => {
        setTHR({
            harvestDate: null,
            poundsHarvested: 0,
        })
    }, [])

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
                                        <Input
                                            type="number"
                                            step="0.5"
                                            value={thr.poundsHarvested}
                                            onChange={event => {
                                                let update = { ...thr }
                                                if (event.target.value < 0 || event.target.value.includes("-")) {
                                                    update.poundsHarvested = 0
                                                    setTHR(update)
                                                } else {
                                                    update.poundsHarvested = Math.round(event.target.value * 2) /2
                                                    setTHR(update)
                                                }
                                            }}
                                        />
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
                                            let update = {...thr}
                                            update.harvestDate = new Date()
                                            completeHarvesterAssignment(assignedTreeHarvestReport.id, update).then(() => {
                                                getAllUnassignedTrees().then(setTrees)
                                                getHarvesterAssignment().then(setAssignedTreeHarvestReport)
                                            })
                                        }}>
                                            Complete Harvest
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