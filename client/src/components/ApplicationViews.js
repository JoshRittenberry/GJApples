import { Route, Routes } from "react-router-dom"
import { AuthorizedRoute } from "./auth/AuthorizedRoute"
import Login from "./auth/Login"
import Register from "./auth/Register"
import { Home } from "./homepages/Home"
import { History } from "./History"
import { NewOrder } from "./orders/NewOrder"
import { OrderHistory } from "./orders/OrderHistory"
import { ViewOrder } from "./orders/ViewOrder"
import { EditOrder } from "./orders/EditOrder"
import { OrderPickerHomePage } from "./homepages/OrderPickerHomePage"
import { HarvesterHomePage } from "./homepages/HarvesterHomePage"
import { Cart } from "./orders/Cart"
import { AdminHomePage } from "./homepages/AdminHomePage"
import { ViewTrees } from "./trees/ViewTrees"
import ScrollToTop from "./ScrollToTop"
import { EditTree } from "./trees/EditTree"
import { NewTree } from "./trees/NewTree"
import { ViewEmployees } from "./employees/ViewEmployees"

export default function ApplicationViews({ loggedInUser, setLoggedInUser }) {
  return (
    <>
    <ScrollToTop />
    <Routes>
      {/* Home Page */}
      <Route path="/">
        <Route
          index
          element={
            <Home loggedInUser={loggedInUser} />
          }
        />

        {/* OrderPicker Home */}
        <Route
          path="orders/open"
          element={
            <AuthorizedRoute roles={["OrderPicker", "Admin"]} loggedInUser={loggedInUser}>
              <OrderPickerHomePage loggedInUser={loggedInUser} />
            </AuthorizedRoute>
          }
        />

        {/* Harvester Home */}
        <Route
          path="harvests/open"
          element={
            <AuthorizedRoute roles={["Harvester", "Admin"]} loggedInUser={loggedInUser}>
              <HarvesterHomePage loggedInUser={loggedInUser} />
            </AuthorizedRoute>
          }
        />

        {/* Admin Home */}
        <Route
          path="admin"
          element={
            <AuthorizedRoute roles={["Admin"]} loggedInUser={loggedInUser}>
              <AdminHomePage loggedInUser={loggedInUser} />
            </AuthorizedRoute>
          }
        />

        {/* History Page */}
        <Route
          path="history"
          element={
            <History />
          }
        />

        {/* New Order Page */}
        <Route
          path="order"
          element={
            <AuthorizedRoute roles={["Customer"]} loggedInUser={loggedInUser}>
              <NewOrder loggedInUser={loggedInUser} />
            </AuthorizedRoute>
          }
        />

        {/* Order History Page */}
        <Route
          path="orderhistory/*"
          element={
            <AuthorizedRoute roles={["Customer"]} loggedInUser={loggedInUser}>
              <Routes>
                <Route path="" element={<OrderHistory loggedInUser={loggedInUser} />} />
                <Route path="view/:id" element={<ViewOrder loggedInUser={loggedInUser} />} />
                <Route path="edit/:id" element={<EditOrder loggedInUser={loggedInUser} />} />
              </Routes>
            </AuthorizedRoute>
          }
        />

        {/* Tree Pages */}
        <Route
          path="trees/*"
          element={
            <Routes>
              <Route path="" element={
                <AuthorizedRoute roles={["Admin","Harvester"]} loggedInUser={loggedInUser}>
                  <ViewTrees loggedInUser={loggedInUser} />
                </AuthorizedRoute>
              } />
              <Route path="edit/:id" element={
                <AuthorizedRoute roles={["Admin"]} loggedInUser={loggedInUser}>
                  <EditTree loggedInUser={loggedInUser} />
                </AuthorizedRoute>
              } />
              <Route path="newtree" element={
                <AuthorizedRoute roles={["Admin"]} loggedInUser={loggedInUser}>
                  <NewTree loggedInUser={loggedInUser} />
                </AuthorizedRoute>
              } />
            </Routes>
          }
        />

        {/* Employee Pages */}
        <Route
          path="employees/*"
          element={
            <AuthorizedRoute roles={["Admin"]} loggedInUser={loggedInUser}>
              <Routes>
                {/* <Route path="" element={<OrderHistory loggedInUser={loggedInUser} />} /> */}
                <Route path="view" element={<ViewEmployees loggedInUser={loggedInUser} />} />
                {/* <Route path="edit/:id" element={<EditOrder loggedInUser={loggedInUser} />} /> */}
              </Routes>
            </AuthorizedRoute>
          }
        />

        <Route
          path="cart"
          element={
            <AuthorizedRoute roles={["Customer"]} loggedInUser={loggedInUser}>
              <Cart loggedInUser={loggedInUser} />
            </AuthorizedRoute>
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
    </>
  )
}
