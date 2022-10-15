import Estimate from "./components/pages/estimate/Estimate";
import Appointment from "./components/pages/appointment/Appointment";
import Client from "./components/pages/client/Client";
import Balance from "./components/pages/balance/Balance";
import Report from "./components/pages/report/Report";
import Sidebar from "./components/layouts/Sidebar";
import { Route, Routes } from "react-router-dom";
import User from "./components/pages/user/User";
import Menu from "./components/layouts/Menu";
import We from "./components/layouts/We";
import Services from "./components/layouts/Services";
import Estimates from "./components/layouts/Estimates";
import Home from "./components/layouts/Home";

function App(props) {
  return (
    <Routes>
        <Route path='/painel' element={<Sidebar />} />
        <Route path='/balance' element={<Balance />} />
        <Route path='/report' element={<Report />} />
        <Route path='/client/list' element={<Client />} />
        <Route path='/appointment/list' element={<Appointment />} />
        <Route path='/estimate/list' element={<Estimate />} />
        <Route path='/user' element={<User />} />
        <Route path='/site' element={<Menu />} />
        <Route path='/home' element={<Home />} />
        <Route path='/services' element={<Services />} />
        <Route path='/estimates' element={<Estimates />} />
        <Route path='/whoweare' element={<We />} />

    </Routes>
  );
}

export default App;
