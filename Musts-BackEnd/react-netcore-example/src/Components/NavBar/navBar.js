import { Outlet, Link, useLocation  } from "react-router-dom";
import './NavBar.css';

function NavBar(props) {
  let basePath = useLocation().pathname;
  if(basePath.charAt(basePath.length -1).valueOf() !== "/"){
    basePath += "/";
  }
  return (
    <>
      <nav id="NavBar">
        <ul id="nav-buttons-container">
          {props.links.map((link) =>
            <button className="nav-button" key={props.links.indexOf(link)}>
              <Link to={props.links.indexOf(link) === 0 ? basePath : basePath + link.dir.toLowerCase()}>{link.name}</Link>
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