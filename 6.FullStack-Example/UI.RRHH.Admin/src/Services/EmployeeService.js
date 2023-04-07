var baseURL = "https://localhost:7271/employee/"

var EmployeeService = {
    GetAllEmployees: async function () {
        return await fetch(baseURL + "GetAll")
            .then(res => res.json())
            .then(
                (result) => {
                    return result;
                },
                (error) => {
                    return error;
                }
            )
        // return await fetch(baseURL + "GetAll", {
        //     method: "GET",
        //     mode: "cors",
        //     headers: {
        //         "Content-Type": "application/json",
        //     },
        // });
    }
}

export default EmployeeService;