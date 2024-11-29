import React, { useState } from "react";
import api from "../api";
import './Styles.css';

const Auth = ({ setToken }) => {
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const [isLogin, setIsLogin] = useState(true);

    const handleAuth = () => {
        const endpoint = isLogin ? "/auth/login" : "/auth/register";
        api.post(endpoint, { email, password })
            .then((response) => {
                setToken(response.data.token);
                localStorage.setItem("token", response.data.token);
            })
            .catch((error) => console.error(error));
    };

    return (
        <div className="container">
            <h1>{isLogin ? "Login" : "Registrar"}</h1>
            <input
                type="email"
                placeholder="Email"
                value={email}
                onChange={(e) => setEmail(e.target.value)}
            />
            <input
                type="password"
                placeholder="Senha"
                value={password}
                onChange={(e) => setPassword(e.target.value)}
            />
            <button onClick={handleAuth}>{isLogin ? "Entrar" : "Registrar"}</button>
            <p onClick={() => setIsLogin(!isLogin)}>
                {isLogin ? "Criar uma conta" : "Fazer login"}
            </p>
        </div>
    );
};

export default Auth;
