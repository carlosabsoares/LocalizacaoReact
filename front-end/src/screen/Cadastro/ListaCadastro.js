import React, { useEffect, useState } from "react";
import axios from "axios";
import Table from "@mui/material/Table";
import TableBody from "@mui/material/TableBody";
import TableContainer from "@mui/material/TableContainer";
import TableHead from "@mui/material/TableHead";
import TableRow from "@mui/material/TableRow";
import Paper from "@mui/material/Paper";
import { Box, Button, Modal } from "@mui/material";

import * as Styled from "./styles";
import MapView from "../../components/Google/Mapa";
import { TPO_DE_VEICULO } from "../../constants/veiculo";

export default function CustomizedTables() {
  const [veiculo, setVeiculo] = useState([]);
  const [selectedVeiculo, setSelectedVeiculo] = useState(null);
  console.log("🚀 ~ CustomizedTables ~ selectedVeiculo:", selectedVeiculo)

  const handleResponse = async (e) => {
    try {
      const getVeiculos = await axios.get(
        "https://localhost:7222/Veiculo/Listar"
      );
      setVeiculo(getVeiculos.data);
    } catch (error) {
      console.error("Erro ao cadastrar:", error);
      alert("Erro ao cadastrar. Verifique o console para mais detalhes.");
    }
  };

  useEffect(() => {
    handleResponse();
  }, []);

  return (
    <>
      <br />
      <TableContainer component={Paper}>
        <Table sx={{ minWidth: 700 }} aria-label="customized table">
          <TableHead>
            <TableRow>
              <Styled.StyledTableCell>Placa</Styled.StyledTableCell>
              <Styled.StyledTableCell align="right">
                Tipo de Veiculo
              </Styled.StyledTableCell>
              <Styled.StyledTableCell align="right">
                Chassi
              </Styled.StyledTableCell>
              <Styled.StyledTableCell align="right">Cor</Styled.StyledTableCell>
              <Styled.StyledTableCell align="right">
                Descrição
              </Styled.StyledTableCell>
              <Styled.StyledTableCell align="right">
                Latitude
              </Styled.StyledTableCell>
              <Styled.StyledTableCell align="right">
                Longitude
              </Styled.StyledTableCell>
              <Styled.StyledTableCell align="center">
                Localizar
              </Styled.StyledTableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {veiculo.map((veiculo) => (
              <Styled.StyledTableRow key={veiculo.placa}>
                <Styled.StyledTableCell component="th" scope="row">
                  {veiculo.placa}
                </Styled.StyledTableCell>
                <Styled.StyledTableCell align="right">
                  {TPO_DE_VEICULO[veiculo.tipoVeiculo]}
                </Styled.StyledTableCell>
                <Styled.StyledTableCell align="right">
                  {veiculo.chassi}
                </Styled.StyledTableCell>
                <Styled.StyledTableCell align="right">
                  {veiculo.cor}
                </Styled.StyledTableCell>
                <Styled.StyledTableCell align="right">
                  {veiculo.descricao}
                </Styled.StyledTableCell>
                <Styled.StyledTableCell align="right">
                  {veiculo.coordenadas.latitude}
                </Styled.StyledTableCell>
                <Styled.StyledTableCell align="right">
                  {veiculo.coordenadas.longitude}
                </Styled.StyledTableCell>
                <Styled.StyledTableCell align="center">
                  <Button
                    variant="contained"
                    color="primary"
                    onClick={() => {
                      setSelectedVeiculo(veiculo);
                    }}
                  >
                    Maps
                  </Button>
                </Styled.StyledTableCell>
              </Styled.StyledTableRow>
            ))}
          </TableBody>
        </Table>
      </TableContainer>

      <Modal
        open={!!selectedVeiculo}
        onClose={() => setSelectedVeiculo(null)}
        aria-labelledby="modal-modal-title"
        aria-describedby="modal-modal-description"
      >
        <Box width="400px" maxHeight="400px" margin="0 auto">
          {!!selectedVeiculo && (
            <MapView
              longitude={selectedVeiculo.coordenadas.longitude}
              latitude={selectedVeiculo.coordenadas.latitude}
              placa={selectedVeiculo.placa}
            />
          )}
        </Box>
      </Modal>
    </>
  );
}
