import React, { Component } from 'react';

import './Header.css';

export default class Header extends Component {
    render() {

        const {
            title,
            className,
            userImage,
        } = this.props

        return (
            <div className={`header ${className}`}>
                <div class="header-wrapper">
                    <nav>
                        <ul>
                            <li><a href="/"><span>IT Lab Odessa</span></a></li>
                            <li><a href="">{title}</a></li>
                        </ul>
                    </nav>

                    <div class="header-profile">

                        <div class="avatar">
                            <img src={userImage} />
				        </div>
                        <ul>
                            <li><a href="#">Редактирование профиля</a></li>
                            <li><a href="#">Выход</a></li>
                        </ul>
                    </div>   
                </div>  
             </div>
        )
    }
}

