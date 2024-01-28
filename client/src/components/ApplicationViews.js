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

export default function ApplicationViews({ loggedInUser, setLoggedInUser }) {
  return (
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
          path="orderpicker"
          element={
            <AuthorizedRoute roles={["OrderPicker"]} loggedInUser={loggedInUser}>
              <OrderPickerHomePage loggedInUser={loggedInUser} />
            </AuthorizedRoute>
          }
        />

        {/* Harvester Home */}
        <Route
          path="harvester"
          element={
            <AuthorizedRoute roles={["Harvester"]} loggedInUser={loggedInUser}>
              <HarvesterHomePage loggedInUser={loggedInUser} />
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
  )
}
