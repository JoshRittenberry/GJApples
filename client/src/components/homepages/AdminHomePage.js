import "../stylesheets/adminHomePage.css"
import { Footer } from "../Footer"
import AdminSelections from "../cards/AdminSelections"

export const AdminHomePage = () => {
    return (
        <>
            <div className="adminhome">
                <header className="adminhome_header">
                    <h1>Admin Home Page</h1>
                </header>
                <section className="adminhome_body">
                    <AdminSelections />
                </section>
            </div>
            <Footer />
        </>
    )
}