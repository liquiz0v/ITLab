import * as React from 'react';
import { connect } from 'react-redux';
import { AppState } from 'reducer';
import { getStudentInfo, getStudentCourses } from './actions'
import { Student, Course } from '../reducer';
import './StudentDetails.css'
import StudentCourses from './StudentCourses/StudentCourses'
  

interface StateFromProps {
    student?: Student,
    studentCourses?: Course[]
}

interface DispatchFromProps {
    getStudentInfo: (userId: number) => void;
    getStudentCourses: (userId: number) => void;
}

interface OwnStateProps {

}

class StudentDetails extends React.Component<StateFromProps & DispatchFromProps, OwnStateProps> {
    constructor(props: StateFromProps & DispatchFromProps) {
        super(props);

        this.state = {

        };

    }

    componentDidMount = () => {
        this.props.getStudentInfo(1);
        this.props.getStudentCourses(1);
    }

    render() {
        let { student } = this.props;

        let name = student ? student.Name : 'name_error';
        let avatar = student ? student.AvatarPhoto : undefined;

        return (
            <>
                <div className="Profile-data">
                    <div className="Profile-block-left">
                        <div className="Main-avatar">
                            <img src={avatar} alt='photo_error' />
                        </div>
                        <b className="Profile-name">{name}</b>
                        <button id="Edit_profile">Редактировать профиль</button>
                    </div>
                    <StudentCourses studentCources={this.props.studentCourses}/>
                </div>
            </>
        );
    }
}

const mapStateToProps = (state: AppState): StateFromProps => {
    return {
        student: state.student.student,
        studentCourses: state.student.studentCourses

    };
};

export default connect<StateFromProps, DispatchFromProps, any, AppState>(mapStateToProps, {
    getStudentInfo,
    getStudentCourses
})(StudentDetails);