import { useEffect, useState } from "react"
import { Button, Form, FormGroup, Input, Label, Modal, ModalBody, ModalFooter, ModalHeader } from "reactstrap"
import { getAllRoles, getUserWithRoles, updateEmployeeRole } from "../../managers/employeeManager"

export const ChangeEmployeeRoleModal = ({ positionModal, togglePositionModal, selectedEmployee, setSelectedEmployee, args }) => {
    const [roles, setRoles] = useState([])
    const [user, setUser] = useState([])
    const [currentRole, setCurrentRole] = useState({})

    useEffect(() => {
        getAllRoles().then(rolesRes => {
            setRoles(rolesRes.filter(role => role.name !== 'Customer'))
            getUserWithRoles(selectedEmployee.id).then(userRes => {
                setUser(userRes)
                const userRole = rolesRes.find(role => userRes.roles?.includes(role.name))
                setCurrentRole(userRole)
            })
        })
    }, [togglePositionModal])

    return (
        <Modal isOpen={positionModal} togglePositionModal={togglePositionModal} {...args}>
            <ModalHeader togglePositionModal={togglePositionModal}>Edit {selectedEmployee.firstName} {selectedEmployee.lastName}'s Position</ModalHeader>
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
                            onChange={event => {
                                let newRole = roles.find(role => role.id == event.target.value)
                                setCurrentRole(newRole)
                            }}
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
                    if (currentRole != null && user.roles?.[0] !== currentRole.name) {
                        updateEmployeeRole(user?.identityUserId, currentRole?.id).then(() => {
                            setSelectedEmployee({})
                            togglePositionModal()
                            window.location.reload()
                        });
                    }
                }}>
                    Submit
                </Button>
                <Button color="secondary" onClick={() => {
                    setSelectedEmployee({})
                    togglePositionModal()
                }}>
                    Cancel
                </Button>
            </ModalFooter>
        </Modal>
    )
}