import Container from "./Container";
import { Link } from "react-router-dom";
import logo from '../../assets/logo.png'
import styles from './Menu.module.css'

export default function Menu() {
  return (
    <nav className={styles.navbar}>
      <Container>
          <Link to="/home" className={styles.text_logo}>
            <img src={logo} alt="logo" width="120" height="120" />
            OF REPAROS E MANUTENÇÃO
          </Link>
          <ul className={styles.list}>
            <li className={styles.item}>
              <Link to="/home" className="nav-link active" aria-current="page" >Home</Link>
            </li>
            <li className={styles.item}>
              <Link to="/services" className="nav-link" id="services">Serviços</Link>
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
