import './App.css';
import React from "react";
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
import {useState} from "react";
import {verifyUser} from "./components/Utils/Functions/VerifyUser";

function App() {

    const [searchPhrase, setSearchPhrase] = useState("")

    return (
        <div className="App">
            <div id={"content"}>
                <BrowserRouter>
                    <Header setSearchPhrase={setSearchPhrase} searchPhrase={searchPhrase}/>
                    <Switch>
                        <Route path={"/signup"}>
                            <RegisterPage/>
                        </Route>
                        <Route path={"/signin"}>
                            <LoginPage/>
                        </Route>
                        <Route path={"/movies/:id"}>
                            {
                                (window.localStorage.getItem("token") && verifyUser() && <MovieDetails/>) ||
                                <LoginPage/>
                            }
                        </Route>
                        <Route path={"/movie/add"}>
                            {
                                (window.localStorage.getItem("token") && verifyUser() && <AddMovie/>) ||
                                <LoginPage/>
                            }
                        </Route>
                        <Route path={"/movie/edit/:id"}>
                            {
                                (window.localStorage.getItem("token") && verifyUser() && <EditMovie/>) ||
                                <LoginPage/>
                            }
                        </Route>
                        <Route path={"/"}>
                            <MainPage searchPhrase={searchPhrase}/>
                        </Route>
                        <Route path={"/activate/:id"}>
                            <ConfirmRegistration/>
                        </Route>
                    </Switch>
                    <Footer/>
                </BrowserRouter>
            </div>
        </div>
    );
}

export default App;
