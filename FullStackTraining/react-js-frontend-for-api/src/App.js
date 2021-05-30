import React from 'react';

import {
  BrowserRouter as Router,
  Switch,
  Route
} from "react-router-dom";

import 'bootstrap/dist/css/bootstrap.min.css';
import HomePage from './pages/HomePage';
import CartPage from './pages/CartPage';

const App = () => {
  return (
    <Router>
      <Switch>
        <Route path="/Cart">
          <CartPage test={"some text"} />
        </Route>
        <Route path="/">
          <HomePage />
        </Route>
      </Switch>
    </Router>
  )
};

export default App;
