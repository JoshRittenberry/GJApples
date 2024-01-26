import { useEffect, useState } from "react"
import { ContactUsFooter } from "../ContactUsFooter"
import { HarvesterAvailableTrees } from "../trees/HarvesterAvailableTrees"
import { getAllUnassignedTrees } from "../../managers/treeManager"

export const HarvesterHome = ({ loggedInUser }) => {
    const [trees, setTrees] = useState([])
    const [assignedTree, setAssignedTree] = useState({})

    useEffect(() => {
        getAllUnassignedTrees().then(setTrees)
    }, [])

    return (
        <>
            <header className="harvesterhome_header">
                <h1>Harvester Home Page</h1>
            </header>
            <section className="harvesterhome_body">
                <HarvesterAvailableTrees loggedInUser={loggedInUser} trees={trees} assignedTree={assignedTree} setAssignedTree={setAssignedTree} />
            </section>
            <ContactUsFooter />
        </>
    )
}