import "./SingleComment.css"
import {useEffect, useState} from "react";
import {getComment} from "../../../API/Server";
import {verifyUser} from "../../Functions/VerifyUser";

export default function SingleComment({movieId, userId, commentText, postedAt, elementIdentifier}) {

    const [display, setDisplay] = useState({})

    useEffect(() => {
        getComment(movieId).then((response) => {
            console.log(response)
        }).catch((error) => {
            console.warn(error)
        })
    }, [])

    const handleDeleteComment = () => {
        console.log("DELETE")
        setDisplay({display: "none"})
    }

    return (
        <div className={`singleComment border`} style={display}>
            <p className={"commentHeader text-secondary"}>Posted: {postedAt} by {userId}:</p>
            <p className={"commentContent"}>{commentText}</p>
            {
                window.localStorage.getItem("role") === "Admin" && verifyUser() &&
                <div className={"adminCommentControls border"}>
                    <button className={"btn btn-danger"} onClick={handleDeleteComment}>Delete comment</button>
                </div>
            }
        </div>
    )
}