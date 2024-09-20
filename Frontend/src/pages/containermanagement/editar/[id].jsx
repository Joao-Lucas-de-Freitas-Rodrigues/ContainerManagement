import { useRouter } from 'next/router'
import Layout from '../../../components/Layout'
import { Form, Col, FormGroup, Input, Label, Row, Button } from 'reactstrap'
import 'bootstrap/dist/css/bootstrap.min.css';
import { useEffect, useState } from "react";
const { useForm } = require('react-hook-form'); // Importando usando a sintaxe do CommonJS
const { yupResolver } = require('@hookform/resolvers/yup');
const yup = require('yup');
import { getType } from '../../../services/containermanagement/containerTypeServices';
import { getStatus } from '../../../services/containermanagement/containerStatusServices';
import { getContainerId, getContainerImageId, putContainer } from '../../../services/containermanagement/containerServices';

const validationPost = yup.object().shape({
    container_name: yup.string().required("Campo Obrigatório"),
    container_description: yup.string().required("Campo Obrigatório")
})

const errorColor = {
    color: 'red'
};

export default function Editar() {
    const router = useRouter();

    const { register, handleSubmit, errors, setValue } = useForm({
        resolver: yupResolver(validationPost)
    })

    const [container, setContainer] = useState([]);
    const [containerType, setContainerType] = useState([]);
    const [containerStatus, setContainerStatus] = useState([]);
    const [imageUrl, setImageUrl] = useState("");

    const fields = ['container_name', 'container_description', 'container_type_id', 'container_status_id'];
    fields.forEach(field => {
        setValue(field, container[field])
    })

    useEffect(async () => {
        try {
            setContainer(await getContainerId(router.query.id))
            setContainerType(await getType())
            setContainerStatus(await getStatus())


            const token = localStorage.getItem('token');

            // Faz a requisição para obter a imagem
            const response = await fetch(`https://localhost:7061/api/container/image/${router.query.id}`, {
                headers: {
                    'Authorization': `Bearer ${token}`
                }
            });

            if (response.ok) {
                const imageUrl = URL.createObjectURL(await response.blob());
                setImageUrl(imageUrl);
            } else {
                console.error("Erro ao carregar a imagem", response.status);
            }

            // setImageUrl(await getContainerImageId(router.query.id))

            console.log(await getContainerImageId(router.query.id))
        } catch (error) {
            console.log(error)
        }
    }, []);

    async function containerSubmit(container) {
        try {
            await putContainer(router.query.id, container);
        } catch (error) {
            console.error('Erro ao autenticar usuário:', error);
        }
    }

    return (
        <Layout>
            <h2>Editar</h2>
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

                <Row>
                    <Col md={6}>
                        {imageUrl && (
                            <div>
                                <Label>Imagem Atual do Container</Label>
                                <img src={imageUrl} alt="Container Image" style={{ width: '300px', height: 'auto' }} />
                            </div>
                        )}
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