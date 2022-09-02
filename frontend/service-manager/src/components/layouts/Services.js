import styles from './Services.module.css'
import { useRef } from 'react';
import logo from '../../assets/logo.png'
import pintura from '../../assets/pintura.jpg'
import background from '../../assets/background.jpg'


export default function Services() {
    return (
        <section>
            <div class={styles.wrapper}>
                <div className={styles.title}>
                    <h1>Pintura</h1>
                </div>
                <div class={styles.product_img}>
                    <img src={pintura} alt="pintura" width="530" height="400" />
                </div>
            </div>

            <div class={styles.wrapper}>
                <div className={styles.title}>
                    <h1>Pintura</h1>
                </div>
                <div class={styles.product_img}>
                    <img src={background} alt="pintura" width="530" height="400" />
                </div>
            </div>

            <div class={styles.wrapper}>
                <div className={styles.title}>
                    <h1>Pintura</h1>
                </div>
                <div class={styles.product_img}>
                    <img src={background} alt="pintura" width="530" height="400" />
                </div>
            </div>

            <div class={styles.wrapper}>
                <div className={styles.title}>
                    <h1>Pintura</h1>
                </div>
                <div class={styles.product_img}>
                    <img src={pintura} alt="pintura" width="530" height="400" />
                </div>
            </div>

            <div class={styles.wrapper}>
                <div className={styles.title}>
                    <h1>Pintura</h1>
                </div>
                <div class={styles.product_img}>
                    <img src={background} alt="pintura" width="530" height="400" />
                </div>
            </div>

            <div class={styles.wrapper}>
                <div className={styles.title}>
                    <h1>Pintura</h1>
                </div>
                <div class={styles.product_img}>
                    <img src={background} alt="pintura" width="530" height="400" />
                </div>
            </div>

        </section>
    );
}
