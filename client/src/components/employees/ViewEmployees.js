import { Button, Table } from "reactstrap"
import { getAllHarvesters, getAllOrderPickers } from "../../managers/employeeManager"
import React, { useEffect, useState } from 'react'
import { Footer } from "../Footer"
import "../stylesheets/viewEmployees.css"
import { useNavigate } from "react-router-dom"

export const ViewEmployees = ({ loggedInUser }) => {
    const [orderPickers, setOrderPickers] = useState([])
    const [harvesters, setHarvesters] = useState([])
    const [employees, setEmployees] = useState([])
    const [screenWidth, setScreenWidth] = useState(window.innerWidth)
    const [currentPage, setCurrentPage] = useState(1)

    const employeesPerPage = 10
    const navigate = useNavigate()

    useEffect(() => {
        getAllOrderPickers().then((op) => {
            setOrderPickers(op)
            getAllHarvesters().then((h) => {
                setHarvesters(h)
                const combinedEmployees = [...op, ...h]
                combinedEmployees.sort((a, b) => a.id - b.id)
                setEmployees(combinedEmployees)
            })
        })

        // Function to update screenWidth state when the window is resized
        const handleResize = () => {
            setScreenWidth(window.innerWidth)
        }

        // Attach the event listener for window resize
        window.addEventListener('resize', handleResize)

        // Clean up the event listener when the component unmounts
        return () => {
            window.removeEventListener('resize', handleResize)
        }
    }, [])

    // Calculate the index of the first and last tree to display on the current page
    const indexOfLastEmployee = currentPage * employeesPerPage
    const indexOfFirstEmployee = indexOfLastEmployee - employeesPerPage
    const currentEmployees = employees.slice(indexOfFirstEmployee, indexOfLastEmployee)

    // Function to handle next page
    const nextPage = () => {
        if (indexOfLastEmployee < employees.length) {
            setCurrentPage(currentPage + 1)
        }
    }

    // Function to handle previous page
    const prevPage = () => {
        if (currentPage > 1) {
            setCurrentPage(currentPage - 1)
        }
    }

    const employeePosition = (employeeId) => {
        const orderPicker = orderPickers.find((picker) => picker.id === employeeId);
        const harvester = harvesters.find((harvester) => harvester.id === employeeId);

        if (orderPicker) {
            return "Order Picker";
        } else if (harvester) {
            return "Harvester";
        } else {
            return "N/A";
        }
    }

    return (
        <>
            <div className="viewemployees">
                <header className="viewemployees_header">
                    <h1>View Employees</h1>
                    <aside className="viewemployees_header_inputs">
                        <Button className="viewemployees_header_inputs_button">
                            Click Me
                        </Button>
                    </aside>
                </header>
                <section className="viewemployees_body">
                    <Table>
                        <thead>
                            <tr>
                                <th>Id</th>
                                <th>First Name</th>
                                <th>Last Name</th>
                                {screenWidth > 700 && <th>Position</th>}
                                {screenWidth > 900 && <th>Address</th>}
                                {screenWidth > 600 && <th>Email</th>}
                                <th>Actions</th>
                            </tr>
                        </thead>
                        <tbody>
                            {employees.map((e) => {
                                return (
                                    <tr key={`employee-${e.id}`}>
                                        <th scope="row">
                                            {e.id}
                                        </th>
                                        <th>{e.firstName}</th>
                                        <th>{e.lastName}</th>
                                        {screenWidth > 700 && <th>{employeePosition(e.id)}</th>}
                                        {screenWidth > 900 && <th>{e.address}</th>}
                                        {screenWidth > 600 && <th>{e.email}</th>}
                                        <th>
                                            <Button className="viewemployees_body_button">
                                                Something
                                            </Button>
                                        </th>
                                    </tr>
                                )
                            })}
                        </tbody>
                    </Table>
                </section>
                {employees.length > 10 && (
                    <div className="viewemployees_body_pagination">
                        <Button className="viewemployees_body_button" onClick={prevPage} disabled={currentPage === 1}>
                            Previous
                        </Button>
                        <Button className="viewemployees_body_button" onClick={nextPage} disabled={indexOfLastEmployee >= employees.length}>
                            Next
                        </Button>
                    </div>
                )}
            </div>
            <Footer />
        </>
    )
}