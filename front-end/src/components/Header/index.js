import { Link } from 'react-router-dom';
import './style.css';

function Header(){
  return(
    <header>
      <h2>Teste Inlog</h2>

      <div className="menu">
        <Link to="/">Home</Link>
        <Link to="/screen/cadastro">Cadastro</Link>
        <Link to="/screen/cadastro/listagem">Lista</Link>
      </div>
    </header>
  )
}

export default Header;