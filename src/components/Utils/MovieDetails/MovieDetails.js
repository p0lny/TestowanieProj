import './MovieDetails.css'
import {useEffect, useState} from "react";
import {useHistory} from "react-router-dom";
import {getMovieDetails} from "../../API/Server";

export default function MovieDetails() {

    const location = useHistory()

    const [movieDetails, setMovieDetails] = useState(null)

    // ID of the movie
    const {state} = location.location

    // Get movie details on page load
    useEffect(() => {
        getMovieDetails(state - 1).then((response) => {
            setMovieDetails(response)
        })
    }, [])

    return (
        <div className={'mainContainer'}>
            {
                movieDetails &&
                <div className={"movieDetailsContainer border"}>
                    <img src={movieDetails.image} className={"movieDetailsImage"} alt={movieDetails.title}/>
                    <div className={"textArea"}>
                        <h2>{movieDetails.title + " " + state}</h2>
                        <p>{movieDetails.content}</p>
                    </div>
                </div>
            }
        </div>
    )
}