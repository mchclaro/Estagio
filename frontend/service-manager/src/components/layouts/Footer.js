import { FaFacebook, FaInstagram } from 'react-icons/fa'
import { SiGmail } from 'react-icons/si'

import styles from './Footer.module.css'


export default function Footer() {
    return (
        <footer className={styles.footer}>
            <ul className={styles.social_list}>
                <li>
                    <FaFacebook />
                </li>
                <li>
                    <FaInstagram />
                </li>
                <li>
                    <SiGmail />
                </li>
            </ul>
            <p className={styles.copy_right}>
                <span>OF REPAROS E MANUTENÇÃO &copy; 2022</span>  
            </p>
        </footer>
    );
}