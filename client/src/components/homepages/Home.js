import "../stylesheets/home.css"

export const Home = () => {
    return (
        <>
            <header className="homepage_header">
                <h1>Non-Authorized User Home Page</h1>
                <img src="https://i.ibb.co/x6w0yJ7/Hand-Holding-Apple.webp" className="hp_header_pic" alt="Hand Holding Apple" />
            </header>
            <section className="homepage_intro">
                <img src="https://i.ibb.co/8zmvNLT/GJ-Picking-Apples.jpg" className="hp_gj_pic" alt="Gary Jones Picking Apples" />
                <div className="gj_welcome">
                    <p>Hello, and thank you for visiting our little slice of paradise! I'm Gary Jones, the proud founder and caretaker of this orchard that has been my labor of love for many years. Nestled in the heart of nature, our orchard is more than just a place to pick apples – it's a sanctuary where memories are made, traditions are born, and the simple joys of nature can be appreciated in every bite of our crisp, juicy apples.</p>

                    <p>From humble beginnings, we've grown not only trees but a community of apple lovers and nature enthusiasts. Whether you're here to enjoy a day of apple picking, explore our scenic trails, or just relax under the shade of an apple tree, I hope you feel the same sense of peace and happiness that this orchard has brought to me over the years.</p>

                    <p>So, come on in, take a stroll, and savor the natural beauty and delicious flavors we have to offer. We're not just an orchard; we're a family, and we're thrilled to have you join us.</p>

                    <p>~Gary Jones</p>
                </div>
            </section>
        </>
    )
}