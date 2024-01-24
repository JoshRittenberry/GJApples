import "../stylesheets/home.css"

export const Home = ({ loggedInUser }) => {
    return (
        <>
            <header className="homepage_header">
                {!loggedInUser ? (
                    <h1>Welcome to Garry Jones' Apples</h1>
                ) : <h1>Welcome Back to Garry Jones' Apples</h1>}
                <img src="https://i.ibb.co/x6w0yJ7/Hand-Holding-Apple.webp" className="homepage_header_pic" alt="Hand Holding Apple" />
            </header>
            <section className="homepage_intro">
                <img src="https://i.ibb.co/8zmvNLT/GJ-Picking-Apples.jpg" className="homepage_gj_pic" alt="Gary Jones Picking Apples" />
                <div className="homepage_gj_welcome">
                    <p>Hello, and thank you for visiting our little slice of paradise! I'm Gary Jones, the proud founder and caretaker of this orchard that has been my labor of love for many years. Nestled in the heart of nature, our orchard is more than just a place to pick apples – it's a sanctuary where memories are made, traditions are born, and the simple joys of nature can be appreciated in every bite of our crisp, juicy apples.</p>

                    <p>From humble beginnings, we've grown not only trees but a community of apple lovers and nature enthusiasts. Whether you're here to enjoy a day of apple picking, explore our scenic trails, or just relax under the shade of an apple tree, I hope you feel the same sense of peace and happiness that this orchard has brought to me over the years.</p>

                    <p>So, come on in, take a stroll, and savor the natural beauty and delicious flavors we have to offer. We're not just an orchard; we're a family, and we're thrilled to have you join us.</p>

                    <p>Sincerly,</p>
                    <p>Gary Jones</p>
                </div>
            </section>
            <footer className="homepage_footer">
                <h3>Contact Us</h3>
                <div className="homepage_footer_address">
                    <p>2584 Orchard Lane</p>
                    <p>Mount Juliet, TN 37122</p>
                </div>
                <div className="homepage_footer_contactinfo">
                    <p>Phone Number: (615) 502-7483</p>
                    <p>Email: contact@garyjonesappleorchard.com</p>
                </div>
            </footer>
        </>
    )
}