import styles from './Estimates.module.css'

export default function Estimates() {
    return (
        <section>
            <div className={styles.form_style_10}>
                <h1>Faça seu orçamento!<span>Preencha as informações abaixo e na mensagem informe qual serviço você gostaria!</span></h1>
                <form>
                    <div className="section">Nome</div>
                    <div className="inner-wrap">
                        <label><input type="text" name="field5" /></label>
                    </div>

                    <div className="section">Telefone</div>
                    <div className="inner-wrap">
                        <label><input type="text" name="field4" /></label>
                    </div>

                    <div className="section">Email</div>
                    <div className="inner-wrap">
                        <label><input type="email" name="field5" /></label>
                    </div>

                    <div className="section">Mensagem</div>
                    <div className="inner-wrap">
                        <label><textarea name="field2"></textarea></label>
                    </div>
                    <div>
                    <button className={styles.button_enviar} role="button">Enviar</button>
                    </div>
                </form>
            </div>
        </section>
    );
}
