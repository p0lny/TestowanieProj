import jwtDecode from "jwt-decode";

export const verifyUser = () => {
    let username = window.localStorage.getItem("username")
    let role = window.localStorage.getItem("role")
    let token = window.localStorage.getItem("token")
    let decodedToken = Object.values(jwtDecode(token))
    return !(decodedToken[1] !== username || decodedToken[2] !== role)
}