import React, { Component } from 'react';

import './EditProfile.css';

import Header from '../Header/Header';
import MenuLeft from '../Menu_left/Menu_left';

export default class EditProfile extends Component {
    render() {

        const TITLE = 'Редактирование профиля'

        const {
            UserName,
            UserImage
        } = this.props

        return (
            <div>
                <Header
                    className='EditProfile-header'
                    userImage={UserImage}
                    title={TITLE}
                />
                <div className="App-data-wrapper">
                    <div class="App-color-filter">
                        {/*Left menu*/}
                        <MenuLeft />

                        <div class="App-page-data">
                            <div className="colums-data">
                                <div className="data-Columns firstColumn profile-image">
                                    <div class="main-avatar">
                                        <img src={UserImage} />
                                    </div>
                                </div>

                                <div className="data-Columns secondColumn">
                                    <div class="form-group">
                                        <label for="input-Name"> Имя </label>
                                        <input type="text" className="form-control" id="input-Name"/>
                                    </div>

                                    <div class="form-group">
                                        <label for="input-Surname"> Фамилия </label>
                                        <input type="text" className="form-control" id="input-Surname" />
                                    </div>

                                    <div class="form-group">
                                        <label for="input-Birthday"> Дата рождения </label>
                                        <input type="text" className="form-control" id="input-Birthday" />
                                    </div>
                                </div>

                                <div className="data-Columns thirdColumn">
                                    <div class="form-group">
                                        <label for="input-Email"> Имя </label>
                                        <input type="Email" className="form-control" id="input-Email" />

                                    </div>
                                    <div class="form-group">
                                        <label for="input-Phone"> Имя </label>
                                        <input type="PheneNumber" className="form-control" id="input-Phone" />
                                    </div>
                                </div>

                            </div>

                            <button type="button" className="btn btn-default"> Сохранить изменения </button>

                        </div>

                       

                    </div>
                </div>

            </div>  
        )
    }
}