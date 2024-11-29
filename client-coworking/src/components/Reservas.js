import React, { useEffect, useState } from "react";
import api from "../api";
import './Styles.css';

const Reservas = () => {
    const [reservas, setReservas] = useState([]);
    const [espacos, setEspacos] = useState([]);
    const [usuario, setUsuario] = useState("");
    const [dataHora, setDataHora] = useState("");
    const [espacoId, setEspacoId] = useState("");

    useEffect(() => {
        api.get("/reservas")
            .then((response) => setReservas(response.data))
            .catch((error) => console.error(error));

        api.get("/espacos")
            .then((response) => setEspacos(response.data))
            .catch((error) => console.error(error));
    }, []);

    const adicionarReserva = () => {
        if (!espacoId || !usuario || !dataHora) {
            alert("Preencha todos os campos!");
            return;
        }

        api.post("/reservas", { espacoId, usuario, dataHora })
            .then(() => {
                setReservas([...reservas, { espacoId, usuario, dataHora }]);
                setUsuario("");
                setDataHora("");
                setEspacoId("");
            })
            .catch((error) => console.error(error));
    };

    return (
        <div className="container">
            <h1>Reservas</h1>
            <ul>
                {reservas.map((reserva) => (
                    <li key={reserva.id}>
                        Espaço: {reserva.espaco?.nome || reserva.espacoId} - 
                        Usuário: {reserva.usuario} - 
                        Data: {new Date(reserva.dataHora).toLocaleString()}
                    </li>
                ))}
            </ul>
            <div>
                <h2>Adicionar Reserva</h2>
                <select value={espacoId} onChange={(e) => setEspacoId(e.target.value)}>
                    <option value="">Selecione um Espaço</option>
                    {espacos.map((espaco) => (
                        <option key={espaco.id} value={espaco.id}>
                            {espaco.nome}
                        </option>
                    ))}
                </select>
                <input
                    type="text"
                    placeholder="Usuário"
                    value={usuario}
                    onChange={(e) => setUsuario(e.target.value)}
                />
                <input
                    type="datetime-local"
                    value={dataHora}
                    onChange={(e) => setDataHora(e.target.value)}
                />
                <button onClick={adicionarReserva}>Adicionar</button>
            </div>
        </div>
    );
};

export default Reservas;
