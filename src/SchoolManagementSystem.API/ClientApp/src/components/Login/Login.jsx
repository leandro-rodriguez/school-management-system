import React from "react";
import logo from "./images/dclase_icon.ico";
import './Login.css';
import {ArrowRightOutlined, LockOutlined, MailOutlined, UserOutlined, LogoutOutlined} from "@ant-design/icons";
import { useState } from "react";
import Home from '../../pages/Home';
import axios from "axios";
import { useNavigationType } from "react-router-dom";
import { useEffect } from "react";

const Login = () => {

    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');

    async function handleSubmit(){ 
    
        var resp = await axios.post('http://localhost:5145/api/Authenticate/login', 
            { "username": username, "password": password })
            .then(resp => { 
                    localStorage.setItem('token', JSON.stringify(resp.data));
                })
                .catch((err) =>{
                        // console.log(err.resp.data)
                    });
    }

    return(
        <div className="login_container">
            <div className="screen">
                <div className="screen__content">
                    <form className="login">
                        <div className="login__field">
                            <UserOutlined />
                            <input
                                type="text"
                                className="login__input"
                                placeholder="Usuario / correo"
                                onChange={(e) => setUsername(e.target.value)}
                            />
                        </div>
                        <div className="login__field">
                            <LockOutlined />
                            <input
                                type="password"
                                className="login__input"
                                placeholder="Contraseña"
                                onChange={(e) => setPassword(e.target.value)}
                            />
                        </div>
                        <a href="http://localhost:8080/Home" className="button login__submit"
                            onClick={handleSubmit()}>
                            <span className="button__text">Iniciar sesión</span>
                            <i className="button__icon"> <ArrowRightOutlined /></i>                            
                        </a>
                    </form>
                    <img className="social-login" src={logo} alt="dclase_icon"/>
                </div>
                <div className="screen__background">
          <span
              className="screen__background__shape screen__background__shape4"
          ></span>
                    <span
                        className="screen__background__shape screen__background__shape3"
                    ></span>
                    <span
                        className="screen__background__shape screen__background__shape2"
                    ></span>
                    <span
                        className="screen__background__shape screen__background__shape1"
                    ></span>
                </div>
            </div>
        </div>
    );
};

export default Login;