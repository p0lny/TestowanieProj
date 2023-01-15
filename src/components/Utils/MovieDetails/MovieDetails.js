import './MovieDetails.css'
import {useEffect, useState} from "react";
import {useHistory} from "react-router-dom";
import {deleteMovie, getMovieDetails} from "../../API/Server";

export default function MovieDetails() {

    const history = useHistory()

    const [movieDetails, setMovieDetails] = useState(null)

    // ID of the movie to fetch (use <movieDetails.movieId> later!)
    const {state} = history.location

    // Get movie details on page load
    useEffect(() => {
        getMovieDetails(state - 1).then((response) => {
            setMovieDetails(response)
        })
    }, [])

    const handleEdit = () => {
        history.push(`/movie/edit/${movieDetails.movieId}`)
        window.location.reload()
    }

    const handleDelete = () => {
        console.log(movieDetails.movieId)
        deleteMovie(movieDetails.movieId).then((response) => {
            if (response.response.status !== 200) {
                console.warn("FAILED TO DELETE")
                return
            }
            history.push("/")
            window.location.reload()
        }).catch((error) => {
            console.warn(error)
        })
    }

    return (
        <>
            <div className={"controlPanel border"}>
                <button className={"btn btn-primary"}
                        onClick={handleEdit}>
                    Edit movie
                </button>
                <button className={"btn btn-danger"}
                        onClick={handleDelete}>
                    Delete movie
                </button>
            </div>
            <div className={'mainContainer'}>
                {
                    movieDetails &&
                    <div className={"movieDetailsContainer border"}>
                        <div className={"info"}>
                            <div className={"leftPanel"}>
                                <img src={movieDetails.urlPoster} className={"movieDetailsImage"}
                                     alt={movieDetails.title}/>
                                <h5 className={"text-secondary"}>Duration: {movieDetails.duration}</h5>
                                <h5 className={"text-secondary"}>Production
                                    location: {movieDetails.productionLocation}</h5>
                                <h5 className={"text-secondary"}>Language: {movieDetails.language}</h5>
                                <h5 className={"text-secondary"}>Age restriction: {movieDetails.ageRestriction}</h5>
                            </div>
                            <div className={"textArea"}>
                                <h2>{movieDetails.title}</h2>
                                <p>{movieDetails.content}</p>
                            </div>
                        </div>
                        <div className={"trailerSection"}>
                            {
                                (movieDetails.urlTrailer && movieDetails.urlTrailer !== "" &&
                                    <iframe className={"videoPlayer"}
                                            src={movieDetails.urlTrailer}>
                                    </iframe>)
                                ||
                                <h5 className={"text-secondary"}>No trailer available</h5>
                            }
                        </div>
                    </div>
                }
            </div>
        </>
    )
}