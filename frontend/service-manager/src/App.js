import Home from './components/layouts/Home';
import { Routes, Route } from 'react-router-dom';

function App() {
  return (
    <Routes>
      <Route path='/' element={<Home />} />
        {/* <Route path='/home' element={<Home />} /> */}
        {/* <Route path='/client/list' element={<Client />} />
        <Route path='/movie/list' element={<Movie />} />
        <Route path='/rent/list' element={<Rent />} /> */}
    </Routes>
  );
}

export default App;
