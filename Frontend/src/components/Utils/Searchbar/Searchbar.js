import {useState} from "react";

import './Searchbar.css'
import {getMovies} from '../../API/Server.js'

export default function Searchbar ({type, id, name, width, searchPhrase, setSearchPhrase}) {

    const onSearchbarInput = (e) => {
        setSearchPhrase(e.target.value)
    }

    return (
        <div className={"searchbarContainer rounded"} style={{
            width: width,
            height: '2.7rem',
        }}>
            <input type={type}
                   id={'searchbar_' + id}
                   name={name}
                   value={searchPhrase}
                   placeholder={"Search for..."}
                   onChange={onSearchbarInput}
                   className={"form-control searchInput"}
            />
        </div>
    )
}