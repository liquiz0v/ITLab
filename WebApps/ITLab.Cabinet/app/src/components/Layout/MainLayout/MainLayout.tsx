import * as React from 'react';
import { Menu } from 'antd'

import { Link } from 'react-router-dom';
import  StudentDetails from "../../../pages/Student/StudentDetails/StudentDetails";

import '../../../App.css';


class MainLayout extends React.Component<any> {
    constructor(props: any) {
        super(props);
        
        this.state = {

        };

    }

    render() {
        const navBar : JSX.Element = (
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
                                <img src="images/avatar.png"></img>
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
        
        const siderMenu : JSX.Element = (
            <Menu
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
             </Menu>
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