import { Outlet, Link } from "react-router-dom";
import './NavBar.css';

function NavBar(props) {
  return (
    <>
      <nav id="NavBar">
        <ul id="nav-buttons-container">
          {props.nodes.map((node) =>
            <button className="nav-button" key={props.nodes.indexOf(node)}>
              <Link to={props.nodes.indexOf(node) === 0 ? props.basePath : props.basePath + node.dir.toLowerCase()}>{node.name}</Link>
            </button>
          )}
          {/* <button className="nav-button">
            <Link to="/">Home</Link>
          </button>
          <button className="nav-button">
            <Link to="/employees">Employees</Link>
          </button> */}
        </ul>
      </nav>

      <Outlet />
    </>
  );
}

export default NavBar;