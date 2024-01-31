import "../stylesheets/changeEmployeePasswordModal.css"
import { useEffect, useState } from "react"
import { Button, Col, Form, FormGroup, Input, Label, Modal, ModalBody, ModalFooter, ModalHeader } from "reactstrap"
import { getAllRoles, getUserWithRoles, updateEmployeeRole } from "../../managers/employeeManager"

export const ChangeEmployeePasswordModal = ({ passwordModal, togglePasswordModal, selectedEmployee, setSelectedEmployee, args }) => {
    const [password, setPassword] = useState(null)

    useEffect(() => {

    }, [])

    const generateRandomPassword = () => {
        const charset = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*"
        let password = ""

        for (let i = 0; i < 8; i++) {
            const randomIndex = Math.floor(Math.random() * charset.length)
            password += charset[randomIndex]
        }

        setPassword(password)
    }

    return (
        <Modal isOpen={passwordModal} togglePasswordModal={togglePasswordModal} {...args}>
            <ModalHeader togglePasswordModal={togglePasswordModal}>Reset {selectedEmployee.firstName} {selectedEmployee.lastName}'s Password</ModalHeader>
            <ModalBody className="changeemployeepasswordmodal_body">
                <Form className="changeemployeepasswordmodal_form">
                    <FormGroup row>
                        <Label
                            for="password"
                            size="md"
                            sm={2}
                        >
                            Password:
                        </Label>
                        <Col sm={10}>
                            <Input
                                bsSize="md"
                                id="password"
                                type="text"
                                value={password}
                                readOnly
                            />
                        </Col>
                    </FormGroup>
                </Form>
            </ModalBody>
            <ModalFooter>
                {password === null && (
                    <Button color="primary" onClick={() => {
                        generateRandomPassword()
                    }}>
                        Generate Password
                    </Button>
                )}
                {password != null && (
                    <Button color="primary" onClick={() => {
                        setPassword(null)
                        togglePasswordModal()
                    }}>
                        Submit
                    </Button>
                )}
                <Button color="secondary" onClick={() => {
                    setPassword(null)
                    togglePasswordModal()
                }}>
                    Cancel
                </Button>
            </ModalFooter>
        </Modal>
    )
}