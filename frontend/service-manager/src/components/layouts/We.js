import Footer from './Footer';
import Menu from './Menu';
import styles from './We.module.css'

export default function We() {
    return (
        <>
        <Menu />
        <section className={styles.section}>
            <div className={styles.container}>
                <div className={styles.card}>
                    <div className={styles.box}>
                        <div className={styles.content}>
                            <h3>Quando a empresa foi criada?</h3>
                            <p>Lorem ipsum dolor sit amet consectetur adipisicing elit. Labore, totam velit? Iure nemo labore inventore?</p>
                        </div>
                    </div>
                </div>

                <div className={styles.card}>
                    <div className={styles.box}>
                        <div className={styles.content}>
                            <h3>Onde atuamos?</h3>
                            <p>Lorem ipsum dolor sit amet consectetur adipisicing elit. Labore, totam velit? Iure nemo labore inventore?</p>
                        </div>
                    </div>
                </div>

                <div className={styles.card}>
                    <div className={styles.box}>
                        <div className={styles.content}>
                            <h3>Um pouco sobre nós</h3>
                            <p>Lorem ipsum dolor sit amet consectetur adipisicing elit. Labore, totam velit? Iure nemo labore inventore?</p>
                        </div>
                    </div>
                </div>

                <div className={styles.card}>
                    <div className={styles.box}>
                        <div className={styles.content}>
                            <h3>Metas para o futuro</h3>
                            <p>Lorem ipsum dolor sit amet consectetur adipisicing elit. Labore, totam velit? Iure nemo labore inventore?</p>
                        </div>
                    </div>
                </div>

                <div className={styles.card}>
                    <div className={styles.box}>
                        <div className={styles.content}>
                            <h3>Metas para o futuro</h3>
                            <p>Lorem ipsum dolor sit amet consectetur adipisicing elit. Labore, totam velit? Iure nemo labore inventore?</p>
                        </div>
                    </div>
                </div>

                <div className={styles.card}>
                    <div className={styles.box}>
                        <div className={styles.content}>
                            <h3>Metas para o futuro</h3>
                            <p>Lorem ipsum dolor sit amet consectetur adipisicing elit. Labore, totam velit? Iure nemo labore inventore?</p>
                        </div>
                    </div>
                </div>
            </div>
        </section>
        <Footer />
        </>
    );
}
