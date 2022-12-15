import './AccountControls.css'

export default function AccountControls () {

    // IF USER NOT LOGGED IN

    const onLogIn = () => {
        // redirect to log-in page
        console.log("redirect to log-in page")
    }

    const onRegister = () => {
        // redirect to register page
        console.log("redirect to register page")
    }

    return (
        <div className={"accountControlsContainer"}>
            <button className={"btn btn-outline-primary accountBtn"} onClick={onLogIn}>Zaloguj</button>
            <button className={"btn btn-outline-primary accountBtn"} onClick={onRegister}>Zarejestruj</button>
        </div>
    )
}