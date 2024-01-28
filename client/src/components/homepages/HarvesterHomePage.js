import { useEffect, useState } from "react"
import { ContactUsFooter } from "../ContactUsFooter"
import { HarvesterAvailableTrees } from "../trees/HarvesterAvailableTrees"
import { getAllUnassignedTrees, getHarvesterAssignment } from "../../managers/treeManager"
import { HarvesterAssignedTree } from "../trees/HarvesterAssignedTree"

export const HarvesterHomePage = ({ loggedInUser }) => {
    const [trees, setTrees] = useState([])
    const [assignedTreeHarvestReport, setAssignedTreeHarvestReport] = useState({})

    useEffect(() => {
        getAllUnassignedTrees().then(setTrees)
        getHarvesterAssignment().then(setAssignedTreeHarvestReport)
    }, [])

    return (
        <>
            <div className="harvesterhome">
                <header className="harvesterhome_header">
                    <h1>Harvester Home Page</h1>
                </header>
                <section className="harvesterhome_body">
                    <HarvesterAvailableTrees loggedInUser={loggedInUser} trees={trees} setTrees={setTrees} assignedTreeHarvestReport={assignedTreeHarvestReport} setAssignedTreeHarvestReport={setAssignedTreeHarvestReport} />
                    <HarvesterAssignedTree loggedInUser={loggedInUser} trees={trees} setTrees={setTrees} assignedTreeHarvestReport={assignedTreeHarvestReport} setAssignedTreeHarvestReport={setAssignedTreeHarvestReport} />
                </section>
            </div>
            <ContactUsFooter />
        </>
    )
}