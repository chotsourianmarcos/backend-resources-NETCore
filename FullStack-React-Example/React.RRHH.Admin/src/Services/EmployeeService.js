var baseURL = "https://localhost:7271/employees/"

var EmployeeService = {
    GetAllEmployees: async function () {
        // fetch(baseURL + "GetAll")
        //     .then(res => res.json())
        //     .then(
        //         (result) => {
        //             return result;
        //         },
        //         (error) => {
        //             return error;
        //         }
        //     )
        return await fetch(baseURL + "GetAll", {
            method: "GET",
            mode: "cors",
            headers: {
                "Content-Type": "application/json",
            },
        });
    }
}

export default EmployeeService;