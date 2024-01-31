import { useEffect, useState } from "react"
import { Button, Form, FormGroup, Input, Label, Modal, ModalBody, ModalFooter, ModalHeader } from "reactstrap"
import { getAllRoles, getUserWithRoles } from "../../managers/employeeManager"

export const ChangeEmployeeRoleModal = ({ modal, toggle, selectedEmployee, setSelectedEmployee, args }) => {
    const [roles, setRoles] = useState([])
    const [user, setUser] = useState([])
    const [currentRole, setCurrentRole] = useState({})

    useEffect(() => {
        getAllRoles().then(rolesRes => {
            setRoles(rolesRes)
            getUserWithRoles(selectedEmployee.id).then(userRes => {
                setUser(userRes)
                const userRole = rolesRes.find(role => userRes.roles?.includes(role.name))
                setCurrentRole(userRole)
            })
        })
    }, [toggle])

    return (
        <Modal isOpen={modal} toggle={toggle} {...args}>
            <ModalHeader toggle={toggle}>Edit {selectedEmployee.firstName} {selectedEmployee.lastName}'s Position</ModalHeader>
            <ModalBody>
                <Form>
                    <FormGroup>
                        <Label for="position">
                            Position
                        </Label>
                        <Input
                            id="position"
                            name="select"
                            type="select"
                            onChange=""
                        >
                            {roles.map(r => {
                                return (
                                    <option key={r.id} selected={r.id === currentRole?.id} value={r.id}>
                                        {r.name}
                                    </option>
                                )
                            })}
                        </Input>
                    </FormGroup>
                </Form>
            </ModalBody>
            <ModalFooter>
                <Button color="primary" onClick={() => {
                    setSelectedEmployee({})
                    toggle()
                }}>
                    Submit
                </Button>{' '}
                <Button color="secondary" onClick={() => {
                    setSelectedEmployee({})
                    toggle()
                }}>
                    Cancel
                </Button>
            </ModalFooter>
        </Modal>
    )
}