import React from 'react';
import './App.css';

import { BrowserRouter, Route, Switch } from 'react-router-dom';
import MainLayout from './components/Layout/MainLayout/MainLayout'
import StudentDetails from 'pages/Student/StudentDetails/StudentDetails';


function App() {
  
  return (
    <BrowserRouter> 
      <Switch>

          <Route path="/student-details" exact={true} component={StudentDetails} />  

      </Switch>
      <MainLayout/>
    </BrowserRouter>
  );
}

export default App;
