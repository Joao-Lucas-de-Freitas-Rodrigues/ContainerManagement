import React, { useEffect, useState } from 'react';
import Layout from '../../components/Layout'
import { Form, Col, FormGroup, Input, Label, Row, Button } from 'reactstrap'
import 'bootstrap/dist/css/bootstrap.min.css';
import { useForm } from 'react-hook-form'
import { yupResolver } from '@hookform/resolvers/yup/dist/yup';
import * as yup from "yup";
import { postUser } from '../../services/esale/userServices'
import { getState } from '../../services/esale/stateServices'
import 'react-toastify/dist/ReactToastify.css';

const validationPost = yup.object().shape({
    name: yup.string().required("Campo Obrigatório"),
    cpf: yup.string().required("Campo Obrigatório"),
    birthDate: yup.date(),
    phoneNumber: yup.string().required("Campo Obrigatório"),
    address: yup.string().required("Campo Obrigatório"),
    addressNumber: yup.number().typeError("Deve ser um número").required("Campo Obrigatório"),
    addressDetails: yup.string(),
    zipCode: yup.string().required("Campo Obrigatório"),
    city: yup.string().required("Campo Obrigatório"),
    stateId: yup.number(),
    email: yup.string().required("Campo Obrigatório"),
    password: yup.string().required("Campo Obrigatório"),
    rg: yup.string()
})

const errorColor = {
    color: 'red'
};

export default function Cadastrar() {

    const { register, handleSubmit, errors } = useForm({
        resolver: yupResolver(validationPost)
    })

    const [state, setState] = useState([])

    useEffect(async () => {
        try {
            await Promise.all([getState()])
                .then(function (results) {
                    setState(results[0])
                    console.log(state)
                });
        } catch (error) {
            errorMsg(error.message);
        }
    }, [])

    const userSubmit = values => postUser(values);

    return (
        <Layout>
            <h2>Cadastro Usuário</h2>
            <Form onSubmit={handleSubmit(userSubmit)}>
                <Row>
                    <Col md={4}>
                        <FormGroup>
                            <Label for="nomeId">
                                Nome
                            </Label>
                            <Input
                                id="nomeId"
                                name="name"
                                innerRef={register}
                                maxLength="100"
                            />
                            <p style={errorColor}>{errors.name?.message}</p>
                        </FormGroup>
                    </Col>
                    <Col md={2}>
                        <FormGroup>
                            <Label for="passwordId">
                                Senha
                            </Label>
                            <Input
                                id="passwordId"
                                name="password"
                                innerRef={register}
                                maxLength="100"
                            />
                            <p style={errorColor}>{errors.password?.message}</p>
                        </FormGroup>
                    </Col>
                    <Col md={4}>
                        <FormGroup>
                            <Label for="emailId">
                                Email
                            </Label>
                            <Input
                                id="emailId"
                                name="email"
                                innerRef={register}
                                maxLength="100"
                            />
                            <p style={errorColor}>{errors.password?.message}</p>
                        </FormGroup>
                    </Col>
                    <Col md={5}>
                        <FormGroup>
                            <Label for="cpfId">
                                CPF
                            </Label>
                            <Input
                                id="cpfId"
                                name="cpf"
                                innerRef={register}
                                maxLength="100"
                            />
                            <p style={errorColor}>{errors.cpf?.message}</p>
                        </FormGroup>
                    </Col>
                    <Col md={5}>
                        <FormGroup>
                            <Label for="rgId">
                                RG
                            </Label>
                            <Input
                                id="rgId"
                                name="rg"
                                innerRef={register}
                                maxLength="100"
                            />
                            <p style={errorColor}>{errors.rg?.message}</p>
                        </FormGroup>
                    </Col>
                    <Col md={5}>
                        <FormGroup>
                            <Label for="birthDateId">
                                Data de Nascimento
                            </Label>
                            <Input
                                id="birthDateId"
                                name="birthDate"
                                innerRef={register}
                                maxLength="100"
                                type={'datetime-local'}
                            />
                            <p style={errorColor}>{errors.birthDate?.message}</p>
                        </FormGroup>
                    </Col>
                    <Col md={5}>
                        <FormGroup>
                            <Label for="phoneNumberId">
                                Número de Contato
                            </Label>
                            <Input
                                id="phoneNumberId"
                                name="phoneNumber"
                                innerRef={register}
                                maxLength="100"
                            />
                            <p style={errorColor}>{errors.phoneNumber?.message}</p>
                        </FormGroup>
                    </Col>
                    <Col md={5}>
                        <FormGroup>
                            <Label for="addressId">
                                Endereço
                            </Label>
                            <Input
                                id="addressId"
                                name="address"
                                innerRef={register}
                                maxLength="100"
                            />
                            <p style={errorColor}>{errors.address?.message}</p>
                        </FormGroup>
                    </Col>
                    <Col md={5}>
                        <FormGroup>
                            <Label for="addressNumberId">
                                Número da Residência
                            </Label>
                            <Input
                                id="addressNumberId"
                                name="addressNumber"
                                innerRef={register}
                                type={'number'}
                                maxLength="100"
                            />
                            <p style={errorColor}>{errors.addressNumber?.message}</p>
                        </FormGroup>
                    </Col>
                    <Col md={5}>
                        <FormGroup>
                            <Label for="addressDetailsId">
                                Complemento
                            </Label>
                            <Input
                                id="addressDetailsId"
                                name="addressDetails"
                                innerRef={register}
                                maxLength="100"
                            />
                        </FormGroup>
                    </Col>
                    <Col md={5}>
                        <FormGroup>
                            <Label for="zipCodeId">
                                CEP
                            </Label>
                            <Input
                                id="zipCodeId"
                                name="zipCode"
                                innerRef={register}
                                maxLength="100"
                            />
                            <p style={errorColor}>{errors.zipCode?.message}</p>
                        </FormGroup>
                    </Col>
                    <Col md={5}>
                        <FormGroup>
                            <Label for="cityId">
                                Cidade
                            </Label>
                            <Input
                                id="cityId"
                                name="city"
                                innerRef={register}
                                maxLength="100"
                            />
                            <p style={errorColor}>{errors.city?.message}</p>
                        </FormGroup>
                    </Col>
                    <Col md={5}>
                        <FormGroup>
                            <Label for="stateId">
                                Estado
                            </Label>
                            <Input
                                id="stateId"
                                name="stateId"
                                innerRef={register}
                                maxLength="100"
                                type={'select'}
                            >
                                <option value={''}>Selecione</option>
                                {state.map((res) => (
                                    <option key={res.id} value={res.id}>{res.description}</option>
                                ))}
                            </Input>
                            <p style={errorColor}>{errors.state?.message}</p>
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