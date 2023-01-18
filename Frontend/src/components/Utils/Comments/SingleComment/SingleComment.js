import "./SingleComment.css"
import {useState} from "react";
import {deleteComment} from "../../../API/Server";
import {verifyUser} from "../../Functions/VerifyUser";

export default function SingleComment({userName, commentText, postedAt, elementIdentifier}) {

    const [display, setDisplay] = useState({})

    const handleDeleteComment = () => {
        setDisplay({display: "none"})
        deleteComment(elementIdentifier).then((response) => {
            console.log(response)
        })
    }

    return (
        <div className={`singleComment border`} style={display}>
            <p className={"commentHeader text-secondary"}>Posted: {new Date(postedAt).toUTCString()} by {userName}:</p>
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