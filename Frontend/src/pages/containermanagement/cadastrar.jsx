import React,{ useEffect, useState } from "react";
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

    useEffect(async () => {
        try {
            setContainerType(await getType())
            setContainerStatus(await getStatus())
        } catch (error) {
            console.log(error)
        }
    }, []);

    const { register, handleSubmit, errors } = useForm({
        resolver: yupResolver(validationPost)
    })

    async function containerSubmit(data) {
        const formData = new FormData();
        formData.append('container_name', data.container_name);
        formData.append('container_description', data.container_description);
        formData.append('container_type_id', data.container_type_id);
        formData.append('container_status_id', data.container_status_id);
        
        if (data.image[0]) {
            formData.append('image', data.image[0]); // Adicionando a imagem
        }

        try {
            await postContainer(formData);
        } catch (error) {
            console.error('Erro ao autenticar usuário:', error);
        }
    }

    return (
        <Layout>
            <h2>Cadastrar Container</h2>
            <Form onSubmit={handleSubmit(containerSubmit)} encType="multipart/form-data">
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
                            />
                            {errors.container_name && <span style={errorColor}>{errors.container_name.message}</span>}
                        </FormGroup>
                    </Col>
                    <Col md={3}>
                        <FormGroup>
                            <Label for="container_description">
                                Descrição
                            </Label>
                            <Input
                                id="container_description"
                                name="container_description"
                                innerRef={register}
                            />
                            {errors.container_description && <span style={errorColor}>{errors.container_description.message}</span>}
                        </FormGroup>
                    </Col>
                    <Col md={3}>
                        <FormGroup>
                            <Label for="containerTypeId">
                                Tipo Container
                            </Label>
                            <Col sm={10}>
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
                            </Col>
                        </FormGroup>
                    </Col>
                    <Col md={3}>
                        <FormGroup>
                            <Label for="containerStatusId">
                                Status Container
                            </Label>
                            <Col sm={3}>
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
                            </Col>
                        </FormGroup>
                    </Col>
                </Row>
                <Row>
                    <Col md={3}>
                        <FormGroup>
                            <Label for="image">Upload Imagem</Label>
                            <Input
                                id="image"
                                name="image"
                                type="file"
                                innerRef={register}
                            />
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
}
