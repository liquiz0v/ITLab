import React, { Component } from 'react';

import './Menu_left.css';

export default class MenuLeft extends Component {
    render() {

        return (
            <div class="MenuLeft">
                <ul>
                    <li><a href=""> Профиль   </a></li>
                    <li><a href=""> Календарь </a></li>
                    <li><a href=""> Список    </a></li>
                    <li><a href=""> Книги     </a></li>
                </ul>
            </div>
        )
    }
}