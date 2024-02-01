import { Button, Table } from "reactstrap"
import { getAllAdmin, getAllHarvesters, getAllOrderPickers } from "../../managers/customerManager"
import React, { useEffect, useState } from 'react'
import { Footer } from "../Footer"
import "../stylesheets/viewCustomers.css"
import { useNavigate } from "react-router-dom"
import { ChangeCustomerPositionModal } from "./ChangeCustomerPositionModal"
import { ChangeCustomerPasswordModal } from "./ChangeCustomerPasswordModal"

export const ViewCustomers = ({ loggedInUser }) => {
    const [customers, setCustomers] = useState([])
    const [selectedCustomer, setSelectedCustomer] = useState({})
    const [screenWidth, setScreenWidth] = useState(window.innerWidth)
    const [currentPage, setCurrentPage] = useState(1)
    const [positionModal, setPositionModal] = useState(false)
    const [passwordModal, setPasswordModal] = useState(false)


    const customersPerPage = 10
    const navigate = useNavigate()
    const togglePositionModal = () => setPositionModal(!positionModal)
    const togglePasswordModal = () => setPasswordModal(!passwordModal)

    useEffect(() => {

        // Need a funciton to get all customers

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
    const indexOfLastCustomer = currentPage * customersPerPage
    const indexOfFirstCustomer = indexOfLastCustomer - customersPerPage
    const currentCustomers = customers.slice(indexOfFirstCustomer, indexOfLastCustomer)

    // Function to handle next page
    const nextPage = () => {
        if (indexOfLastCustomer < customers.length) {
            setCurrentPage(currentPage + 1)
        }
    }

    // Function to handle previous page
    const prevPage = () => {
        if (currentPage > 1) {
            setCurrentPage(currentPage - 1)
        }
    }

    const customerPosition = (customerId) => {
        const orderPicker = orderPickers.find((picker) => picker.id === customerId)
        const harvester = harvesters.find((harvester) => harvester.id === customerId)
        const admin = admins.find((admin) => admin.id === customerId)

        if (orderPicker) {
            return "Order Picker"
        } else if (harvester) {
            return "Harvester"
        } else if (admin) {
            return "Admin"
        } else {
            return "N/A"
        }
    }

    return (
        <>
            <div className="viewcustomers">
                <header className="viewcustomers_header">
                    <h1>Customers</h1>
                    <aside className="viewcustomers_header_inputs">
                        {/* Place for buttons if needed */}
                    </aside>
                </header>
                <section className="viewcustomers_body">
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
                            {customers.map((e) => {
                                return (
                                    <tr key={`customer-${e.id}`}>
                                        <th scope="row">
                                            {e.id}
                                        </th>
                                        <th>{e.firstName}</th>
                                        <th>{e.lastName}</th>
                                        {screenWidth > 700 && <th>{customerPosition(e.id)}</th>}
                                        {screenWidth > 900 && <th>{e.address}</th>}
                                        {screenWidth > 600 && <th>{e.email}</th>}
                                        <th>
                                            <button className="viewcustomers_body_button_edit" onClick={() => {
                                                navigate(`/customers/edit/${e.id}`)
                                            }}>
                                                <i className="fa-solid fa-pen-to-square"></i>
                                            </button>
                                            <button className="viewcustomers_body_button_position" onClick={() => {
                                                setSelectedCustomer(e)
                                                togglePositionModal()
                                            }}>
                                                <i className="fa-solid fa-briefcase"></i>
                                            </button>
                                            <button className="viewcustomers_body_button_reset" onClick={() => {
                                                setSelectedCustomer(e)
                                                togglePasswordModal()
                                            }}>
                                                <i className="fa-solid fa-key"></i>
                                            </button>
                                        </th>
                                    </tr>
                                )
                            })}
                        </tbody>
                    </Table>
                </section>
                {customers.length > 10 && (
                    <div className="viewcustomers_body_pagination">
                        <Button className="viewcustomers_body_button" onClick={prevPage} disabled={currentPage === 1}>
                            Previous
                        </Button>
                        <Button className="viewcustomers_body_button" onClick={nextPage} disabled={indexOfLastCustomer >= customers.length}>
                            Next
                        </Button>
                    </div>
                )}
            </div>
            <ChangeCustomerPositionModal positionModal={positionModal} togglePositionModal={togglePositionModal} selectedCustomer={selectedCustomer} setSelectedCustomer={setSelectedCustomer} />
            <ChangeCustomerPasswordModal passwordModal={passwordModal} togglePasswordModal={togglePasswordModal} selectedCustomer={selectedCustomer} setSelectedCustomer={setSelectedCustomer} />
            <Footer />
        </>
    )
}