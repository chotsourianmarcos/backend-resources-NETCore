import NavBar from "../NavBar/NavBar";

function Employees() {
    var navItems = [
        {
            dir: "list",
            name: "Listado de Empleados"
        },
        {
            dir: "addupdate",
            name: "Agregar o Modificar Empleado"
        }
    ];
    return (
        <div id="Employees">
            <p className="main-text">
            Sección de empleados
            </p>
            <NavBar links={navItems}/>
        </div>
    );
  }
  
  export default Employees;