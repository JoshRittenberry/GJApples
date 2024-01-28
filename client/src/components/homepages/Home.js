import React from "react"
import "../stylesheets/home.css"
import "../../App.css"
import { HomePageWelcome } from "./HomePageWelcome"
import { Cards } from "../cards/Cards"
import { HomePageGJGreeting } from "./HomePageGJGreeting"
import { Footer } from "../Footer"

export const Home = ({ loggedInUser }) => {
    return (
        <>
            <HomePageWelcome loggedInUser={loggedInUser} />
            <HomePageGJGreeting />
            {/* <Cards /> */}
            <Footer />
        </>
    )
}