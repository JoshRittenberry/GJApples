import "../stylesheets/homePageWelcome.css"
import "../../App.css"
import { Button } from "../Button"

export const HomePageWelcome = () => {
    return (
        <div className='hero-container'>
            <video src='/videos/hp_apples_h.mp4' autoPlay loop muted />
            <h1>Garry Jones' Apples</h1>
            <p>What are you waiting for?</p>
            <div className='hero-btns'>
                <Button
                    className='btns'
                    buttonStyle='btn--outline'
                    buttonSize='btn--large'
                >
                    GET STARTED
                </Button>
                <Button
                    className='btns'
                    buttonStyle='btn--primary'
                    buttonSize='btn--large'
                    onClick={console.log('hey')}
                >
                    WATCH TRAILER <i className='far fa-play-circle' />
                </Button>
            </div>
        </div>
    )
}