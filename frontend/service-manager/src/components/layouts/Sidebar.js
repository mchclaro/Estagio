import './Sidebar.css';
import { BsFillCalendar2Fill, BsFillPersonFill, BsFileBarGraphFill, BsFillFileEarmarkTextFill } from 'react-icons/bs'
import { RiMoneyDollarCircleFill, RiSettings5Fill } from 'react-icons/ri'
import logo from '../../assets/logo.png'
import { Link } from "react-router-dom";

export default function Sidebar(props) {
  return (
    <>
      <div className="sidebar close">
        <div className="logo-details">
          <i><img src={logo} alt="logo" width="75" height="75" /></i>
          <span className="logo_name">OF Reparos e Manutenção</span>
        </div>
        <ul className="nav-links">
          <li>
            <div className="iocn-link">
              <Link to="">
                <i><BsFillCalendar2Fill /></i>
                <span className="link_name">Agendamento</span>
              </Link>
            </div>
            <ul className="sub-menu">
              <li><Link to="/" className="link_name">Agendamento</Link></li>
              <li><Link to="/appointment/list">Ver todos</Link></li>
              <li><Link to="">Novo Agendamento</Link></li>
            </ul>
          </li>
          <li>
            <div className="iocn-link">
              <Link to="">
                <i><BsFillFileEarmarkTextFill /></i>
                <span className="link_name">Orçamentos</span>
              </Link>
            </div>
            <ul className="sub-menu">
              <li><Link to="/" className="link_name">Orçamentos</Link></li>
              <li><Link to="/estimate/list">Ver todos</Link></li>
              <li><Link to="">Novo Orçamentos</Link></li>
            </ul>
          </li>
          <li>
            <div className="iocn-link">
              <Link to="">
                <i><BsFillPersonFill /></i>
                <span className="link_name">Clientes</span>
              </Link>
            </div>
            <ul className="sub-menu">
              <li><Link to="/" className="link_name">Clientes</Link></li>
              <li><Link to="/client/list">Ver todos</Link></li>
              <li><Link to="">Novo Cliente</Link></li>
            </ul>
          </li>
          <li>
            <div className="iocn-link">
              <Link to="">
                <i> <BsFileBarGraphFill /></i>
                <span className="link_name">Relatórios</span>
              </Link>
            </div>
            <ul className="sub-menu">
              <li><Link to="/" className="link_name">Relatórios</Link></li>
              <li><Link to="">Gerar Relatórios</Link></li>
            </ul>
          </li>
          <li>
            <div className="iocn-link">
              <Link to="">
                <i><RiMoneyDollarCircleFill /></i>
                <span className="link_name">Saldo</span>
              </Link>
            </div>
            <ul className="sub-menu">
              <li><Link to="/" className="link_name" href="#">Saldo</Link></li>
              <li><Link to="">Consultar Saldo</Link></li>
            </ul>
          </li>
          <li>
            <div className="iocn-link">
              <Link to="">
                <i><RiSettings5Fill /></i>
                <span className="link_name">Configurações</span>
              </Link>
            </div>
            <ul className="sub-menu">
              <li><Link to="/" className="link_name" href="#">Configurações</Link></li>
              <li><Link to="">Perfil</Link></li>
              <li><Link to="">Sair</Link></li>
            </ul>
          </li>
        </ul>
      </div>
    </>
  );
}