import axios from "axios";

import {config} from "../../config";

// mock data
import {movies} from "./mockdata";

const endpoint = "https://" + config.server + ":" + config.port

/** ACCOUNT REQUESTS **/

export const signIn = async (data) => {
    return await axios.post(`${endpoint}/api/account/login`, data)
}

export const signUp = async (data) => {
    return await axios.post(`${endpoint}/api/account/register`, data)
}

export const activateAccount = async (token) => {
    return await axios.post(`${endpoint}/api/account/activate/${token}`)
}

/** COMMENT REQUESTS **/

export const getComment = async (movieId) => {
    return await axios.get(`${endpoint}/api/comment/${movieId}`)
}

export const getCommentHistory = async (id) => {
    return await axios.get(`${endpoint}/api/comment/history/${id}`)
}

export const sendComment = async (data) => {
    return await axios.post(`${endpoint}/api/comment`, data)
}

export const deleteComment = async (id) => {
    return await axios.delete(`${endpoint}/api/comment/${id}`)
}

export const editComment = async (data) => {
    return await axios.put(`${endpoint}/api/comment/edit`, data)
}

export const moderateComment = async (data) => {
    return await axios.put(`${endpoint}/api/comment/moderate`, data)
}

/** MOVIE REQUESTS **/

export const getMovieDetails = async (id) => {
    return await axios.get(`${endpoint}/api/movie/details/${id}`, {headers: {'Authorization': `Bearer ${window.localStorage.getItem("token")}`}})
}

export const deleteMovie = async (id) => {
    return await axios.delete(`${endpoint}/api/movie/${id}`, {headers: {'Authorization': `Bearer ${window.localStorage.getItem("token")}`}})
}

export const getMovies = async () => {
    return await axios.get(`${endpoint}/api/movie`, {headers: {'Authorization': `Bearer ${window.localStorage.getItem("token")}`}})
}

export const postMovie = async (data) => {
    return await axios.post(`${endpoint}/api/movie`, data, {headers: {'Authorization': `Bearer ${window.localStorage.getItem("token")}`}})
}

export const editMovie = async (data) => {
    return await axios.put(`${endpoint}/api/movie`, data, {headers: {'Authorization': `Bearer ${window.localStorage.getItem("token")}`}})
}

/** RATING REQUESTS **/

export const getOverallRating = async (movieId) => {
    return await axios.get(`${endpoint}/api/rating/overall/${movieId}`)
}

export const getRating = async (movieId) => {
    return await axios.get(`${endpoint}/api/rating/${movieId}`)
}

export const postRating = async (data) => {
    return await axios.post(`${endpoint}/api/rating`, data)
}

export const editRating = async (data) => {
    return await axios.put(`${endpoint}/api/rating`, data)
}

export const deleteRating = async (id) => {
    return await axios.delete(`${endpoint}/api/rating/${id}`)
}

/** WATCHLIST REQUESTS **/

export const getWatchedMovies = async () => {
    return await axios.get(`${endpoint}/api/watchlist/watched`)
}

export const addWatchedMovies = async (data) => {
    return await axios.post(`${endpoint}/api/watchlist/watched`, data)
}

export const deleteWatchedMovie = async (id) => {
    return await axios.delete(`${endpoint}/api/watchlist/watched/${id}`)
}

export const getToBeWatchedMovies = async () => {
    return await axios.get(`${endpoint}/api/watchlist/tobewatched`)
}

export const postToBeWatchedMovies = async (data) => {
    return await axios.post(`${endpoint}/api/watchlist/tobewatched`, data)
}

export const deleteToBeWatchedMovies = async (id) => {
    return await axios.delete(`${endpoint}/api/watchlist/tobewatched/${id}`)
}