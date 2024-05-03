
import { BrowserRouter, Routes, Route } from 'react-router-dom';

import Home from './screen/Home/Index';
import CadastroForm from './screen/Cadastro/CadastroForm';
import ListaCadastro from './screen/Cadastro/ListaCadastro';
import MapView from './components/Google/Mapa';

import Header from './components/Header';


function RoutesApp(){
  return(
    <BrowserRouter>
      <Header/>
      <Routes>
        <Route path="/" element={ <Home/> } />
        <Route path="/screen/Cadastro" element={ <CadastroForm/> } />
        <Route path="/screen/Cadastro/listagem" element={ <ListaCadastro/> } />
        <Route path="/components/Google/Mapa" element={ <MapView/> } />
      </Routes>
    </BrowserRouter>
  )
}

export default RoutesApp;