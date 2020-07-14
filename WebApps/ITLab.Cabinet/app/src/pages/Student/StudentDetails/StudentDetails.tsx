import * as React from 'react';
import { connect } from 'react-redux';
import { AppState } from 'reducer';
import { getStudentInfo } from './actions'
import { Student, Course } from '../reducer';

interface StateFromProps{
    student?: Student,
    studentCources?: Course[]
}

interface DispatchFromProps{
    getStudentInfo: (userId : number) => void;
}

interface OwnStateProps{

}

class StudentDetails extends React.Component<StateFromProps & DispatchFromProps, OwnStateProps> {
    constructor(props: StateFromProps & DispatchFromProps ) {
        super(props);
        
        this.state = {

        };

    }

    componentDidMount = () => {
        this.props.getStudentInfo(2);
    }

    render() {
        let name = this.props.student ? this.props.student.Name : 'name_error';
        let avatar = this.props.student ? this.props.student.AvatarPhoto : 'photo_error';

        return (
            <>
            <div>{ name }</div>
                <div className="profile-block-left">
                    <div className="main-avatar">
                        <img src={ avatar }/>
                    </div>

                    <b className="profile-name"></b>
                    <button id="edit_profile">Редактировать профиль</button>
                </div>
                
                <div className="profile-block-right">
					<p>На данный момент Вы не записаны на наши курсы.</p>
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