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
            pathname: `/movies/${cardId}`,
            state: cardId
        })
        window.location.reload()
    }

    // Get all movies on page load
    useEffect(() => {
        getMovies().then((response) => {
            console.log(response.data)
            setMovies(response.data)
        })
    }, [])

    return (
        <div className={"mainPageContainer"}>
            {
                movies.length > 0 && movies.map((item, key) => {
                    // if(item.content.length > 140) {
                    //     item.content = item.content.substring(0, 140) + "..."
                    // }
                    return (
                        <Card
                            image={item.urlPoster}
                            content={item.content}
                            imageAlt={item.title}
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