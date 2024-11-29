import React, { useEffect, useState } from "react";
import api from "../api";
import './Espacos.css';

const Espacos = () => {
    const [espacos, setEspacos] = useState([]);
    const [nome, setNome] = useState("");
    const [localizacao, setLocalizacao] = useState("");
    const [capacidade, setCapacidade] = useState("");

    useEffect(() => {
        api.get("/espacos")
            .then((response) => setEspacos(response.data))
            .catch((error) => console.error(error));
    }, []);

    const adicionarEspaco = () => {

    if (capacidade <= 0) {
        alert("A capacidade deve ser um número maior que zero.");
        return;
    }

        api.post("/espacos", { nome, localizacao, capacidade })
            .then(() => {
                setEspacos([...espacos, { nome, localizacao, capacidade }]);
                setNome("");
                setLocalizacao("");
                setCapacidade("");
            })
            .catch((error) => console.error(error));
    };

    return (
        <div className="container">
            <h1>Espaços de Coworking</h1>
            <ul>
                {espacos.map((espaco) => (
                    <li key={espaco.id}>
                        {espaco.nome} - {espaco.localizacao} ({espaco.capacidade} pessoas)
                    </li>
                ))}
            </ul>
            <div>
                <h2>Adicionar Espaço</h2>
                <input
                    type="text"
                    placeholder="Nome"
                    value={nome}
                    onChange={(e) => setNome(e.target.value)}
                />
                <input
                    type="text"
                    placeholder="Localização"
                    value={localizacao}
                    onChange={(e) => setLocalizacao(e.target.value)}
                />
                <input
                    type="number"
                    placeholder="Capacidade"
                    value={capacidade}
                    onChange={(e) => setCapacidade(e.target.value)}
                />
                <button onClick={adicionarEspaco}>Adicionar</button>
            </div>
            <div className="descricao">
                <h2>Sobre a Aplicação</h2>
                <p>
                    Este sistema é uma aplicação de gerenciamento de espaços para coworking, 
                    onde os usuários podem adicionar, visualizar e gerenciar diferentes locais 
                    disponíveis. O backend é construído utilizando ASP.NET Web API 
                    e o Entity Framework, garantindo uma integração eficiente com o banco de dados SQLite. 
                    A autenticação e autorização são geridas de forma segura através de tokens JWT.
                </p>
            </div>
        </div>
    );
};

export default Espacos;