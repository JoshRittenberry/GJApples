import React from "react"
import "../stylesheets/home.css"
import "../../App.css"
import { HomePageWelcome } from "./HomePageWelcome"
import { Cards } from "../cards/Cards"
import { HomePageGJGreeting } from "./HomePageGJGreeting"
import { ContactUsFooter } from "../ContactUsFooter"

export const Home = ({ loggedInUser }) => {
    console.log(loggedInUser)
    return (
        <>
            <HomePageWelcome loggedInUser={loggedInUser} />
            <HomePageGJGreeting />
            {/* <Cards /> */}
            <ContactUsFooter />
        </>
    )
}