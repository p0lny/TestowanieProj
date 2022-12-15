import './App.css';
import Header from "./components/Utils/Header/Header";
import Footer from "./components/Utils/Footer/Footer";
import MainPage from "./components/MainPage/MainPage";

function App() {
  return (
    <div className="App">
        <div id={"content"}>
            <Header/>
            <MainPage/>
            <Footer/>
        </div>
    </div>
  );
}

export default App;
