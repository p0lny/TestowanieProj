import Card from "../Utils/Card/Card";
import './MainPage.css'
import {useHistory} from "react-router-dom";

export default function MainPage() {

    const history = useHistory()

    const handleCardClick = (cardId) => {
        console.log("card has been clicked")
        history.push({
            pathname: `/movie/${cardId}`,
            state: cardId
        })
        window.location.reload()
    }

    const testData = [
        {
            movieId: 1,
            image: "https://d585tldpucybw.cloudfront.net/sfimages/default-source/blogs/templates/social/reactt-light_1200x628.png?sfvrsn=43eb5f2a_2",
            content: "Tekst tekst tekst tekst tekst tekst tekst tekst tekst tekst tekst tekst tekst tekst tekst tekst tekst tekst tekst tekst tekst tekst",
            imageAlt: "tekst obrazka",
            title: "Tytuł 1"
        }, {
            movieId: 2,
            image: "https://d585tldpucybw.cloudfront.net/sfimages/default-source/blogs/templates/social/reactt-light_1200x628.png?sfvrsn=43eb5f2a_2",
            content: "Tekst tekst tekst tekst tekst tekst tekst tekst tekst tekst tekst tekst tekst tekst tekst tekst tekst tekst tekst tekst tekst tekst",
            imageAlt: "tekst obrazka",
            title: "Tytuł 2"
        }, {
            movieId: 3,
            image: "https://d585tldpucybw.cloudfront.net/sfimages/default-source/blogs/templates/social/reactt-light_1200x628.png?sfvrsn=43eb5f2a_2",
            content: "Tekst tekst tekst tekst tekst tekst tekst tekst tekst tekst tekst tekst tekst tekst tekst tekst tekst tekst tekst tekst tekst tekst",
            imageAlt: "tekst obrazka",
            title: "Tytuł 3"
        }, {
            movieId: 4,
            image: "https://d585tldpucybw.cloudfront.net/sfimages/default-source/blogs/templates/social/reactt-light_1200x628.png?sfvrsn=43eb5f2a_2",
            content: "Tekst tekst tekst tekst tekst tekst tekst tekst tekst tekst tekst tekst tekst tekst tekst tekst tekst tekst tekst tekst tekst tekst",
            imageAlt: "tekst obrazka",
            title: "Tytuł 4"
        }, {
            movieId: 5,
            image: "https://d585tldpucybw.cloudfront.net/sfimages/default-source/blogs/templates/social/reactt-light_1200x628.png?sfvrsn=43eb5f2a_2",
            content: "Tekst tekst tekst tekst tekst tekst tekst tekst tekst tekst tekst tekst tekst tekst tekst tekst tekst tekst tekst tekst tekst tekst",
            imageAlt: "tekst obrazka",
            title: "Tytuł 5"
        }, {
            movieId: 6,
            image: "https://d585tldpucybw.cloudfront.net/sfimages/default-source/blogs/templates/social/reactt-light_1200x628.png?sfvrsn=43eb5f2a_2",
            content: "Tekst tekst tekst tekst tekst tekst tekst tekst tekst tekst tekst tekst tekst tekst tekst tekst tekst tekst tekst tekst tekst tekst",
            imageAlt: "tekst obrazka",
            title: "Tytuł 6"
        }
    ]

    return (
        <div className={"mainPageContainer"}>

            {
                testData.map((item, key) => {
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