import './RegisterPage.css'
import {useState} from "react";
import {signUp} from "../API/Server";
import {useHistory} from "react-router-dom";

export default function RegisterPage () {

    const history = useHistory()

    const [name, setName] = useState("")
    const [surname, setSurname] = useState("")
    const [email, setEmail] = useState("")
    const [password, setPassword] = useState("")
    const [borderColorUsername, setBorderColorUsername] = useState("border-dark")
    const [borderColorEmail, setBorderColorEmail] = useState("border-dark")
    const [borderColorPassword, setBorderColorPassword] = useState("border-dark")
    const [warning, setWarning] = useState(false)

    const validateUsername = () => {
        if (name.length > 2 && name.length < 20) {
            console.log("Valid username")
            setBorderColorUsername("border-dark")
        } else {
            console.warn("Invalid username")
            setBorderColorUsername("border-danger")
            return false
        }
        return true
    }

    const validateEmail = () => {
        let regex = /^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/
        if (email.match(regex)) {
            console.log("Valid email address")
            setBorderColorEmail("border-dark")
        } else {
            console.warn("Invalid email address")
            setBorderColorEmail("border-danger")
            return false
        }
        return true
    }

    const validatePassword = () => {
        if (password.length > 6) {
            console.log("Valid password")
            setBorderColorPassword("border-dark")
        } else {
            console.warn("Invalid password")
            setBorderColorPassword("border-danger")
            return false
        }
        return true
    }

    const redirect = () => {
        // redirect to main page
        console.log("redirect to main page")
        history.push('/')
        window.location.reload()
    }

    const attemptSignUp = () => {
        if(validateUsername() && validateEmail() && validatePassword()) {
            let dataPack = {
                name,
                surname,
                email,
                password,
                passwordConfirmation: password
            }
            signUp(dataPack).then((response) => {
                console.log(response)
                redirect()
            })
        } else {
            setWarning(true)
        }
    }

    return (
        <form className={'registerForm'}>
            <div className={'registerContainer'}>
                <h2 className={"mb-5"}>Sign up</h2>
                <div className="form-outline mb-4">
                    <input type="text"
                           id="form2Example0"
                           className={`form-control ${borderColorUsername}`}
                           required={true}
                           value={name}
                           placeholder={"Between 2 and 20 characters"}
                           onChange={(e) => {
                               setName(e.target.value)
                               validateUsername()
                               setWarning(false)
                           }}
                    />
                    <label className="form-label" htmlFor="form2Example0">Name</label>
                </div>

                <div className="form-outline mb-4">
                    <input type="text"
                           id="form2Example3"
                           className={`form-control border-dark`}
                           required={true}
                           value={surname}
                           placeholder={"Between 2 and 20 characters"}
                           onChange={(e) => {
                               setSurname(e.target.value)
                               setWarning(false)
                           }}
                    />
                    <label className="form-label" htmlFor="form2Example3">Surname</label>
                </div>

                <div className="form-outline mb-4">
                    <input type="email"
                           id="form2Example1"
                           className={`form-control ${borderColorEmail}`}
                           required={true}
                           value={email}
                           placeholder={"Your email"}
                           onChange={(e) => {
                               setEmail(e.target.value)
                               validateEmail()
                               setWarning(false)
                           }}/>
                    <label className="form-label" htmlFor="form2Example1">Email address</label>
                </div>

                <div className="form-outline mb-4">
                    <input type="password"
                           id="form2Example2"
                           className={`form-control ${borderColorPassword}`}
                           required={true}
                           value={password}
                           placeholder={"At least 6 characters"}
                           onChange={(e) => {
                               setPassword(e.target.value)
                               validatePassword()
                               setWarning(false)
                           }}/>
                    <label className="form-label" htmlFor="form2Example2">Password</label>
                </div>
                {
                    warning &&
                    <p className={"text-danger"}>Please fill all input fields correctly</p>
                }
                <button type="button" className="btn btn-primary btn-block mb-4" onClick={attemptSignUp}>Sign up</button>
            </div>
        </form>
    )
}