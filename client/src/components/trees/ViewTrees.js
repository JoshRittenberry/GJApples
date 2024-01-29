import "../stylesheets/viewTrees.css"
import { useEffect, useState } from "react"
import { Button, Table } from "reactstrap"
import { Footer } from "../Footer"
import { getAllTrees } from "../../managers/treeManager"

export const ViewTrees = ({ loggedInUser }) => {
    const [trees, setTrees] = useState([])
    const [screenWidth, setScreenWidth] = useState(window.innerWidth)

    useEffect(() => {
        getAllTrees().then(setTrees)

        // Function to update screenWidth state when the window is resized
        const handleResize = () => {
            setScreenWidth(window.innerWidth);
        };

        // Attach the event listener for window resize
        window.addEventListener('resize', handleResize);

        // Clean up the event listener when the component unmounts
        return () => {
            window.removeEventListener('resize', handleResize);
        };
    }, [])

    const datePlanted = (tree) => {
        return new Date(tree.datePlanted).toISOString().split('T')[0]
    }

    const dateRemoved = (tree) => {
        if (tree.dateRemoved == null) {
            return `-`
        }
        return new Date(tree.dateRemoved).toISOString().split('T')[0]
    }

    const lastHarvestDate = (treeHarvestReports) => {
        let harvest = treeHarvestReports.reduce((prev, current) => prev.id > current.id ? prev : current)
        return new Date(harvest.harvestDate).toISOString().split('T')[0]
    }

    const lastHarvester = (treeHarvestReports) => {
        let harvest = treeHarvestReports.reduce((prev, current) => prev.id > current.id ? prev : current)
        return `${harvest.employee.firstName} ${harvest.employee.lastName}`
    }

    const poundsProduced = (treeHarvestReports) => {
        let pounds = 0
        let harvest = treeHarvestReports.map(thr => pounds += thr.poundsHarvested)
        return pounds
    }

    return (
        <>
            <div className="viewtrees">
                <header className="viewtrees_header">
                    <h1>Tree Manager</h1>
                </header>
                <section className="viewtrees_body">
                    <Table>
                        <thead>
                            <tr>
                                <th>Tree Id</th>
                                <th>Apple Variety</th>
                                {screenWidth > 800 && <th>Date Planted</th>}
                                {screenWidth > 800 && <th>Date Removed</th>}
                                {screenWidth > 800 && <th>Last Harvest Date</th>}
                                {screenWidth > 800 && <th>Last Harvester</th>}
                                {screenWidth > 800 && <th>Pounds Produced</th>}
                                {loggedInUser.roles.includes("Admin") && <th></th>}
                            </tr>
                        </thead>
                        <tbody>
                            {trees?.map((t) => (
                                <tr key={`order-${t.id}`}>
                                    <th
                                        style={{ color: t.dateRemoved != null ? 'red' : 'black' }}
                                        scope="row"
                                    >
                                        {t.id}
                                    </th>
                                    <th style={{ color: t.dateRemoved != null ? 'red' : 'black' }}>{t.appleVariety.type}</th>
                                    {screenWidth > 800 && <th style={{ color: t.dateRemoved != null ? 'red' : 'black' }}>{datePlanted(t)}</th>}
                                    {screenWidth > 800 && <th style={{ color: t.dateRemoved != null ? 'red' : 'black' }}>{dateRemoved(t)}</th>}
                                    {screenWidth > 800 && <th style={{ color: t.dateRemoved != null ? 'red' : 'black' }}>{lastHarvestDate(t.treeHarvestReports)}</th>}
                                    {screenWidth > 800 && <th style={{ color: t.dateRemoved != null ? 'red' : 'black' }}>{lastHarvester(t.treeHarvestReports)}</th>}
                                    {screenWidth > 800 && <th style={{ color: t.dateRemoved != null ? 'red' : 'black' }}>{poundsProduced(t.treeHarvestReports)}</th>}
                                    {loggedInUser.roles.includes("Admin") && (
                                        <th>
                                            <Button className="viewtrees_body_button">
                                                Edit
                                            </Button>
                                        </th>
                                    )}
                                </tr>
                            ))}
                        </tbody>
                    </Table>
                </section>
            </div>
            <Footer />
        </>
    )
}