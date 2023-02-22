import NavBar from "../NavBar/NavBar";

function Employees() {
    var nodes = [
        {
            dir: "",
            name: "Listado de Empleados"
        },
        {
            dir: "/addupdate",
            name: "Agregar o Modificar Empleado"
        }
        ];
    return (
        <div id="Employees">
            <p className="main-text">
            Sección de empleados
            </p>
            <NavBar basePath="/employees" nodes={nodes}/>
        </div>
    );
  }
  
  export default Employees;