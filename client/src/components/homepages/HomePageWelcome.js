import "../stylesheets/homePageWelcome.css"
import "../../App.css"
import { Button } from "../Button"
import { useNavigate } from "react-router-dom"
import { useEffect, useState } from "react"

export const HomePageWelcome = ({ loggedInUser }) => {
    const [screenWidth, setScreenWidth] = useState(window.innerWidth)

    const navigate = useNavigate()

    useEffect(() => {
        // Function to update screenWidth state when the window is resized
        const handleResize = () => {
            setScreenWidth(window.innerWidth);
        };

        // Attach the event listener for window resize
        window.addEventListener('resize', handleResize);

        // Clean up the event listener when the component unmounts
        return () => {
            window.removeEventListener('resize', handleResize);
        };
    }, []); // Empty dependency array means this effect runs once after initial render

    return (
        <div className='homepagewelcome-container'>
            <video className='homepagewelcome-container-video' src='/videos/hp_apples_h.mp4' playsInline autoPlay loop muted />
            <h1>Garry Jones' Apples</h1>
            <p>What are you waiting for{loggedInUser?.id != null && loggedInUser?.roles.includes("Customer") && (` ${loggedInUser?.firstName}`)}? Buy some of our delicious apples!!</p>
            <div className='homepagewelcome-btns'>
                {loggedInUser?.id == null && (
                    <Button
                        className='btns'
                        buttonStyle='btn--primary'
                        buttonSize='btn--large'
                        onClick={event => {
                            event.preventDefault()
                            navigate("/login")
                        }}
                    >
                        Login to Purchase
                    </Button>
                )}
                {loggedInUser?.id != null && loggedInUser?.roles.includes("Customer") && (
                    <Button
                        className='btns'
                        buttonStyle='btn--primary'
                        buttonSize='btn--large'
                        onClick={event => {
                            event.preventDefault()
                            navigate("/order")
                        }}
                    >
                        Start an Order
                    </Button>
                )}
            </div>
        </div>
    )
}