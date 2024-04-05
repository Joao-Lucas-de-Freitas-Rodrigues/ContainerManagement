import 'bootstrap/dist/css/bootstrap.min.css';
import { useEffect, useState } from "react";
import { getContainer, deleteContainer } from '../../services/containermanagement/containerServices';
import Layout from '../../components/Layout'
import { Table, Button } from "reactstrap";
import { HiOutlinePencilAlt, HiOutlineTrash, HiPlus } from "react-icons/hi";
import Styles from '../../styles/home.module.css';
import Router from 'next/router';
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

const Container = () => {

    const [container, setContainer] = useState([]);


    useEffect(async () => {
        try {
            setContainer(await getContainer())
        } catch (error) {
            console.log(error)
        }
    }, []);

    async function Excluir(id) {
        const confirmDelete = window.confirm("Tem certeza que deseja excluir?");
        if (confirmDelete) {
            try {
                await deleteContainer(id);
                toast("Exclusão realizada com sucesso!");
                setContainer(await getContainer())
            } catch (error) {
                console.error('Erro ao autenticar usuário:', error);
            }
        }
    }

    return (
        <Layout titulo='Home'>
            <div className={Styles.titulo}>
                <h2>Containers</h2>
                <div className={Styles.adicionar}>
                    <Button
                        color="primary"
                        onClick={() => Router.push('/containermanagement/cadastrar')}
                    >
                        <HiPlus size={20} />Cadastrar
                    </Button>
                </div>
            </div>
            <Table responsive='true' className="table">
                <thead>
                    <tr>
                        <th>
                            Container
                        </th>
                        <th>
                            Descrição
                        </th>
                        <th>
                            Status
                        </th>
                        <th>
                            Tipo
                        </th>
                        <th>
                            Ações
                        </th>
                    </tr>
                </thead>
                <tbody>
                    {container.map((item) => (
                        <tr key={item.id}>
                            <td>{item.container_name}</td>
                            <td>{item.container_description}</td>
                            <td>{item.containerStatus.description}</td>
                            <td>{item.containerType.description}</td>
                            <td>
                                <div className={Styles.home}>
                                    <Button
                                        color="primary"
                                        onClick={() => { Router.push(`/containermanagement/editar/${item.id}`) }}
                                    >
                                        <HiOutlinePencilAlt size={22} />
                                    </Button>
                                    <Button
                                        color="danger"
                                        onClick={() => { Excluir(item.id) }}
                                    >{
                                            <HiOutlineTrash size={22} />
                                        }

                                    </Button>
                                    <ToastContainer />
                                </div>
                            </td>
                        </tr>
                    ))}
                </tbody>
            </Table>
        </Layout >
    )
}

export default Container;