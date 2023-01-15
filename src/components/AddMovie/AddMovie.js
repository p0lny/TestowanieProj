import "./AddMovie.css"
import {useEffect, useState} from "react";
import {verifyUser} from "../Utils/Functions/VerifyUser";
import {postMovie} from "../API/Server";
import {useHistory} from "react-router-dom";

export default function AddMovie() {

    const history = useHistory()

    const [displayPage, setDisplayPage] = useState(false)

    const [title, setTitle] = useState("")
    const [duration, setDuration] = useState(0)
    const [premiereDate, setPremiereDate] = useState("")
    const [productionLocation, setProductionLocation] = useState("")
    const [language, setLanguage] = useState("")
    const [ageRestriction, setAgeRestriction] = useState(0)
    const [urlPoster, setUrlPoster] = useState("")
    const [urlTrailer, setUrlTrailer] = useState("")

    useEffect(() => {
        if (window.localStorage.getItem("role") === "Admin" && verifyUser()) {
            setDisplayPage(true)
        }
    }, [])

    const sendMovie = () => {
        const dataPack = {
            title,
            duration,
            premiereDate: new Date(premiereDate).toJSON(),
            productionLocation,
            language,
            ageRestriction,
            urlPoster,
            urlTrailer
        }
        if (verifyUser()) {
            postMovie(dataPack).then((response) => {
                if(response.status !== 200) {
                    console.warn(response)
                    return
                }
                history.push("/")
                window.location.reload()
            }).catch((error) => {
                console.warn(error)
            })
        }
    }

    return (
        <>
            {
                displayPage &&
                <div className={'mainContainer'}>
                    <form className={"mainForm"}>
                        <div className="mb-3">
                            <label htmlFor="exampleInput1" className="form-label">Movie title</label>
                            <input required={true} type="text" className="form-control" id="exampleInput1"
                                   onChange={(e) => {
                                       setTitle(e.target.value)
                                   }}/>
                        </div>
                        <div className="mb-3">
                            <label htmlFor="exampleInput2" className="form-label">Movie duration</label>
                            <input required={true} type="number" className="form-control" id="exampleInput2"
                                   onChange={(e) => {
                                       setDuration(parseInt(e.target.value))
                                   }}/>
                        </div>
                        <div className="mb-3">
                            <label htmlFor="exampleInput3" className="form-label">Premiere date</label>
                            <input required={true} type="date" className="form-control" id="exampleInput3"
                                   onChange={(e) => {
                                       setPremiereDate(e.target.value)
                                   }}/>
                        </div>
                        <div className="mb-3">
                            <label htmlFor="exampleInput4" className="form-label">Production location</label>
                            <input required={true} type="text" className="form-control" id="exampleInput4"
                                   onChange={(e) => {
                                       setProductionLocation(e.target.value)
                                   }}/>
                        </div>
                        <div className="mb-3">
                            <label htmlFor="exampleInput5" className="form-label">Language</label>
                            <input required={true} type="text" className="form-control" id="exampleInput5"
                                   onChange={(e) => {
                                       setLanguage(e.target.value)
                                   }}/>
                        </div>
                        <div className="mb-3">
                            <label htmlFor="exampleInput6" className="form-label">Age restriction</label>
                            <input required={true} type="number" className="form-control" id="exampleInput6"
                                   onChange={(e) => {
                                       setAgeRestriction(parseInt(e.target.value))
                                   }}/>
                        </div>
                        <div className="mb-3">
                            <label htmlFor="exampleInput7" className="form-label">Poster URL</label>
                            <input required={true} type="text" className="form-control" id="exampleInput7"
                                   onChange={(e) => {
                                       setUrlPoster(e.target.value)
                                   }}/>
                        </div>
                        <div className="mb-3">
                            <label htmlFor="exampleInput8" className="form-label">Trailer URL</label>
                            <input required={true} type="text" className="form-control" id="exampleInput8"
                                   onChange={(e) => {
                                       setUrlTrailer(e.target.value)
                                   }}/>
                        </div>
                        <button type="button" className="btn btn-primary" onClick={sendMovie}>Submit</button>
                    </form>
                </div>
            }
        </>
    )
}