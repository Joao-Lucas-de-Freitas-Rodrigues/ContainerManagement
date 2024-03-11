import { Form, FormGroup, Label, Input, Button } from 'reactstrap'
import 'bootstrap/dist/css/bootstrap.min.css';
import styles from '../styles/Login.module.css'
import { useForm } from 'react-hook-form'
import { useRouter } from "next/router";
import {validateUser} from '../services/containermanagement/loginServices'

export default function Login() {

  const { register, handleSubmit, errors } = useForm({
  })

  async function handleLogin(user) {
    try {
        const userData = await validateUser(user);
        console.log(userData)
        // Se o login for bem-sucedido, redirecione ou faça outras ações necessárias
    } catch (error) {
        // Lidar com erros de autenticação, por exemplo, exibindo uma mensagem de erro ao usuário
        console.error('Erro ao autenticar usuário:', error);
    }
}

  return (
    <div className={styles.App}>
      <h2>Login</h2>
      <Form onSubmit={handleSubmit(handleLogin)}>
        <FormGroup>
          <Label for="exampleEmail">Username</Label>
          <Input
            type="text"
            name="username"
            id="exName"
            innerRef={register}
          />
        </FormGroup>
        <FormGroup>
          <Label for="examplePassword">Password</Label>
          <Input
            type="password"
            name="password"
            id="examplePassword"
            innerRef={register}
          />
        </FormGroup>
        <Button
          color='primary'
          type='submit'
        >Login</Button>
      </Form>
    </div >
  )
}