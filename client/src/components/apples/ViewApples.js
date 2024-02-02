import "../stylesheets/viewApples.css"
import { useEffect, useState } from "react"
import { Button, Table } from "reactstrap"
import { Footer } from "../Footer"
import { getAllApples } from "../../managers/appleManager"
import { useNavigate } from "react-router-dom"

export const ViewApples = ({ loggedInUser }) => {
    const [apples, setApples] = useState([])
    const [screenWidth, setScreenWidth] = useState(window.innerWidth)
    const [currentPage, setCurrentPage] = useState(1)

    const applesPerPage = 10
    const navigate = useNavigate()

    useEffect(() => {
        getAllApples().then(setApples)

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

    // Calculate the index of the first and last apple to display on the current page
    const indexOfLastApple = currentPage * applesPerPage;
    const indexOfFirstApple = indexOfLastApple - applesPerPage;
    const currentApples = apples.slice(indexOfFirstApple, indexOfLastApple);

    // Function to handle next page
    const nextPage = () => {
        if (indexOfLastApple < apples.length) {
            setCurrentPage(currentPage + 1);
        }
    };

    // Function to handle previous page
    const prevPage = () => {
        if (currentPage > 1) {
            setCurrentPage(currentPage - 1);
        }
    };

    const datePlanted = (apple) => {
        return new Date(apple.datePlanted).toISOString().split('T')[0]
    }

    const dateRemoved = (apple) => {
        if (apple.dateRemoved == null) {
            return `-`
        }
        return new Date(apple.dateRemoved).toISOString().split('T')[0]
    }

    const lastHarvestDate = (appleHarvestReports) => {
        if (appleHarvestReports.length < 1) {
            return "-"
        }
        let harvest = appleHarvestReports.reduce((prev, current) => prev.id > current.id ? prev : current)
        return new Date(harvest.harvestDate).toISOString().split('T')[0]
    }

    const lastHarvester = (appleHarvestReports) => {
        if (appleHarvestReports.length < 1) {
            return "-"
        }
        let harvest = appleHarvestReports.reduce((prev, current) => prev.id > current.id ? prev : current)
        return `${harvest.employee.firstName} ${harvest.employee.lastName}`
    }

    const poundsProduced = (trees) => {
        let pounds = 0
        trees.map(tree => {
            tree.treeHarvestReports.map(thr => {
                pounds += thr.poundsHarvested
            })
        })
        return pounds
    }

    const poundsOrdered = (orderItems) => {
        let pounds = 0
        orderItems.map(item => {
            pounds += item.pounds
        })
        return pounds
    }

    return (
        <>
            <div className="viewapples">
                <header className="viewapples_header">
                    <h1>Apple Manager</h1>
                    <aside className="viewapples_header_inputs">
                        <Button className="viewapples_header_inputs_button" onClick={() => {
                            navigate("/apples/newapple")
                        }}>
                            New Apple
                        </Button>
                    </aside>
                </header>
                <section className="viewapples_body">
                    <Table>
                        <thead>
                            <tr>
                                <th>Apple Id</th>
                                <th>Variety</th>
                                <th>Cost Per Pound</th>
                                <th>Number of Trees</th>
                                <th>Pounds Produced</th>
                                <th>Pounds Purchased</th>
                                <th>Pounds Available</th>
                                <th></th>
                                {loggedInUser.roles.includes("Admin") && <th></th>}
                            </tr>
                        </thead>
                        <tbody>
                            {currentApples?.map((a) => (
                                <tr key={`order-${a.id}`}>
                                    <th scope="row">{a.id}</th>
                                    <th>{a.type}</th>
                                    <th>{a.costPerPound}</th>
                                    <th>{a.trees?.filter(tree => tree.dateRemoved == null).length}</th>
                                    <th>{poundsProduced(a.trees)}</th>
                                    <th>{poundsOrdered(a.orderItems)}</th>
                                    <th>{poundsProduced(a.trees) - poundsOrdered(a.orderItems)}</th>
                                    {loggedInUser.roles.includes("Admin") && (
                                        <th>
                                            <Button className="viewapples_body_button" onClick={() => {
                                                navigate(`/apples/edit/${a.id}`)
                                            }}>
                                                Edit
                                            </Button>
                                        </th>
                                    )}
                                </tr>
                            ))}
                        </tbody>
                    </Table>
                </section>
                <div className="viewapples_body_pagination">
                    <Button className="viewapples_body_button" onClick={prevPage} disabled={currentPage === 1}>
                        Previous
                    </Button>
                    <Button className="viewapples_body_button" onClick={nextPage} disabled={indexOfLastApple >= apples.length}>
                        Next
                    </Button>
                </div>
            </div>
            <Footer />
        </>
    )
}