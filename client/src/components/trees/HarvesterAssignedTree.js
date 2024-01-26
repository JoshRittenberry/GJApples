import { Button, Input, Label, Table } from "reactstrap"
import "../stylesheets/harvesterHomePage.css"
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
                        <div className="orderpickerhome_body_assignment_header_top">
                            <h3>Harvest #{assignedTreeHarvestReport.id}</h3>
                        </div>
                        <h5>Tree #{assignedTreeHarvestReport.treeId}</h5>
                        <div className="orderpickerhome_body_assignment_header_bottom">
                            <h5>Apple Variety: {assignedTreeHarvestReport.tree.appleVariety.type}</h5>
                            <h5>Date Planted: {new Date(assignedTreeHarvestReport.tree.datePlanted).toISOString().split('T')[0]}</h5>
                        </div>
                    </header>
                    <section className="harvesterhome_body_assignment_body">
                        <div className="harvesterhome_body_assignment_body_input">
                            <h5>Pounds Harvested:</h5>
                            <Input
                                type="number"
                                step="0.5"
                                value={thr.poundsHarvested}
                                id="poundsHarvested"
                                onChange={event => {
                                    let update = { ...thr }
                                    if (event.target.value < 0 || event.target.value.includes("-")) {
                                        update.poundsHarvested = 0
                                        setTHR(update)
                                    } else {
                                        update.poundsHarvested = Math.round(event.target.value * 2) / 2
                                        setTHR(update)
                                    }
                                }}
                            />
                        </div>
                        <div className="harvesterhome_body_assignment_body_buttons">
                            <Button onClick={() => {
                                deleteTreeHarvestReport(assignedTreeHarvestReport.id).then(() => {
                                    getAllUnassignedTrees().then(setTrees)
                                    getHarvesterAssignment().then(setAssignedTreeHarvestReport)
                                })
                            }}>
                                Unassign Me
                            </Button>
                            <Button onClick={() => {
                                let update = { ...thr }
                                update.harvestDate = new Date()
                                completeHarvesterAssignment(assignedTreeHarvestReport.id, update).then(() => {
                                    getAllUnassignedTrees().then(setTrees)
                                    getHarvesterAssignment().then(setAssignedTreeHarvestReport)
                                })
                            }}>
                                Complete Harvest
                            </Button>
                        </div>
                    </section>
                </>
            )}
            {assignedTreeHarvestReport.id == null && (
                <>
                    <h3>Assign a Tree to see this</h3>
                </>
            )}
        </div>
    )
}