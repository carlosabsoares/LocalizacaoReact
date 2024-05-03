import React, { useState } from "react";
import axios from "axios";
import { Button, TextField, Stack, Box } from "@mui/material";
import InputLabel from "@mui/material/InputLabel";
import NativeSelect from "@mui/material/NativeSelect";

const CadastroFrom = () => {
  const [chassi, setChassi] = useState("");
  const [cor, setCor] = useState("");
  const [descricao, setDescricao] = useState("");
  const [placa, setPlaca] = useState("");
  const [tipoVeiculo, setTipoVeiculo] = useState(1);
  const [coordenadas, setCoordenadas] = useState({
    latitude: "",
    longitude: "",
  });

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      await axios.post("https://localhost:7222/Veiculo/Cadastrar", {
        chassi,
        cor,
        descricao,
        placa,
        tipoVeiculo,
        coordenadas,
      });

      alert("Cadastro realizado com sucesso!");
      setChassi("");
      setCor("");
      setDescricao("");
      setTipoVeiculo([]);
      setCoordenadas({
        latitude: "",
        longitude: "",
      });
      setPlaca("");
    } catch (error) {
      console.error("Erro ao cadastrar:", error);
      alert("Erro ao cadastrar. Verifique o console para mais detalhes.");
    }
  };

  return (
    <form onSubmit={handleSubmit}>
      {/* <TextField label="Email" type="email"/> */}
      <br />
      <Stack spacing={2} width={800} margin="0 auto">
        <TextField
          type="text"
          label="Descrição"
          placeholder="Descrição"
          inputProps={{ maxLength: 30 }}
          value={descricao}
          onChange={(e) => setDescricao(e.target.value)}
        />

        <TextField
          type="text"
          label="Chassi"
          placeholder="Chassi"
          value={chassi}
          inputProps={{ maxLength: 50 }}
          onChange={(e) => setChassi(e.target.value)}
        />

        <InputLabel variant="standard" htmlFor="uncontrolled-native">
          Tipo Veiculos
        </InputLabel>
        <NativeSelect
          onChange={(e) => setTipoVeiculo(Number(e.target.value))}
          defaultValue={30}
          inputProps={{
            name: "tipoVeiculo",
            id: "uncontrolled-native",
          }}
        >
          <option value={1}>Ônibus</option>
          <option value={2}>Caminhão</option>
        </NativeSelect>
        <TextField
          type="text"
          label="Placa"
          placeholder="Placa"
          inputProps={{ maxLength: 10 }}
          value={placa}
          onChange={(e) => setPlaca(e.target.value)}
        />
        <TextField
          type="text"
          label="Cor"
          placeholder="Cor"
          inputProps={{ maxLength: 20 }}
          value={cor}
          onChange={(e) => setCor(e.target.value)}
        />

        <Box display="flex" gap="16px">
          <TextField
            fullWidth
            type="number"
            step="0.01"
            label="Latitude"
            placeholder="Latitude"
            value={coordenadas.latitude}
            onChange={(e) =>
              setCoordenadas((prevState) => ({
                ...prevState,
                latitude: Number(e.target.value),
              }))
            }
          />

          <TextField
            fullWidth
            type="number"
            step="0.01"
            label="Longitude"
            placeholder="Longitude"
            value={coordenadas.longitude}
            onChange={(e) =>
              setCoordenadas((prevState) => ({
                ...prevState,
                longitude: Number(e.target.value),
              }))
            }
          />
        </Box>

        <Button variant="contained" type="submit">
          Cadastrar
        </Button>
      </Stack>
    </form>
  );
};
export default CadastroFrom;
