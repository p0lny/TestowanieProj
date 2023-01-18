import Card from "../Utils/Card/Card";
import './MainPage.css'
import {useHistory} from "react-router-dom";
import {getMovies} from "../API/Server";
import {useEffect, useState} from "react";

export default function MainPage({searchPhrase}) {

    const history = useHistory()

    const [movies, setMovies] = useState([])
    const [PageNumber, setPageNumber] = useState(1)
    const [loading, setLoading] = useState(false)
    const [PageSize, setPageSize] = useState(10)
    const [pageCount, setPageCount] = useState(1)
    const [perPage10, setPerPage10] = useState("primary")
    const [perPage25, setPerPage25] = useState("outline-primary")
    const [perPage50, setPerPage50] = useState("outline-primary")

    // Go to movie details
    const handleCardClick = (cardId) => {
        history.push({
            pathname: `/movies/${cardId}`,
            state: cardId
        })
        window.location.reload()
    }

    const handlePerPage = (number) => {
        switch (number) {
            case 10:
                setPerPage10("primary")
                setPerPage25("outline-primary")
                setPerPage50("outline-primary")
                setPageSize(10)
                break;
            case 25:
                setPerPage10("outline-primary")
                setPerPage25("primary")
                setPerPage50("outline-primary")
                setPageSize(25)
                break;
            case 50:
                setPerPage10("outline-primary")
                setPerPage25("outline-primary")
                setPerPage50("primary")
                setPageSize(50)
                break;
        }
    }

    // Get all movies on page load and on dependency change
    useEffect(() => {
        if (loading === false) {
            const dataPack = {
                PageNumber,
                PageSize,
                searchPhrase
            }
            getMovies(dataPack).then((response) => {
                console.log(response.data.items)
                setMovies(response.data.items)
                setPageCount(response.data.totalPages)
            })
        }
    }, [PageNumber, PageSize, loading])

    let timeout
    useEffect(() => {
        clearTimeout(timeout)
        setLoading(true)
        timeout = setTimeout(() => {
            setLoading(false)
        }, 2000)
    }, [searchPhrase])

    return (
        <div className={"mainPageContainer"}>
            <div className={"postsContainer"}>
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
                                onCardClick={() => handleCardClick(item.id)}
                            />
                        )
                    })
                }
            </div>
            <div className={"myPagination rounded-5"}>
                {
                    (PageNumber > 2 &&
                    <>
                        <button className={"btn btn-outline-primary rounded-5"} onClick={() => setPageNumber(1)}>1</button>
                        <button className={"btn btn-outline-primary rounded-5"} onClick={() => setPageNumber(2)}>2</button>
                    </>) || (
                        PageNumber > 1 &&
                        <button className={"btn btn-outline-primary rounded-5"} onClick={() => setPageNumber(1)}>1</button>
                    )
                }
                <button className={"btn btn-primary rounded-5"}>{PageNumber}</button>
                {
                    (PageNumber < pageCount - 1 &&
                        <>
                            <button className={"btn btn-outline-primary rounded-5"} onClick={() => setPageNumber(pageCount - 1)}>{pageCount - 1}</button>
                            <button className={"btn btn-outline-primary rounded-5"} onClick={() => setPageNumber(pageCount)}>{pageCount}</button>
                        </>) || (
                        PageNumber < pageCount &&
                        <button className={"btn btn-outline-primary rounded-5"} onClick={() => setPageNumber(pageCount)}>{pageCount}</button>
                    )
                }
            </div>
            <div className={"text-secondary perPageConfig"}>
                <p className={"mt-2"}>Posts per page:</p>
                <button className={`rounded-5 btn btn-${perPage10}`} onClick={() => handlePerPage(10)}>10</button>
                <button className={`rounded-5 btn btn-${perPage25}`} onClick={() => handlePerPage(25)}>25</button>
                <button className={`rounded-5 btn btn-${perPage50}`} onClick={() => handlePerPage(50)}>50</button>
            </div>
        </div>
    )
}