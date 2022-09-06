import styles from './Home.module.css'
import Menu from './Menu';
import Footer from './Footer';
import Estimates from './Estimates';
import We from './We';
import Services from './Services';

function Home() {
    return (
        <>
            <Menu />
            <section className={styles.home_container}>
                    <h1>Prestação de Serviços</h1>
                    <h4>Pintura, hidráulica, alvenaria e pequenos reparos.</h4>
            </section>
            <We />
            {/* <Services /> */}
            <Estimates />
            <Footer />
        </>
    );
}

export default Home