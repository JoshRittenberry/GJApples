import { Route, Routes } from "react-router-dom"
import { AuthorizedRoute } from "./auth/AuthorizedRoute"
import Login from "./auth/Login"
import Register from "./auth/Register"
import { Home } from "./homepages/Home"
import { History } from "./History"
import { ContactUs } from "./ContactUs"

export default function ApplicationViews({ loggedInUser, setLoggedInUser }) {
  return (
    <Routes>
      {/* Home Page */}
      <Route path="/">
        <Route
          index
          element={
            <Home />
          }
        />

        {/* History Page */}
        <Route
          path="history"
          element={
            <History />
          }
        />

        {/* Contact Us Page */}
        <Route
          path="contactus"
          element={
            <ContactUs />
          }
        />

        <Route
          path="login"
          element={<Login setLoggedInUser={setLoggedInUser} />}
        />
        <Route
          path="register"
          element={<Register setLoggedInUser={setLoggedInUser} />}
        />
      </Route>
      <Route path="*" element={<p>Whoops, nothing here...</p>} />
    </Routes>
  )
}
