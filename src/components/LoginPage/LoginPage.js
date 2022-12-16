import './LoginPage.css'

export default function LoginPage() {
    return (
        <form className={'loginForm'}>
            <div className={'loginContainer'}>
                <h2 className={"mb-5"}>Sign in</h2>
                <div className="form-outline mb-4">
                    <input type="email" id="form2Example1" className="form-control"/>
                    <label className="form-label" htmlFor="form2Example1">Email address</label>
                </div>

                <div className="form-outline mb-4">
                    <input type="password" id="form2Example2" className="form-control"/>
                    <label className="form-label" htmlFor="form2Example2">Password</label>
                </div>

                <div className="row mb-4">
                    <div className="col">
                        <a href="#">Forgot password?</a>
                    </div>
                </div>

                <button type="button" className="btn btn-primary btn-block mb-4">Sign in</button>
            </div>
        </form>
    )
}