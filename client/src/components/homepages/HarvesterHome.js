import { useEffect, useState } from "react"
import { ContactUsFooter } from "../ContactUsFooter"
import { HarvesterAvailableTrees } from "../trees/HarvesterAvailableTrees"
import { getAllUnassignedTrees, getHarvesterAssignment } from "../../managers/treeManager"

export const HarvesterHome = ({ loggedInUser }) => {
    const [trees, setTrees] = useState([])
    const [assignedTreeHarvestReport, setAssignedTreeHarvestReport] = useState({})

    useEffect(() => {
        getAllUnassignedTrees().then(setTrees)
        getHarvesterAssignment().then(setAssignedTreeHarvestReport)
    }, [])

    return (
        <>
            <header className="harvesterhome_header">
                <h1>Harvester Home Page</h1>
            </header>
            <section className="harvesterhome_body">
                <HarvesterAvailableTrees loggedInUser={loggedInUser} trees={trees} setTrees={setTrees} assignedTreeHarvestReport={assignedTreeHarvestReport} setAssignedTreeHarvestReport={setAssignedTreeHarvestReport} />
            </section>
            <ContactUsFooter />
        </>
    )
}