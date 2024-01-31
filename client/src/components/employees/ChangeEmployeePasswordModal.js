import "../stylesheets/changeEmployeePasswordModal.css"
import { useEffect, useState } from "react"
import { Button, Col, Form, FormGroup, Input, Label, Modal, ModalBody, ModalFooter, ModalHeader } from "reactstrap"
import { getAllRoles, getUserWithRoles, updateEmployeePassword, updateEmployeeRole } from "../../managers/employeeManager"

export const ChangeEmployeePasswordModal = ({ passwordModal, togglePasswordModal, selectedEmployee, setSelectedEmployee, args }) => {
    const [user, setUser] = useState({})
    const [password, setPassword] = useState({})

    useEffect(() => {
        getUserWithRoles(selectedEmployee.id).then(userRes => {
            setUser(userRes)
            setPassword({
                identityUserId: userRes.identityUserId,
                password: null,
            })
        })
    }, [togglePasswordModal])

    const generateRandomPassword = () => {
        const charset = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*"
        let newPassword = ""

        for (let i = 0; i < 8; i++) {
            const randomIndex = Math.floor(Math.random() * charset.length)
            newPassword += charset[randomIndex]
        }

        let update = {...password}
        update.password = newPassword
        setPassword(update)
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
                                value={password?.password}
                                readOnly
                            />
                        </Col>
                    </FormGroup>
                </Form>
            </ModalBody>
            <ModalFooter>
                {password?.password === null && (
                    <Button color="primary" onClick={() => {
                        generateRandomPassword()
                    }}>
                        Generate Password
                    </Button>
                )}
                {password?.password != null && (
                    <Button color="primary" onClick={() => {
                        updateEmployeePassword(password).then(() => {
                            setPassword(null)
                            togglePasswordModal()
                        })
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