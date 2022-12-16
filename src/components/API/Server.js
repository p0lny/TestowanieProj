import axios from "axios";
import {config} from "../../config";

const endpoint = config.server + ":" + config.port

/** ACCOUNT REQUESTS **/

export const signIn = async (data) => {
    await axios.post(`${endpoint}/api/account/login`, data).then((response) => {
        console.log(response)
        return response
    }).catch((error) => {
        console.warn(error)
    })
}

export const signUp = async (data) => {
    await axios.post(`${endpoint}/api/account/register`, data).then((response) => {
        console.log(response)
        return response
    }).catch((error) => {
        console.warn(error)
    })
}

export const activateAccount = async (token) => {
    await axios.post(`${endpoint}/api/account/activate/${token}`).then((response) => {
        console.log(response)
        return response
    }).catch((error) => {
        console.warn(error)
    })
}

/** COMMENT REQUESTS **/

export const getComment = async (movieId) => {
    await axios.get(`${endpoint}/api/comment/${movieId}`).then((response) => {
        console.log(response)
        return response
    }).catch((error) => {
        console.warn(error)
    })
}

export const getCommentHistory = async (id) => {
    await axios.get(`${endpoint}/api/comment/history/${id}`).then((response) => {
        console.log(response)
        return response
    }).catch((error) => {
        console.warn(error)
    })
}

export const sendComment = async (data) => {
    await axios.post(`${endpoint}/api/comment`, data).then((response) => {
        console.log(response)
        return response
    }).catch((error) => {
        console.warn(error)
    })
}

export const deleteComment = async (id) => {
    await axios.delete(`${endpoint}/api/comment/${id}`).then((response) => {
        console.log(response)
        return response
    }).catch((error) => {
        console.warn(error)
    })
}

export const editComment = async (data) => {
    await axios.put(`${endpoint}/api/comment/edit`, data).then((response) => {
        console.log(response)
        return response
    }).catch((error) => {
        console.warn(error)
    })
}

export const moderateComment = async (data) => {
    await axios.put(`${endpoint}/api/comment/moderate`, data).then((response) => {
        console.log(response)
        return response
    }).catch((error) => {
        console.warn(error)
    })
}

/** MOVIE REQUESTS **/

export const getMovieDetails = async (id) => {
    await axios.get(`${endpoint}/api/movie/${id}`).then((response) => {
        console.log(response)
        return response
    }).catch((error) => {
        console.warn(error)
    })
}

export const deleteMovie = async (id) => {
    await axios.delete(`${endpoint}/api/movie/${id}`).then((response) => {
        console.log(response)
        return response
    }).catch((error) => {
        console.warn(error)
    })
}

export const getMovies = async (data) => {
    await axios.get(`${endpoint}/api/movie`, data).then((response) => {
        console.log(response)
        return response
    }).catch((error) => {
        console.warn(error)
    })
}

export const postMovies = async (data) => {
    await axios.post(`${endpoint}/api/movie`, data).then((response) => {
        console.log(response)
        return response
    }).catch((error) => {
        console.warn(error)
    })
}

export const editMovies = async (data) => {
    await axios.put(`${endpoint}/api/movie`, data).then((response) => {
        console.log(response)
        return response
    }).catch((error) => {
        console.warn(error)
    })
}

/** RATING REQUESTS **/

export const getOverallRating = async (movieId) => {
    await axios.get(`${endpoint}/api/rating/overall/${movieId}`).then((response) => {
        console.log(response)
        return response
    }).catch((error) => {
        console.warn(error)
    })
}

export const getRating = async (movieId) => {
    await axios.get(`${endpoint}/api/rating/${movieId}`).then((response) => {
        console.log(response)
        return response
    }).catch((error) => {
        console.warn(error)
    })
}

export const postRating = async (data) => {
    await axios.post(`${endpoint}/api/rating`, data).then((response) => {
        console.log(response)
        return response
    }).catch((error) => {
        console.warn(error)
    })
}

export const editRating = async (data) => {
    await axios.put(`${endpoint}/api/rating`, data).then((response) => {
        console.log(response)
        return response
    }).catch((error) => {
        console.warn(error)
    })
}

export const deleteRating = async (id) => {
    await axios.delete(`${endpoint}/api/rating/${id}`).then((response) => {
        console.log(response)
        return response
    }).catch((error) => {
        console.warn(error)
    })
}

/** WATCHLIST REQUESTS **/

export const getWatchedMovies = async () => {
    await axios.get(`${endpoint}/api/watchlist/watched`).then((response) => {
        console.log(response)
        return response
    }).catch((error) => {
        console.warn(error)
    })
}

export const addWatchedMovies = async (data) => {
    await axios.post(`${endpoint}/api/watchlist/watched`, data).then((response) => {
        console.log(response)
        return response
    }).catch((error) => {
        console.warn(error)
    })
}

export const deleteWatchedMovie = async (id) => {
    await axios.delete(`${endpoint}/api/watchlist/watched/${id}`).then((response) => {
        console.log(response)
        return response
    }).catch((error) => {
        console.warn(error)
    })
}

export const getToBeWatchedMovies = async () => {
    await axios.get(`${endpoint}/api/watchlist/tobewatched`).then((response) => {
        console.log(response)
        return response
    }).catch((error) => {
        console.warn(error)
    })
}

export const postToBeWatchedMovies = async (data) => {
    await axios.post(`${endpoint}/api/watchlist/tobewatched`, data).then((response) => {
        console.log(response)
        return response
    }).catch((error) => {
        console.warn(error)
    })
}

export const deleteToBeWatchedMovies = async (id) => {
    await axios.delete(`${endpoint}/api/watchlist/tobewatched/${id}`).then((response) => {
        console.log(response)
        return response
    }).catch((error) => {
        console.warn(error)
    })
}