import { Footer } from "../Footer"
import { AdminEmployeeSelections } from "../cards/AdminEmployeeSelections"
import { AdminEmployeeSelectionItem } from "../cards/AdminEmployeeSelectionItem"
import "../stylesheets/adminEmployeeMenu.css"

export const AdminEmployeeMenu = () => {
    return (
        <>
            <div className="adminemployeemenu">
                <selection className="adminemployeemenu_body">
                    <AdminEmployeeSelections />
                </selection>
            </div>
            <Footer />
        </>
    )
}