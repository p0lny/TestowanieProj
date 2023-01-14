import Card from "../Utils/Card/Card";
import './MainPage.css'
import {useHistory} from "react-router-dom";
import {getMovies} from "../API/Server";
import {useEffect, useState} from "react";

export default function MainPage() {

    const history = useHistory()

    const [movies, setMovies] = useState([])

    // Go to movie details
    const handleCardClick = (cardId) => {
        console.log("card has been clicked")
        history.push({
            pathname: `/movie/${cardId}`,
            state: cardId
        })
        window.location.reload()
    }

    // Get all movies on page load
    useEffect(() => {
        getMovies().then((response) => {
            setMovies(response)
        })
    }, [])

    return (
        <div className={"mainPageContainer"}>
            {
                movies.length > 0 && movies.map((item, key) => {
                    return (
                        <Card
                            image={item.image}
                            content={item.content}
                            imageAlt={item.imageAlt}
                            title={item.title}
                            key={key}
                            onCardClick={() => handleCardClick(item.movieId)}
                        />
                    )
                })
            }
        </div>
    )
}