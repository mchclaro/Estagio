import styles from './Services.module.css'
import pintura from '../../assets/pintura.jpeg'
import eletrico from '../../assets/eletrica.jpeg'
import hidraulica from '../../assets/hidraulica.jpeg'
import alvenaria from '../../assets/alvenaria.jpeg'
import Menu from './Menu'
import Footer from './Footer'


export default function Services() {
    return (
        <>
            <Menu />
            <section className={styles.section}>
                <div class={styles.wrapper}>
                    <div className={styles.title}>
                        <h1><span>Pintura</span></h1>
                    </div>
                    <div class={styles.product_img}>
                        <img src={pintura} alt="pintura" width="530" height="400" />
                    </div>
                </div>

                <div class={styles.wrapper}>
                    <div className={styles.title}>
                        <h1><span>Elétrica</span></h1>
                    </div>
                    <div class={styles.product_img}>
                        <img src={eletrico} alt="eletrico" width="530" height="400" />
                    </div>
                </div>

                <div class={styles.wrapper}>
                    <div className={styles.title}>
                        <h1><span>Hidráulica</span></h1>
                    </div>
                    <div class={styles.product_img}>
                        <img src={hidraulica} alt="hidraulica" width="530" height="400" />
                    </div>
                </div>

                <div class={styles.wrapper}>
                    <div className={styles.title}>
                        <h1><span>Alvenaria</span></h1>
                    </div>
                    <div class={styles.product_img}>
                        <img src={alvenaria} alt="alvenaria" width="530" height="400" />
                    </div>
                </div>
            </section>
            <Footer />
        </>
    );
}
