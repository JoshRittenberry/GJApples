import { useState } from "react";
import { register } from "../../managers/authManager";
import { Link, useNavigate } from "react-router-dom";
import { Button, FormFeedback, FormGroup, Input, Label } from "reactstrap";
import { Footer } from "../Footer"
import "../stylesheets/register.css"

export const NewEmployee = ({setLoggedInUser}) => {
    const [firstName, setFirstName] = useState("");
    const [lastName, setLastName] = useState("");
    const [userName, setUserName] = useState("");
    const [email, setEmail] = useState("");
    const [address, setAddress] = useState("");
    const [password, setPassword] = useState("");

    const navigate = useNavigate();

    const handleSubmit = (e) => {

    };

    return (
        <>
            <div className="container register-container" style={{ maxWidth: "500px" }}>
                <h3>Create an Employee Account</h3>
                <FormGroup>
                    <Label>First Name</Label>
                    <Input
                        type="text"
                        value={firstName}
                        onChange={(e) => {
                            setFirstName(e.target.value);
                        }}
                    />
                </FormGroup>
                <FormGroup>
                    <Label>Last Name</Label>
                    <Input
                        type="text"
                        value={lastName}
                        onChange={(e) => {
                            setLastName(e.target.value);
                        }}
                    />
                </FormGroup>
                <FormGroup>
                    <Label>Email</Label>
                    <Input
                        type="email"
                        value={email}
                        onChange={(e) => {
                            setEmail(e.target.value);
                        }}
                    />
                </FormGroup>
                <FormGroup>
                    <Label>User Name</Label>
                    <Input
                        type="text"
                        value={userName}
                        onChange={(e) => {
                            setUserName(e.target.value);
                        }}
                    />
                </FormGroup>
                <FormGroup>
                    <Label>Address</Label>
                    <Input
                        type="text"
                        value={address}
                        onChange={(e) => {
                            setAddress(e.target.value);
                        }}
                    />
                </FormGroup>
                <FormGroup>
                    <Label>Password</Label>
                    <Input
                        type="password"
                        value={password}
                        onChange={(e) => {
                            setPassword(e.target.value);
                        }}
                    />
                </FormGroup>
                <div className="register-container-options">
                    <Button
                        color="primary"
                        onClick={handleSubmit}
                    >
                        Create Account
                    </Button>
                </div>
            </div>
            <Footer />
        </>
    );
}