import { useEffect, useState } from "react";
import { Link, NavLink as RRNavLink } from "react-router-dom";
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
import { NavBarButton } from "./NavBarButton";

export default function NavBar({ loggedInUser, setLoggedInUser }) {
    const [click, setClick] = useState(false)
    const [button, setButton] = useState(true)

    useEffect(() => {
        showButton()
    }, [])

    const handleClick = () => {
        setClick(!click)
    }

    const closeMobileMenu = () => {
        setClick(false)
    }

    const showButton = () => {
        if (window.innerWidth <= 960) {
            setButton(false)
        } else {
            setButton(true)
        }
    }

    window.addEventListener('resize', showButton)

    return (
        <>
            <nav className="navbar">
                <div className="navbar-container">
                    <Link to="/" className="navbar-logo" onClick={closeMobileMenu}>
                        GJ's Apples
                    </Link>
                    <div className="menu-icon" onClick={handleClick}>
                        <i className={click ? `fas fa-times` : `fas fa-bars`} />
                    </div>
                    <ul className={click ? `nav-menu active` : `nav-menu`}>
                        {loggedInUser ? (
                            <>
                                {/* Normal Links */}
                                <li className="nav-item">
                                    <Link to="/" className="nav-links" onClick={closeMobileMenu}>
                                        Home
                                    </Link>
                                </li>
                                <li className="nav-item">
                                    <Link to="/history" className="nav-links" onClick={closeMobileMenu}>
                                        History
                                    </Link>
                                </li>
                                <li className="nav-item">
                                    <Link to="/contactus" className="nav-links" onClick={closeMobileMenu}>
                                        Contact Us
                                    </Link>
                                </li>

                                {/* Customer Links */}
                                {loggedInUser.roles.includes("Customer") && (
                                    <>
                                        <li className="nav-item">
                                            <Link to="/order" className="nav-links" onClick={closeMobileMenu}>
                                                Order
                                            </Link>
                                        </li>
                                        <li className="nav-item">
                                            <Link to="/orderhistory" className="nav-links" onClick={closeMobileMenu}>
                                                Order History
                                            </Link>
                                        </li>
                                    </>
                                )}

                                {/* Order Picker Links */}
                                {loggedInUser.roles.includes("OrderPicker") && (
                                    <li className="nav-item">
                                        <Link to="/orderpicker" className="nav-links" onClick={closeMobileMenu}>
                                            Employee Homepage
                                        </Link>
                                    </li>
                                )}

                                {/* Harvester Links */}
                                {loggedInUser.roles.includes("Harvester") && (
                                    <li className="nav-item">
                                        <Link to="/harvester" className="nav-links" onClick={closeMobileMenu}>
                                            Employee Homepage
                                        </Link>
                                    </li>
                                )}

                                {/* Logout */}
                                <li className="nav-item">
                                    <Link to="/login" onClick={(e) => {
                                        e.preventDefault();
                                        // setOpen(false);
                                        logout().then(() => {
                                            setLoggedInUser(null);
                                            // setOpen(false);
                                        });
                                    }}>
                                        Logout
                                    </Link>
                                </li>
                            </>
                        ) : (
                            <>
                                {/* Normal Links */}
                                <li className="nav-item">
                                    <Link to="/" className="nav-links" onClick={closeMobileMenu}>
                                        Home
                                    </Link>
                                </li>
                                <li className="nav-item">
                                    <Link to="/history" className="nav-links" onClick={closeMobileMenu}>
                                        History
                                    </Link>
                                </li>
                                <li className="nav-item">
                                    <Link to="/contactus" className="nav-links" onClick={closeMobileMenu}>
                                        Contact Us
                                    </Link>
                                </li>

                                {/* Login */}
                                <li className="nav-item">
                                    <Link to="/login" className="nav-links" onClick={closeMobileMenu}>
                                        Login
                                    </Link>
                                </li>
                            </>
                        )}
                    </ul>
                    {button && <NavBarButton buttonStyle="btn--outline">Login</NavBarButton>}
                </div>
            </nav>
        </>
    )
}

