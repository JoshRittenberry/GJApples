import { useState } from "react";
import { NavLink as RRNavLink } from "react-router-dom";
import {
    Button,
    Collapse,
    Nav,
    NavLink,
    NavItem,
    Navbar,
    NavbarBrand,
    NavbarToggler,
    UncontrolledDropdown,
    DropdownMenu,
    DropdownItem,
    DropdownToggle
} from "reactstrap";
import { logout } from "../managers/authManager";
import "./stylesheets/navBar.css"

export default function NavBar({ loggedInUser, setLoggedInUser }) {
    const [open, setOpen] = useState(false);

    const toggleNavbar = () => setOpen(!open);

    return (
        <div>
            <Navbar color="light" light fixed="true" expand="lg">
                <NavbarBrand className="mr-auto" tag={RRNavLink} to="/">
                    <img src="https://i.ibb.co/9NWqd8x/Logo.png" className="nav-logo" alt="GJApples_Logo" /> Garry Jones' Apple Orchard
                </NavbarBrand>
                {loggedInUser ? (
                    <Nav navbar>
                        {
                            loggedInUser.roles.includes("Customer") && (
                                <>
                                    <NavItem>
                                        <NavLink href="/order">Order</NavLink>
                                    </NavItem>
                                    <NavItem>
                                        <NavLink href="/orderhistory">Order History</NavLink>
                                    </NavItem>
                                </>
                            )
                        }
                        {
                            loggedInUser.roles.includes("OrderPicker") && (
                                <>
                                    <NavItem>
                                        <NavLink href="/orderpicker">Employee Homepage</NavLink>
                                    </NavItem>
                                </>
                            )
                        }
                        <UncontrolledDropdown nav inNavbar>
                            <DropdownToggle nav caret>
                                More
                            </DropdownToggle>
                            <DropdownMenu right>
                                <DropdownItem>
                                    <NavItem>
                                        <NavLink tag={RRNavLink} to="/history">
                                            History
                                        </NavLink>
                                    </NavItem>
                                </DropdownItem>
                                <DropdownItem>
                                    <NavItem>
                                        <NavLink tag={RRNavLink} to="/contactus">
                                            Contact Us
                                        </NavLink>
                                    </NavItem>
                                </DropdownItem>
                                <DropdownItem divider />
                                <DropdownItem>
                                    <NavItem>
                                        <NavLink tag={RRNavLink} to="/login" onClick={(e) => {
                                            e.preventDefault();
                                            setOpen(false);
                                            logout().then(() => {
                                                setLoggedInUser(null);
                                                setOpen(false);
                                            });
                                        }}>
                                            Logout
                                        </NavLink>
                                    </NavItem>
                                </DropdownItem>
                            </DropdownMenu>
                        </UncontrolledDropdown>
                    </Nav>
                ) : (
                    <Nav navbar>
                        <UncontrolledDropdown nav inNavbar>
                            <DropdownToggle nav caret>
                                More
                            </DropdownToggle>
                            <DropdownMenu right>
                                <DropdownItem>
                                    <NavItem>
                                        <NavLink tag={RRNavLink} to="/history">
                                            History
                                        </NavLink>
                                    </NavItem>
                                </DropdownItem>
                                <DropdownItem>
                                    <NavItem>
                                        <NavLink tag={RRNavLink} to="/contactus">
                                            Contact Us
                                        </NavLink>
                                    </NavItem>
                                </DropdownItem>
                                <DropdownItem divider />
                                <DropdownItem>
                                    <NavItem>
                                        <NavLink tag={RRNavLink} to="/login">
                                            Login
                                        </NavLink>
                                    </NavItem>
                                </DropdownItem>
                            </DropdownMenu>
                        </UncontrolledDropdown>
                    </Nav>
                )}
            </Navbar>
        </div>
    );
}