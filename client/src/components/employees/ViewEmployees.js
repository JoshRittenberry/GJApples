import { Button, Table } from "reactstrap";
import { getAllHarvesters, getAllOrderPickers } from "../../managers/employeeManager";
import "../stylesheets/viewEmployees.css"
import React, { useEffect, useState } from 'react';

export const ViewEmployees = ({ loggedInUser }) => {
    const [orderPickers, setOrderPickers] = useState([])
    const [harvesters, setHarvesters] = useState([])
    const [employees, setEmployees] = useState([])

    useEffect(() => {
        getAllOrderPickers().then((op) => {
            setOrderPickers(op);
            getAllHarvesters().then((h) => {
                setHarvesters(h);
                const combinedEmployees = [...op, ...h];
                combinedEmployees.sort((a, b) => a.id - b.id);
                setEmployees(combinedEmployees);
            });
        });
    }, []);

    return (
        <>
            <div classname="viewemployees">
                <header className="viewemployees_header">
                    <h1>View Employees</h1>
                </header>
                <section className="viewemployees_section">
                    <Table>
                        <thead>
                            <tr>
                                <th>Id</th>
                                <th>Position</th>
                                <th>First Name</th>
                                <th>Last Name</th>
                                <th>Address</th>
                                <th>Email</th>
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
                                        <th>
                                            employee position
                                        </th>
                                        <th>{e.firstName}</th>
                                        <th>{e.lastName}</th>
                                        <th>{e.address}</th>
                                        <th>{e.email}</th>
                                        <th>
                                            <Button>
                                                Something
                                            </Button>
                                        </th>
                                    </tr>
                                )
                            })}
                        </tbody>
                    </Table>
                </section>
            </div>
        </>
    )
}