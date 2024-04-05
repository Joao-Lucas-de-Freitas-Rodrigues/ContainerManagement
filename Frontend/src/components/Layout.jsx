import Link from "next/Link"
import styles from '../styles/Layout.module.css'
import PropTypes from 'prop-types';

export default function Layout(props){
    
    return(
        <div className={styles.layout}>
            <div className={styles.cabecalho}>
                <Link href='/containermanagement'><h1>Container Management</h1></Link>  
            </div>
            <div className={styles.conteudo}>
                {props.children}
            </div>
        </div>
    )
}

Layout.propTypes = {
    children: PropTypes.node.isRequired
};