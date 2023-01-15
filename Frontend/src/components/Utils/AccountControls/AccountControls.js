import './AccountControls.css'
import {useHistory} from "react-router-dom";
import {useEffect, useState} from "react";
import {verifyUser} from "../Functions/VerifyUser";

export default function AccountControls() {

    let history = useHistory()

    const [username, setUsername] = useState("")
    const [role, setRole] = useState("")

    useEffect(() => {
        if (window.localStorage.getItem("token") !== null &&
            window.localStorage.getItem("username") !== null &&
            window.localStorage.getItem("role") !== null
        ) {
            setUsername(window.localStorage.getItem("username"))
            setRole(window.localStorage.getItem("role"))
        } else {
            setUsername("")
            setRole("")
        }
    }, [])

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

    const signOut = () => {
        window.localStorage.removeItem("token")
        history.push("/")
        window.location.reload()
    }

    const goToAddMovie = () => {
        if (verifyUser()) {
            // redirect to add-movie page
            console.log("redirect to add-movie page")
            history.push('/movie/add')
            window.location.reload()
        } else {
            // redirect to add-movie page
            console.warn("Corrupted credentials")
            history.push('/')
            window.location.reload()
        }
    }

    return (
        <>
            {
                (!username &&
                    <div className={"accountControlsContainer border border-light rounded-2"}>
                        <button className={"btn btn-primary noRoundRight"} onClick={onLogIn}>Sign in
                        </button>
                        <button className={"btn btn-primary noRoundLeft"} onClick={onRegister}>Sign
                            up
                        </button>
                    </div>
                )
                ||
                (username &&
                    <div className="accountControlsContainer dropdown border border-light rounded-2">
                        <button className="btn btn-primary dropdown-toggle" id="dropdownMenuLink"
                           data-bs-toggle="dropdown" aria-expanded="false">
                            {username}
                        </button>

                        <ul className="dropdown-menu" aria-labelledby="dropdownMenuLink">
                            {
                                role === "Admin" &&
                                <li><button className="dropdown-item" onClick={goToAddMovie}>Add movie</button></li>
                            }
                            <li><button className="dropdown-item" onClick={signOut}>Sign out</button></li>
                        </ul>
                    </div>
                )
            }
        </>
    )
}