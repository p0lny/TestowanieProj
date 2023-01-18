import "./Comments.css"
import SingleComment from "./SingleComment/SingleComment";
import AddComment from "./AddComment/AddComment";
import {useEffect, useState} from "react";
import {getComment} from "../../API/Server";

export default function Comments({movieId}) {

    const [comments, setComments] = useState([])

    useEffect(() => {
        getComment(movieId).then((response) => {
            console.log(response)
            setComments(response.data)
        }).catch((error) => {
            console.warn(error)
        })
    }, [])

    return (
        <>
            <div className={"commentsContainer border"}>
                <AddComment movieId={movieId}/>
                {
                    comments.map((comment) => {
                        return (
                            <SingleComment userName={comment.userName} commentText={comment.commentText} postedAt={comment.postedAt} elementIdentifier={comment.id} key={`COMMENT_${comment.id}`}/>
                        )
                    })
                }
            </div>
        </>
    )
}