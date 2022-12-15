import './Header.css'
import Searchbar from "../Searchbar/Searchbar";
import AccountControls from "../AccountControls/AccountControls";

export default function Header () {
    return (
        <div id={"header"} className={"bg-primary"}>
            <span id={"appname"}>Biblioteka Filmowa</span>
            <Searchbar width={"40vw"}/>
            <AccountControls/>
        </div>
    )
}