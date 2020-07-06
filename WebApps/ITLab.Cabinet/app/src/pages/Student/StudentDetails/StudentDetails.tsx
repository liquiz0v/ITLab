import * as React from 'react';
import { connect } from 'react-redux';
import { AppState } from 'reducer';
//import { getStudentInfo } from './actions'
import { Student, Course } from '../reducer';

interface StateFromProps{
    student?: Student,
    studentCources?: Course[]
}

interface DispatchFromProps{
    //getStudentInfo: (userId : number) => void;
}

interface OwnStateProps{

}

class StudentDetails extends React.Component<StateFromProps & DispatchFromProps, OwnStateProps> {
    constructor(props: StateFromProps & DispatchFromProps ) {
        super(props);
        
        this.state = {

        };

    }

    render() {
        return (
            <div>StudentDetails Page</div>
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
    //getStudentInfo
})(StudentDetails);