import {useState} from "react";

import './Searchbar.css'

export default function Searchbar ({type, id, name, width}) {

    const [phrase, setPhrase] = useState("")

    const onSearchbarInput = (e) => {
        setPhrase(e.target.value)
    }

    const search = () => {
        // api call for search movies
        console.log(`search movies by phrase: '${phrase}'`)
    }

    return (
        <div className={"searchbarContainer rounded"} style={{
            width: width,
            height: '2.7rem',
        }}>
            <input type={type}
                   id={'searchbar_' + id}
                   name={name}
                   value={phrase}
                   onChange={onSearchbarInput}
                   className={"form-control searchInput"}
            />
            <button className={"btn btn-outline-primary bi-search searchBtn"}
                    onClick={search}
            />
        </div>
    )
}