import * as React from 'react';
import { connect } from 'react-redux';
import { AppState } from 'reducer';
import { getStudentInfo } from './actions'
import { Student, Course } from '../reducer';
import '../../../App.css';
interface StateFromProps {
    student?: Student,
    studentCources?: Course[]
}

interface DispatchFromProps {
    getStudentInfo: (userId: number) => void;
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
        this.props.getStudentInfo(2);
    }

    render() {
        let { student } = this.props;

        let name = student ? student.Name : 'name_error';
        let avatar = student ? student.AvatarPhoto : 'photo_error';

        return (
            <>
                <div className="Profile-data">
                    <div className="Profile-block-left">
                        <div className="Main-avatar">
                            <img src={avatar} />
                        </div>
                        <b className="Profile-name">{name}</b>
                        <button id="Edit_profile">Редактировать профиль</button>
                    </div>
                    <div className="Profile-block-right">
                        <p>На данный момент Вы не записаны на наши курсы.</p>
                    </div>
                </div>
            </>
        );
    }
}

const mapStateToProps = (state: AppState): StateFromProps => {
    return {
        student: state.student.student,
        studentCources: state.student.studentCourses

    };
};

export default connect<StateFromProps, DispatchFromProps, any, AppState>(mapStateToProps, {
    getStudentInfo
})(StudentDetails);