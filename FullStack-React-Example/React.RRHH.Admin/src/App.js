import { BrowserRouter, Routes, Route } from "react-router-dom";
import Layout from './Components/Layout/Layout.js'
import Home from './Components/Home/Home.js'
import Employees from './Components/Employees/Employees.js'
import EmployeeList from "./Components/Employees/EmployeeList/EmployeeList.js";
import AddUpdateEmployee from "./Components/Employees/AddUpdateEmployee/AddUpdateEmployee.js";

function App() {
  return (
    // <BrowserRouter>
    //   <Routes>
    //     <Route path="/" element={<Layout />}>
    //       <Route index element={<Home />} />
    //       <Route path="/employees" element={<Employees />} />
    //     </Route>
    //   </Routes>
    // </BrowserRouter>

    // <BrowserRouter>
    //   <Routes>
    //     <Route path="/" element={<Layout />}>
    //       <Route index element={<Home />} />
    //       <Route path="/employees" element={<Employees />}>
    //         <Route path="/employees/" element={<EmployeeList />} />
    //         <Route path="/employees/addupdate" element={<AddUpdateEmployee />} />
    //       </Route>
    //     </Route>
    //   </Routes>
    // </BrowserRouter>

    <BrowserRouter>
      <Routes>
        <Route path="/" element={<Layout />}>
          <Route index element={<Home />} />
          <Route path="/employees" element={<Employees />}>
            <Route path="/employees/" element={<EmployeeList />} />
            <Route path="/employees/addupdate" element={<AddUpdateEmployee />} />
          </Route>
        </Route>
      </Routes>
    </BrowserRouter>
  );
}

export default App;