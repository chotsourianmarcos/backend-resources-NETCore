import Header from './Header/Header.js'
import NavBar from '../NavBar/NavBar.js'

import './Layout.css';

function Layout() {
    var nodes = [
        {
            dir: "",
            name: "Home"
        },
        {
            dir: "employees/",
            name: "Empleados"
        }
        ];
    return (
        <div id="Layout">
            <Header />
            <NavBar basePath="/" nodes={nodes}/>
        </div>
    );
  }
  
  export default Layout;