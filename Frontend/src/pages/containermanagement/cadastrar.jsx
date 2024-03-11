import React from 'react';
import { useEffect, useState } from "react";
import Layout from '../../components/Layout'
import { Form, Col, FormGroup, Input, Label, Row, Button } from 'reactstrap'
import 'bootstrap/dist/css/bootstrap.min.css';
const { useForm } = require('react-hook-form'); // Importando usando a sintaxe do CommonJS
const { yupResolver } = require('@hookform/resolvers/yup');
const yup = require('yup');
import { getType } from '../../services/containermanagement/containerTypeServices';
import { getStatus } from '../../services/containermanagement/containerStatusServices';
import { postContainer } from '../../services/containermanagement/containerServices';
import 'react-toastify/dist/ReactToastify.css';

const validationPost = yup.object().shape({
    container_name: yup.string().required("Campo Obrigatório"),
    container_description: yup.string().required("Campo Obrigatório")
})

const errorColor = {
    color: 'red'
};

export default function Cadastrar() {
    
    const [containerType, setContainerType] = useState([]);
    const [containerStatus, setContainerStatus] = useState([]);

    useEffect(() => {
        try {
            (async () => {
                setContainerType(await getType())
                setContainerStatus(await getStatus())
            })()
        } catch (error) {
            console.log(error)
        }
    }, []);

    const { register, handleSubmit, errors } = useForm({
        resolver: yupResolver(validationPost)
    })

    async function containerSubmit(user) {
        try {
            const userData = await postContainer(user);
        } catch (error) {
            console.error('Erro ao autenticar usuário:', error);
        }
    }

    return (
        <Layout>
            <h2>Cadastrar Container</h2>
            <Form onSubmit={handleSubmit(containerSubmit)}>
                <Row>
                    <Col md={3}>
                        <FormGroup>
                            <Label for="containerId">
                                Container
                            </Label>
                            <Input
                                id="containerId"
                                name="container_name"
                                innerRef={register}
                                maxLength="100"
                            />
                            <p style={errorColor}>{errors.name?.message}</p>
                        </FormGroup>
                    </Col>
                    <Col md={3}>
                        <FormGroup>
                            <Label for="descriptionId">
                                Descrição do Container
                            </Label>
                            <Input
                                id="descriptionId"
                                name="container_description"
                                innerRef={register}
                                maxLength="100"
                            />
                            <p style={errorColor}>{errors.description?.message}</p>
                        </FormGroup>
                    </Col>
                    <Col md={3}>
                        <FormGroup>
                            <Label for="containerTypeId">
                                Tipo Container
                            </Label>
                            <Input
                                id="containerTypeId"
                                name="container_type_id"
                                type="select"
                                innerRef={register}
                            >
                                {containerType.map((item) => (
                                    <option key={item.id} value={item.id}>{item.description}</option>
                                ))}
                            </Input>
                        </FormGroup>
                    </Col>
                    <Col md={3}>
                        <FormGroup>
                            <Label for="containerStatusId">
                                Status Container
                            </Label>
                            <Input
                                id="containerStatusId"
                                name="container_status_id"
                                type="select"
                                innerRef={register}
                            >
                                {containerStatus.map((item) => (
                                    <option key={item.id} value={item.id}>{item.description}</option>
                                ))}
                            </Input>
                        </FormGroup>
                    </Col>
                </Row>
                <Button
                    color="success"
                    type="submit"
                >
                    Salvar
                </Button>
            </Form>
        </Layout>
    )
};