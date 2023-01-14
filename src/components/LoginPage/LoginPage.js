import './LoginPage.css'
import {useState} from "react";
import {signIn} from "../API/Server";
import {useHistory} from "react-router-dom";

export default function LoginPage() {

    const history = useHistory()

    const [email, setEmail] = useState("")
    const [password, setPassword] = useState("")
    const [warning, setWarning] = useState(false)

    const redirect = () => {
        // redirect to main page
        console.log("redirect to main page")
        history.push('/')
        window.location.reload()
    }

    const attemptSignIn = () => {
        if (email === "" || password === "") {
            setWarning(true)
        } else {
            let dataPack = {
                email,
                password
            }
            signIn(dataPack).then((response) => {
                console.log(response)
                window.localStorage.setItem("token", response)
                redirect()
            }).catch((error) => {
                console.warn(error)
            })
        }
    }

    return (
        <form className={'loginForm'}>
            <div className={'loginContainer'}>
                <h2 className={"mb-5"}>Sign in</h2>
                <div className="form-outline mb-4">
                    <input type="text"
                           id="form2Example1"
                           className={`form-control border-dark`}
                           required={true}
                           value={email}
                           placeholder={"Email"}
                           onChange={(e) => {
                               setEmail(e.target.value)
                               setWarning(false)
                           }}
                    />
                    <label className="form-label" htmlFor="form2Example1">Email</label>
                </div>

                <div className="form-outline mb-4">
                    <input type="password"
                           id="form2Example2"
                           className={`form-control border-dark`}
                           required={true}
                           value={password}
                           placeholder={"Password"}
                           onChange={(e) => {
                               setPassword(e.target.value)
                               setWarning(false)
                           }}
                    />
                    <label className="form-label" htmlFor="form2Example2">Password</label>
                </div>
                {
                    warning &&
                    <p className={"text-danger"}>Please fill all input fields</p>
                }
                <button type="button" className="btn btn-primary btn-block mb-4" onClick={attemptSignIn}>Sign in
                </button>
            </div>
        </form>
    )
}