import React, { useEffect, useState } from "react";
import EmployeeService from '../../../Services/EmployeeService.js'

function EmployeeList() {
    // const [employees, setEmployees] = useState([]);
    // async function getEmployees() {
    //     const employees = await EmployeeService.GetAllEmployees();
    //     setEmployees(employees);
    // }
    // getEmployees();

    const [employees, setEmployees] = useState([]);
    const [isLoading, setLoading] = useState(true);

    useEffect(() => {
        getAllEmployees();
    }, []);

    const getAllEmployees = async () => {
        let currentEmployees = await EmployeeService.GetAllEmployees();
        if(Array.isArray(currentEmployees)){
            setEmployees(currentEmployees);
            setLoading(false);
        }
    };

    if (isLoading === false) {
        return (
            <div>
                <table>
                    <tr>
                        <th>
                            Id
                        </th>
                        <th>
                            Name
                        </th>
                        <th>
                            LastName
                        </th>
                        <th>
                            BirthDate
                        </th>
                    </tr>
                    {
                        employees.map((e) =>
                            <tr key={e.id}>
                                <td>
                                    {e.id}
                                </td>
                                <td>
                                    {e.name}
                                </td>
                                <td>
                                    {e.lastName}
                                </td>
                                <td>
                                    {e.birthDate}
                                </td>
                            </tr>
                        )
                    }
                </table>
            </div>
        );
    } else {
        return (
            <p>No hay empleados aún.</p>
        );
    }
}

export default EmployeeList;