import Sidebar from './components/layouts/Sidebar';
import { Routes, Route } from 'react-router-dom';
import Client from "./components/pages/client/Client";
import Appointment from "./components/pages/appointment/Appointment";
import Estimate from "./components/pages/estimate/Estimate";

function App() {
  return (
    <Routes>
      <Route path='/' element={<Sidebar />} />
        {/* <Route path='/home' element={<Home />} /> */}
        <Route path='/client/list' element={<Client />} />
        <Route path='/appointment/list' element={<Appointment />} />
        <Route path='/estimate/list' element={<Estimate />} />
        {/* <Route path='/movie/list' element={<Movie />} />
        <Route path='/rent/list' element={<Rent />} />  */}
    </Routes>
  );
}

export default App;
