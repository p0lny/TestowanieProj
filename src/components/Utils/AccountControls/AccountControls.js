import './AccountControls.css'
import {useHistory} from "react-router-dom";

export default function AccountControls () {

    let history = useHistory()

    // IF USER NOT LOGGED IN

    const onLogIn = () => {
        // redirect to log-in page
        console.log("redirect to log-in page")
        history.push('/signin')
        window.location.reload()
    }

    const onRegister = () => {
        // redirect to register page
        console.log("redirect to register page")
        history.push('/signup')
        window.location.reload()
    }

    return (
        <div className={"accountControlsContainer"}>
            <button className={"btn btn-outline-primary accountBtn noRoundRight"} onClick={onLogIn}>Sign in</button>
            <button className={"btn btn-outline-primary accountBtn noRoundLeft"} onClick={onRegister}>Sign up</button>
        </div>
    )
}