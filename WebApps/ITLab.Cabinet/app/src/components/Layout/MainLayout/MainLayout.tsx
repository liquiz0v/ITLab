import * as React from 'react';

import { Link, Route, Switch } from 'react-router-dom';
import StudentDetails from "../../../pages/Student/StudentDetails/StudentDetails";

import { connect } from 'react-redux'
import '../../../App.css';
import { AppState } from 'reducer';
import { getStudentInfo } from '../../../pages/Student/StudentDetails/actions'
import { Student } from '../../../pages/Student/reducer';


interface StateFromProps {
    student?: Student
}

interface DispatchFromProps {
    getStudentInfo: (userId: number) => void;
}

class MainLayout extends React.Component<any> {
    constructor(props: any) {
        super(props);

        this.state = {

        };

    }

    render() {

        const emptyPageMessage = 'check MainLayout.tsx to add this page';
        const calendar = (<>{emptyPageMessage}</>);
        const myLessons = (<>{emptyPageMessage}</>);
        const myHometasks = (<>{emptyPageMessage}</>);

        let { student } = this.props;
        let userAvatar = 'avatar_error';
        if(student){
            userAvatar = student.AvatarPhoto;
        }
        
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
                                <img src={userAvatar}></img>
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

        const siderMenu: JSX.Element = (
            <div className="Cabinet-main">
                <ul>
                    <li><Link to='general'>Главная</Link></li>
                    <li><Link to='calendar'>Календарь</Link></li>
                    <li><Link to='my-lessons'>Мои Занятия </Link></li>
                    <li><Link to='my-home-tasks'>Мои Домашние Задания</Link></li>
                </ul>

                <Switch>
                    <Route path='/general' render={() => <StudentDetails />} />
                    <Route path='/calendar' render={() => calendar} />
                    <Route path='/my-lessons' render={() => myLessons} />
                    <Route path='/my-home-tasks' render={() => myHometasks} />
                </Switch>

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

const mapStateToProps = (state: AppState): StateFromProps => {
    return {
        student: state.student.student
    };
};

export default connect<StateFromProps, DispatchFromProps, any, AppState>(mapStateToProps, {
    getStudentInfo
})(MainLayout);
