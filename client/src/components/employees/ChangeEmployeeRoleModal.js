import { useEffect, useState } from "react"
import { Button, Form, FormGroup, Input, Label, Modal, ModalBody, ModalFooter, ModalHeader } from "reactstrap"
import { getAllRoles } from "../../managers/employeeManager"

export const ChangeEmployeeRoleModal = ({ modal, toggle, selectedEmployee, setSelectedEmployee, args }) => {
    const [roles, setRoles] = useState([])

    useEffect(() => {
        getAllRoles().then(setRoles)
    }, [])

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
                                    <option key={r.id} value={r.id}>
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