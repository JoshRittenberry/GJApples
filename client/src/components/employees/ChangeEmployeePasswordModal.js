import { useEffect, useState } from "react"
import { Button, Form, FormGroup, Input, Label, Modal, ModalBody, ModalFooter, ModalHeader } from "reactstrap"
import { getAllRoles, getUserWithRoles, updateEmployeeRole } from "../../managers/employeeManager"

export const ChangeEmployeePasswordModal = ({ passwordModal, togglePasswordModal, selectedEmployee, setSelectedEmployee, args }) => {


    useEffect(() => {

    }, [])

    return (
        <Modal isOpen={passwordModal} togglePasswordModal={togglePasswordModal} {...args}>
            <ModalHeader togglePasswordModal={togglePasswordModal}>Reset {selectedEmployee.firstName} {selectedEmployee.lastName}'s Password</ModalHeader>
            <ModalBody>
                <Form>
                    <FormGroup>
                        <Label for="position">
                            Change Password
                        </Label>
                    </FormGroup>
                </Form>
            </ModalBody>
            <ModalFooter>
                <Button color="primary" onClick={() => {
                    togglePasswordModal()
                }}>
                    Submit
                </Button>
                <Button color="secondary" onClick={() => {
                    togglePasswordModal()
                }}>
                    Cancel
                </Button>
            </ModalFooter>
        </Modal>
    )
}