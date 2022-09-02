import Container from "./Container";
import { Link } from "react-router-dom";
import logo from '../../assets/logo.png'
import styles from './Menu.module.css'

export default function Menu() {
  return (
    <nav className={styles.navbar}>
      <Container>
          <Link to="/" className="navbar-brand text-uppercase">
            <img src={logo} alt="logo" width="120" height="120" />
            <strong>OF Reparos e Manutenção</strong>
          </Link>
          <ul className={styles.list}>
            <li className={styles.item}>
              <Link to="/" className="nav-link active" aria-current="page" >Home</Link>
            </li>
            <li className={styles.item}>
              <Link to="/services" className="nav-link">Serviços</Link>
            </li>
            <li className={styles.item}>
              <Link to="/estimates" className="nav-link">Orçamentos</Link>
            </li>
            <li className={styles.item}>
              <Link to="/whoweare" className="nav-link">Quem Somos</Link>
            </li>
          </ul>
      </Container>
    </nav>
  );
}
