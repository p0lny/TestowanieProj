import './Header.css'
import Searchbar from "../Searchbar/Searchbar";
import AccountControls from "../AccountControls/AccountControls";
import {useHistory} from "react-router-dom";

export default function Header ({searchPhrase, setSearchPhrase}) {

    const history = useHistory()

    const handleLogoClick = () => {
        history.push('/')
        window.location.reload()
    }

    return (
        <div id={"header"} className={"bg-primary"}>
            <span id={"appname"} onClick={handleLogoClick}>MovieLibrary</span>
            <div style={{marginTop: "0.5vh"}}>
                <Searchbar width={"40vw"} searchPhrase={searchPhrase} setSearchPhrase={setSearchPhrase}/>
            </div>
            <AccountControls/>
        </div>
    )
}