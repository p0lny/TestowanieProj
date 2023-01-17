import "./EditMovie.css"
import {useEffect, useState} from "react";
import {verifyUser} from "../Utils/Functions/VerifyUser";
import {editMovie, getMovie, getMovieDetails} from "../API/Server";
import {useHistory} from "react-router-dom";

export default function EditMovie() {

    const history = useHistory()

    const [displayPage, setDisplayPage] = useState(false)

    const [title, setTitle] = useState("")
    const [duration, setDuration] = useState(0)
    const [description, setDescription] = useState("")
    const [premiereDate, setPremiereDate] = useState("")
    const [productionLocation, setProductionLocation] = useState("")
    const [language, setLanguage] = useState("")
    const [ageRestriction, setAgeRestriction] = useState(0)
    const [urlPoster, setUrlPoster] = useState("")
    const [urlTrailer, setUrlTrailer] = useState("")

    const movieId = history.location.pathname.substr(history.location.pathname.lastIndexOf("/") + 1)

    useEffect(() => {
        if (window.localStorage.getItem("role") === "Admin" && verifyUser()) {
            setDisplayPage(true)
        }
        getMovie(movieId).then((response) => {
            const movie = response.data
            setTitle(movie.title)
            setUrlPoster(movie.urlPoster)
            setUrlTrailer(movie.urlTrailer)
        })
        getMovieDetails(movieId).then((response) => {
            const movie = response.data
            console.log(response)
            // setDuration(movie.duration)
            setDescription(movie.description)
            setPremiereDate(new Date(movie.premiereDate).toLocaleDateString("en-CA"))
            setProductionLocation(movie.productionLocation)
            setLanguage(movie.language)
            setAgeRestriction(movie.ageRestriction)
        }).catch((error) => {
            console.warn(error)
        })
    }, [])

    const sendMovie = () => {
        const dataPack = {
            id: parseInt(movieId),
            title,
            description,
            duration,
            premiereDate: new Date(premiereDate).toJSON(),
            productionLocation,
            language,
            ageRestriction,
            urlPoster,
            urlTrailer
        }
        if (verifyUser()) {
            editMovie(dataPack).then((response) => {
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
                            <input required={true} value={title} type="text" className="form-control" id="exampleInput1"
                                   onChange={(e) => {
                                       setTitle(e.target.value)
                                   }}/>
                        </div>
                        {/*TODO*/}
                        {/*<div className="mb-3">*/}
                        {/*    <label htmlFor="exampleInput2" className="form-label">Movie duration</label>*/}
                        {/*    <input required={true} value={duration} type="number" className="form-control" id="exampleInput2"*/}
                        {/*           onChange={(e) => {*/}
                        {/*               setDuration(parseInt(e.target.value))*/}
                        {/*           }}/>*/}
                        {/*</div>*/}
                        <div className="mb-3">
                            <label htmlFor="description" className="form-label">Description</label>
                            <textarea required={true} value={description} className="form-control" id="description" style={{height: "24vh"}}
                                   onChange={(e) => {
                                       setDescription(e.target.value)
                                   }}/>
                        </div>
                        <div className="mb-3">
                            <label htmlFor="exampleInput3" className="form-label">Premiere date</label>
                            <input required={true} value={premiereDate} type="date" className="form-control" id="exampleInput3"
                                   onChange={(e) => {
                                       setPremiereDate(e.target.value)
                                   }}/>
                        </div>
                        <div className="mb-3">
                            <label htmlFor="exampleInput4" className="form-label">Production location</label>
                            <input required={true} value={productionLocation} type="text" className="form-control" id="exampleInput4"
                                   onChange={(e) => {
                                       setProductionLocation(e.target.value)
                                   }}/>
                        </div>
                        <div className="mb-3">
                            <label htmlFor="exampleInput5" className="form-label">Language</label>
                            <input required={true} value={language} type="text" className="form-control" id="exampleInput5"
                                   onChange={(e) => {
                                       setLanguage(e.target.value)
                                   }}/>
                        </div>
                        <div className="mb-3">
                            <label htmlFor="exampleInput6" className="form-label">Age restriction</label>
                            <input required={true} value={ageRestriction} type="number" className="form-control" id="exampleInput6"
                                   onChange={(e) => {
                                       setAgeRestriction(parseInt(e.target.value))
                                   }}/>
                        </div>
                        <div className="mb-3">
                            <label htmlFor="exampleInput7" className="form-label">Poster URL</label>
                            <input required={true} value={urlPoster} type="text" className="form-control" id="exampleInput7"
                                   onChange={(e) => {
                                       setUrlPoster(e.target.value)
                                   }}/>
                        </div>
                        <div className="mb-3">
                            <label htmlFor="exampleInput8" className="form-label">Trailer URL</label>
                            <input required={true} value={urlTrailer} type="text" className="form-control" id="exampleInput8"
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