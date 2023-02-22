import Header from './Header/Header.js'
import NavBar from '../NavBar/NavBar.js'

import './Layout.css';

function Layout() {
    var navItems = [
        {
            dir: "home",
            name: "Home"
        },
        {
            dir: "employees",
            name: "Empleados"
        }
    ];
    return (
        <div id="Layout">
            <Header />
            <NavBar links={navItems}/>
        </div>
    );
  }
  
  export default Layout;