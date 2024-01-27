import { Link } from "react-router-dom"
import { Button } from "./Button"
import "./stylesheets/contactUsFooter.css"

export const ContactUsFooter = () => {
    return (
        <div className="footer-container">
            <section className="footer-subscription">
                <Link to="/contactus" className="social-logo">
                    Contact Us
                </Link>
                <p className="footer-subscription-heading">
                    Join GJ's newsletter to receive updates on all of our news and upcomming events
                </p>
                <p className="footer-subscription-text">
                    You can unsubscribe at any time
                </p>
                <div className="input-areas">
                    <form>
                        <input
                            type="email"
                            name="email"
                            placeholder="Your Email"
                            className="footer-input"
                        />
                        <Button buttonStyle="btn--outline">Subscribe</Button>
                    </form>
                </div>
            </section>
            {/* <div className="footer-links">
                <div className="footer-link-wrapper">
                    <div className="footer-link-items">
                        <h2 className="Connect With Us"></h2>
                        <Link to="/contactus">Contact Us</Link>
                    </div>
                </div>
            </div> */}
            <section className="social-media">
                <div className="social-media-wrap">
                    <div className="footer-logo">
                        <Link to="/" className="social-logo">
                            GJ's Apples
                        </Link>
                    </div>
                    <small className="website-rights">GJ's Apples © 2024</small>
                    <div className="social-icons">
                        <Link 
                            className="social-icon-link facebook"
                            to="/"
                            target="_blank"
                            aria-label="Facebook"
                        >
                            <i className="fab fa-facebook-f"></i>
                        </Link>
                        <Link 
                            className="social-icon-link instagram"
                            to="/"
                            target="_blank"
                            aria-label="Instagram"
                        >
                            <i className="fab fa-instagram"></i>
                        </Link>
                    </div>
                </div>
            </section>
        </div>
    )
}


// return (
//     <footer className="contactusfooter">
//         <h3>Contact Us</h3>
//         <div className="contactusfooter_address">
//             2584 Orchard Lane
//             <br />
//             Mount Juliet, TN 37122
//         </div>
//         <div className="contactusfooter_contactinfo">
//             Phone Number: (615) 502-7483
//             <br />
//             Email: <a href="mailto:contact@garyjonesappleorchard.com">contact@garyjonesappleorchard.com</a>
//         </div>
//     </footer>
// )