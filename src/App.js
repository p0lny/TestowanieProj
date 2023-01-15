import './App.css';
import Header from "./components/Utils/Header/Header";
import Footer from "./components/Utils/Footer/Footer";
import {BrowserRouter, Route, Switch} from "react-router-dom";
import RegisterPage from "./components/RegisterPage/RegisterPage";
import LoginPage from "./components/LoginPage/LoginPage";
import MainPage from "./components/MainPage/MainPage";
import MovieDetails from "./components/Utils/MovieDetails/MovieDetails";
import ConfirmRegistration from "./components/ConfirmRegistration/ConfirmRegistration";
import AddMovie from "./components/AddMovie/AddMovie";
import EditMovie from "./components/EditMovie/EditMovie";

function App() {

    return (
        <div className="App">
            <div id={"content"}>
                <BrowserRouter>
                    <Header/>
                    <Switch>
                        <Route path={"/signup"}>
                            <RegisterPage/>
                        </Route>
                        <Route path={"/signin"}>
                            <LoginPage/>
                        </Route>
                        <Route path={"/movies/:id"}>
                            <MovieDetails/>
                        </Route>
                        <Route path={"/movie/add"}>
                            <AddMovie/>
                        </Route>
                        <Route path={"/movie/edit/:id"}>
                            <EditMovie/>
                        </Route>
                        <Route path={"/activate/:id"}>
                            <ConfirmRegistration/>
                        </Route>
                        <Route path={"/"}>
                            <MainPage/>
                        </Route>
                    </Switch>
                    <Footer/>
                </BrowserRouter>
            </div>
        </div>
    );
}

export default App;
