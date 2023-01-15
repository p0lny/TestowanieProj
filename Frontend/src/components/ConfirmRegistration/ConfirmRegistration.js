import "./ConfirmRegistration.css"
import {useHistory, useLocation} from "react-router-dom";
import {useEffect, useState} from "react";
import {activateAccount} from "../API/Server";

export default function ConfirmRegistration() {

    const history = useHistory()
    const location = useLocation()

    const [confirmed, setConfirmed] = useState(false)

    const token = location.pathname.substr(10)

    const redirect = () => {
        // redirect to log-in page
        console.log("redirect to log-in page")
        history.push('/signin')
        window.location.reload()
    }

    useEffect(() => {
        activateAccount(token).then((response) => {
            console.log(response)
            setConfirmed(response)
        }).catch((error) => {
            console.warn(error)

        })
    }, [])

    return (
        <div className={`content`}>
            {
                (confirmed &&
                    <>
                        <p>
                            Your account has been activated.
                        </p>
                        <button type={"button"}
                                className={"btn btn-primary"}
                                onClick={redirect}>
                            Signin
                        </button>
                    </>)
                ||
                (!confirmed &&
                    <>
                        <p className={"text-danger"}>
                            Your account has NOT been activated.
                        </p>
                        <p className={"text-danger"}>
                            Activation link is incorrect or has expired.
                        </p>
                        <button type={"button"}
                                className={"btn btn-primary"}
                                onClick={redirect}>
                            Signin
                        </button>
                    </>)
            }
        </div>
    )
}