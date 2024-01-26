import "./stylesheets/contactUsFooter.css"

export const ContactUsFooter = () => {
    return (
        <footer className="contactusfooter">
            <h3>Contact Us</h3>
            <div className="contactusfooter_address">
                2584 Orchard Lane
                <br />
                Mount Juliet, TN 37122
            </div>
            <div className="contactusfooter_contactinfo">
                Phone Number: (615) 502-7483
                <br />
                Email: <a href="mailto:contact@garyjonesappleorchard.com">contact@garyjonesappleorchard.com</a>
            </div>
        </footer>

    )
}