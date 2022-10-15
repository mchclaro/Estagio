import styles from './Services.module.css'
import pintura from '../../assets/pintura.jpg'
import eletrico from '../../assets/eletrico.jpg'
import hidraulica from '../../assets/hidraulica.jpg'
import alvenaria from '../../assets/alvenaria.jpg'
import reparos from '../../assets/reparos.jpg'
import serralheria from '../../assets/serralheria.jpg'
import Menu from './Menu'
import Footer from './Footer'


export default function Services() {
    return (
        <>
        <Menu />
        <section className={styles.section}>
            <a id="services"></a>

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
                    <h1><span>Elétrico</span></h1>
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

            <div class={styles.wrapper}>
                <div className={styles.title}>
                    <h1><span>Pequenos Reparos</span></h1>
                </div>
                <div class={styles.product_img}>
                    <img src={reparos} alt="reparos" width="530" height="400" />
                </div>
            </div>

            <div class={styles.wrapper}>
                <div className={styles.title}>
                    <h1><span>Serralheria</span></h1>
                </div>
                <div class={styles.product_img}>
                    <img src={serralheria} alt="serralheria" width="530" height="400" />
                </div>
            </div>

        </section>
        <Footer />
        </>
    );
}
