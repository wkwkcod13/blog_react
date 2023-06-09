import React from 'react';
import Container from 'react-bootstrap/Container';
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';
import NavDropdown from 'react-bootstrap/NavDropdown';

const NavLink = [
    { name: 'Posts', href: './Posts' },
    { name: 'Pages', href: './Pages' },
    { name: 'Layout', href: './Layout' },
    //{ name: 'Login', href: './Login' }
];
interface appNav {

}
function AppNav(prop: appNav) {
    return (
        <Navbar bg="dark" expand="lg">
            <Container>
                <Navbar.Brand href="./">React-Bootstrap</Navbar.Brand>
                <Navbar.Toggle aria-controls="basic-navbar-nav" />
                <Navbar.Collapse id="basic-navbar-nav">
                    <Nav className="me-auto">
                        {
                            NavLink.map((item, index) => {
                                const { name, ...rest } = item;
                                return (<Nav.Link key={index} {...rest}>{name}</Nav.Link>)
                            })
                        }
                        <NavDropdown title="Dropdown" id="basic-nav-dropdown">
                            <NavDropdown.Item href="#action/3.1">
                                Action
                            </NavDropdown.Item>
                            <NavDropdown.Item href="#action/3.2">
                                Another action
                            </NavDropdown.Item>
                            <NavDropdown.Item href="#action/3.3">
                                Something
                            </NavDropdown.Item>
                            <NavDropdown.Divider />
                            <NavDropdown.Item href="#action/3.4">
                                Separated link
                            </NavDropdown.Item>
                        </NavDropdown>
                    </Nav>
                </Navbar.Collapse>
                <Navbar.Collapse className="justify-content-end">
                    <Nav.Link href="./Login">Login</Nav.Link>
                </Navbar.Collapse>
            </Container>
        </Navbar>
    );
}

export default AppNav;