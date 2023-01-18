import './MovieDetails.css'
import {useEffect, useState} from "react";
import {useHistory} from "react-router-dom";
import {deleteMovie, getMovie, getMovieDetails} from "../../API/Server";
import Comments from "../Comments/Comments";

export default function MovieDetails() {

    const history = useHistory()

    const [movieInfo, setMovieInfo] = useState(null)
    const [movieDetails, setMovieDetails] = useState(null)

    // ID of the movie to fetch (use <movieDetails.movieId> later!)
    const {state} = history.location

    // Get movie details on page load
    useEffect(() => {
        getMovie(state).then((response) => {
            setMovieInfo(response.data)
        })
        getMovieDetails(state).then((response) => {
            setMovieDetails(response.data)
        })
    }, [])

    const handleEdit = () => {
        history.push(`/movie/edit/${movieDetails.movieId}`)
        window.location.reload()
    }

    const handleDelete = () => {
        deleteMovie(movieDetails.movieId).then((response) => {
            console.log(response)
            history.push("/")
            window.location.reload()
        }).catch((error) => {
            console.warn(error)
        })
    }

    return (
        <>
            {
                (window.localStorage.getItem("role") === "Admin" ||
                window.localStorage.getItem("role") === "Moderator") &&
                <div className={"controlPanel border"}>
                    <button className={"btn btn-primary"}
                            onClick={handleEdit}>
                        Edit movie
                    </button>
                    {
                        window.localStorage.getItem("role") === "Admin" &&
                        <button className={"btn btn-danger"}
                                onClick={handleDelete}>
                            Delete movie
                        </button>
                    }
                </div>
            }
            <div className={'mainContainer'}>
                {
                    movieDetails && movieInfo &&
                    <div className={"movieDetailsContainer border"}>
                        <div className={"info"}>
                            <div className={"leftPanel"}>
                                <img src={movieInfo.urlPoster} className={"movieDetailsImage"}
                                     alt={movieInfo.title}/>
                                {/*<h6 className={"text-secondary"}>Duration: {movieDetails.duration}</h6>*/}
                                <h6 className={"text-secondary"}>Production
                                    location: {movieDetails.productionLocation}</h6>
                                <h6 className={"text-secondary"}>Language: {movieDetails.language}</h6>
                                <h6 className={"text-secondary"}>Age restriction: {movieDetails.ageRestriction}</h6>
                            </div>
                            <div className={"textArea"}>
                                <h2>{movieInfo.title}</h2>
                                <p className={"desc ms-4"}>{movieDetails.description}</p>
                            </div>
                        </div>
                        <div className={"trailerSection"}>
                            {
                                (movieInfo.urlTrailer && movieInfo.urlTrailer !== "" &&
                                    <iframe className={"videoPlayer"}
                                            src={movieInfo.urlTrailer}>
                                    </iframe>)
                                ||
                                <h5 className={"text-secondary"}>No trailer available</h5>
                            }
                        </div>
                    </div>
                }
            </div>

            {
                movieInfo &&
                <Comments movieId={movieInfo.id}/>
            }
        </>
    )
}