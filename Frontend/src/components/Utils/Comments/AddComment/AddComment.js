import "./AddComment.css"
import {useState} from "react";

export default function AddComment({movieId}) {

    const [comment, setComment] = useState("")
    const [recommendsMovie, setRecommendsMovie] = useState(false)

    const sendComment = () => {
        const dataPack = {
            movieId,
            comment,
            recommendsMovie
        }
        console.log(dataPack)
    }

    return (
        <div className={"createCommentContainer border"}>
            <p className={"text-secondary fw-bold"}>Add your comment:</p>
            <textarea className={"commentTextArea"} placeholder={"Your comment here..."} value={comment}
                      onChange={(e) => {
                          setComment(e.target.value)
                      }}/>
            <div className={"addCommentButtons"}>
                <div className={"commentCheckbox"}>
                    <input type={"checkbox"} style={{width: "18px"}} onChange={(e) => {
                        setRecommendsMovie(e.target.checked)
                    }}/>
                    <span className={"mt-2 ms-2"}>Recommend movie</span>
                </div>
                <button className={"btn btn-primary"} onClick={sendComment}>Send comment</button>
            </div>
        </div>
    )
}