
import React, { Component } from 'react';

//import Home from './components/Home/Home';
//import Header from './components/Header/Header';
import Profile from './components/Profile/Profile';

import './App.css';
import './lib/normalize.css';

import UserImage from './images/avatar.png'

//const TITLE = 'Профиль';
const USER = 'Иван Иванов';
//const PROFILE_PHOTO = '';
//const USER_IMAGE = ''

class App extends Component {
    render() {
        return (
            <Profile
                userName={USER}
                UserImage={UserImage}
            />
        )
    }
}

export default App;