import { FaFacebook } from 'react-icons/fa'
import { SiGmail, SiWhatsapp } from 'react-icons/si'

import styles from './Footer.module.css'


export default function Footer() {
    return (
        <footer className={styles.footer}>
            <ul className={styles.social_list}>
                <li>
                    <a href='https://www.facebook.com/OfReparoseManutencao/'><FaFacebook /></a>
                </li>
                <li>
                    <a href='https://criarmeulink.com.br/u/1666133772'><SiGmail /></a>
                </li>
                <li>
                    <a href='https://wa.link/pm3ssj'> <SiWhatsapp /></a>
                </li>
            </ul>
            <p className={styles.copy_right}>
                <span>OF REPAROS E MANUTENÇÃO &copy; 2022</span>
            </p>
        </footer>
    );
}