// My Old Code:
// 
// const [open, setOpen] = useState(false);
// const toggleNavbar = () => setOpen(!open);
// 
// return (
//     <div>
//         <Navbar color="light" light fixed="true" expand="lg">
//             <NavbarBrand className="mr-auto" tag={RRNavLink} to="/">
//                 <img src="https://i.ibb.co/9NWqd8x/Logo.png" className="nav-logo" alt="GJApples_Logo" /> Garry Jones' Apple Orchard
//             </NavbarBrand>
//             {loggedInUser ? (
//                 <Nav navbar>
//                     {
//                         loggedInUser.roles.includes("Customer") && (
//                             <>
//                                 <NavItem>
//                                     <NavLink href="/order">Order</NavLink>
//                                 </NavItem>
//                                 <NavItem>
//                                     <NavLink href="/orderhistory">Order History</NavLink>
//                                 </NavItem>
//                             </>
//                         )
//                     }
//                     {
//                         loggedInUser.roles.includes("OrderPicker") && (
//                             <>
//                                 <NavItem>
//                                     <NavLink href="/orderpicker">Employee Homepage</NavLink>
//                                 </NavItem>
//                             </>
//                         )
//                     }
//                     {
//                         loggedInUser.roles.includes("Harvester") && (
//                             <>
//                                 <NavItem>
//                                     <NavLink href="/harvester">Employee Homepage</NavLink>
//                                 </NavItem>
//                             </>
//                         )
//                     }
//                     <UncontrolledDropdown nav inNavbar>
//                         <DropdownToggle nav caret>
//                             More
//                         </DropdownToggle>
//                         <DropdownMenu end>
//                             <DropdownItem>
//                                 <NavItem>
//                                     <NavLink tag={RRNavLink} to="/history">
//                                         History
//                                     </NavLink>
//                                 </NavItem>
//                             </DropdownItem>
//                             <DropdownItem>
//                                 <NavItem>
//                                     <NavLink tag={RRNavLink} to="/contactus">
//                                         Contact Us
//                                     </NavLink>
//                                 </NavItem>
//                             </DropdownItem>
//                             <DropdownItem divider />
//                             <DropdownItem>
//                                 <NavItem>
//                                     <NavLink tag={RRNavLink} to="/login" onClick={(e) => {
//                                         e.preventDefault();
//                                         setOpen(false);
//                                         logout().then(() => {
//                                             setLoggedInUser(null);
//                                             setOpen(false);
//                                         });
//                                     }}>
//                                         Logout
//                                     </NavLink>
//                                 </NavItem>
//                             </DropdownItem>
//                         </DropdownMenu>
//                     </UncontrolledDropdown>
//                 </Nav>
//             ) : (
//                 <Nav navbar>
//                     <UncontrolledDropdown nav inNavbar>
//                         <DropdownToggle nav caret>
//                             More
//                         </DropdownToggle>
//                         <DropdownMenu end>
//                             <DropdownItem>
//                                 <NavItem>
//                                     <NavLink tag={RRNavLink} to="/history">
//                                         History
//                                     </NavLink>
//                                 </NavItem>
//                             </DropdownItem>
//                             <DropdownItem>
//                                 <NavItem>
//                                     <NavLink tag={RRNavLink} to="/contactus">
//                                         Contact Us
//                                     </NavLink>
//                                 </NavItem>
//                             </DropdownItem>
//                             <DropdownItem divider />
//                             <DropdownItem>
//                                 <NavItem>
//                                     <NavLink tag={RRNavLink} to="/login">
//                                         Login
//                                     </NavLink>
//                                 </NavItem>
//                             </DropdownItem>
//                         </DropdownMenu>
//                     </UncontrolledDropdown>
//                 </Nav>
//             )}
//         </Navbar>
//     </div>
// );