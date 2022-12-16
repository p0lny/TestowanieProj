import './RegisterPage.css'

export default function RegisterPage () {
    return (
        <form className={'registerForm'}>
            <div className={'registerContainer'}>
                <h2 className={"mb-5"}>Sign up</h2>
                <div className="form-outline mb-4">
                    <input type="text" id="form2Example0" className="form-control"/>
                    <label className="form-label" htmlFor="form2Example0">Username</label>
                </div>

                <div className="form-outline mb-4">
                    <input type="email" id="form2Example1" className="form-control"/>
                    <label className="form-label" htmlFor="form2Example1">Email address</label>
                </div>

                <div className="form-outline mb-4">
                    <input type="password" id="form2Example2" className="form-control"/>
                    <label className="form-label" htmlFor="form2Example2">Password</label>
                </div>

                <button type="button" className="btn btn-primary btn-block mb-4">Sign up</button>
            </div>
        </form>
    )
}