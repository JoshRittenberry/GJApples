import React from "react"
import "../stylesheets/home.css"
import "../../App.css"
import { HomePageWelcome } from "./HomePageWelcome"

export const Home = ({ loggedInUser }) => {
    return (
        <>
            <HomePageWelcome />
        </>
    )
}