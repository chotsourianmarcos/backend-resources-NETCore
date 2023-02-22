import EmployeeService from '../../../Services/EmployeeService.js'

function EmployeeList() {
    let employeeList = EmployeeService.GetAllEmployees();
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
                {employeeList.map((e) =>
                    <tr key={e.Id}>
                        <td>
                            {e.Id}
                        </td>
                        <td>
                            {e.Name}
                        </td>
                        <td>
                            {e.LastName}
                        </td>
                        <td>
                            {e.BirthDate}
                        </td>
                    </tr>
                )}
            </table>
        </div>
    );
}

export default EmployeeList;