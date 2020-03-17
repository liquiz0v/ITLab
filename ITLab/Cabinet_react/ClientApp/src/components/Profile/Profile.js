import React, { Component } from 'react';

import './Profile.css';

import Header from '../Header/Header';
import MenuLeft from '../Menu_left/Menu_left';

const TITLE = 'Профиль'

export default class Profile extends Component {
    render() {

        const {
            userName,
            //className,
            UserImage,
        } = this.props


        return (
            <div>
                <Header
                    className='Profile-header'
                    userImage={UserImage}
                    title={TITLE}
                />
                <div className="profile-wrapper">
                    <div class="color-filter">
                        {/* <div class="profile-main">*/}

                            {/*Left menu*/}
                            <MenuLeft />

                            <div class="profile-data">
                                <div class="profile-block-left">
                                    <div class="main-avatar">
                                        <img src={UserImage}/>
                            </div>
                                    <b class="profile-name">Иван Иванов</b>
                                    <button id="edit_profile">Редактировать профиль</button>
                                </div>
                                <div class="profile-block-right">
                                    <p>На данный момент Вы не записаны на наши курсы.</p>
                                </div>

                            </div>
                        {/*</div>*/}
                    </div>
                </div>
            </div>
        )
    }
}