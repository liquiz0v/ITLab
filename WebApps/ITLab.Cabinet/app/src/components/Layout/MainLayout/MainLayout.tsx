import * as React from 'react';
// import { Menu } from 'antd'

// import { Link } from 'react-router-dom';
// import StudentDetails from "../../../pages/Student/StudentDetails/StudentDetails";

import '../../../App.css';
import avatar from '../../../static/images/avatar.png';

class MainLayout extends React.Component<any> {
    constructor(props: any) {
        super(props);

        this.state = {

        };

    }

    render() {
        const navBar: JSX.Element = (
            <div>
                <header>
                    <div className="Header-wrapper">
                        <nav>
                            <ul>
                                <li><a href="/"><span>IT Lab Odessa</span></a></li>
                                <li><a href="">Профиль</a></li>
                            </ul>
                        </nav>
                        <div className="Header-profile">

                            <div className="Avatar">
                                <img src={avatar}></img>
                            </div>
                            <ul>
                                <li><a href="#">Редактирование профиля</a></li>
                                <li><a href="#">Выход</a></li>
                            </ul>
                        </div>
                    </div>
                </header>
            </div>
        );
        
        const emptyProfile = (
            <div className="Profile-data">
                <div className="Profile-block-left">
                    <div className="Main-avatar">
                        <img src={avatar} />
                    </div>
                    <b className="Profile-name">Иван Иванов</b>
                    <button id="Edit_profile">Редактировать профиль</button>
                </div>
                <div className="Profile-block-right">
                    <p>На данный момент Вы не записаны на наши курсы.</p>
                </div>
            </div>
        );

        const siderMenu: JSX.Element = (
            <div className="Cabinet-main">
                <ul>
                    <li><a href="">Главная</a></li>
                    <li><a href="">Календарь</a></li>
                    <li><a href="">Список</a></li>
                    <li><a href="">Книги</a></li>
                </ul>
                {emptyProfile}
            </div>
        );



        return (
            <>
                {navBar}
                {siderMenu}

            </>
        );
    }
}


export default MainLayout;

{/* <Menu
                style={{ width: 256 }}
                defaultSelectedKeys={['1']}
                defaultOpenKeys={['sub1']}
                mode="inline"
            >
                <Menu.Item key="/StudentDetails">
                    <span>
                        <Link to="/student-details">
                            <StudentDetails></StudentDetails>
                        </Link>
                    </span>
                </Menu.Item>
             </Menu> */}