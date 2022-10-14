import Estimate from "./components/pages/estimate/Estimate";
import Appointment from "./components/pages/appointment/Appointment";
import Client from "./components/pages/client/Client";
import Balance from "./components/pages/balance/Balance";
import Report from "./components/pages/report/Report";
import Sidebar from "./components/layouts/Sidebar";
import { Route, Routes } from "react-router-dom";

function App(props) {
  return (
    <Routes>
        <Route path='/' element={<Sidebar />} />
        <Route path='/balance' element={<Balance />} />
        <Route path='/report' element={<Report />} />
        <Route path='/client/list' element={<Client />} />
        <Route path='/appointment/list' element={<Appointment />} />
        <Route path='/estimate/list' element={<Estimate />} />
        <Route path='/estimate/new' element={`${props.newEstimate}`} />
    </Routes>
  );
}

export default App;
