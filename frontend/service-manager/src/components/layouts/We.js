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
                                <p>A empresa foi fundada no ano de 2018 e vem expandindo até os dias atuais.</p>
                            </div>
                        </div>
                    </div>

                    <div className={styles.card}>
                        <div className={styles.box}>
                            <div className={styles.content}>
                                <h3>Onde atuamos?</h3>
                                <p>Atuamos nas seguintes cidades de Severínia, Cajobi e Olimpia e região.</p>
                            </div>
                        </div>
                    </div>

                    <div className={styles.card}>
                        <div className={styles.box}>
                            <div className={styles.content}>
                                <h3>Um pouco sobre nós</h3>
                                <p>Somos uma empresa de pequeno porte, que vem crescendo aos poucos desde que foi aberta
                                    buscamos sempre realizar o melhor atendimento, com eficiência, organização e o melhor preço
                                    para atender nossos clientes.
                                </p>
                            </div>
                        </div>
                    </div>

                    <div className={styles.card}>
                        <div className={styles.box}>
                            <div className={styles.content}>
                                <h3>Metas para o futuro</h3>
                                <p>Para o futuro pretendemos atuar em demais cidades da região, pretendemos tambem expandir a equipe para
                                    alcançar novos objetivos.
                                </p>
                            </div>
                        </div>
                    </div>

                    <div className={styles.card}>
                        <div className={styles.box}>
                            <div className={styles.content}>
                                <h3>Dica motivacional</h3>
                                <p>Grandes vitórias só podem ser alcançadas com esforço e persistência. Nunca desista de suas metas por parecerem distantes demais!</p>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
            <Footer />
        </>
    );
}
