import * as React from 'react';
import { connect } from 'react-redux';
import { AppState } from '../../../../reducer';
import { Student, Course } from '../../reducer';
import '../../../../App.css';
import { Col, Row, Radio } from 'antd';

import './StudentCourses.css'

interface StateFromProps {
    student?: Student,
}

interface DispatchFromProps {

}

interface OwnStateProps {
    currentLesson: number;
    courseSelected?: number;

}
interface PassedProps {
    studentCources?: Course[]
}

class StudentCourses extends React.Component<StateFromProps & DispatchFromProps & PassedProps, OwnStateProps> {
    constructor(props: StateFromProps & DispatchFromProps) {
        super(props);

        this.state = {
            currentLesson: 0
        };

    }

    componentDidMount = () => {

    }


    getEmptyCoursesContent = () => {
        return <p>На данный момент Вы не записаны на наши курсы.</p>;
    }

    onCourseSelected = (e: any) => {

        this.setState({ courseSelected: e.value });
    }

    getCoursesContent = () => {
        let { studentCources } = this.props;
        if (studentCources) {
            return (

                <Radio.Group defaultValue={studentCources[0].CourseId} buttonStyle="solid" onChange={(e: any) => this.onCourseSelected(e)}>
                    {
                        studentCources.map((course: Course) => {
                            return <Radio.Button className='radio-button' value={course.CourseId}>{course.Name}</Radio.Button>
                        })
                    }
                </Radio.Group>
            );
        }

        return null;
    }

    onLessonsStepClick = (currentLesson: number) => {
        this.setState({ currentLesson: currentLesson })
    }

    render() {
        let { studentCources } = this.props;

        const haveCources = studentCources ? studentCources.length > 0 : false;

        return (
            <>
                <div className="Profile-block-right">
                    <Row>
                        <Col span={24}>
                            {haveCources ? this.getCoursesContent() : this.getEmptyCoursesContent()}
                        </Col>
                    </Row>
                </div>
            </>
        );
    }
}

const mapStateToProps = (state: AppState): StateFromProps => {
    return {
        student: state.student.student,

    };
};

export default connect<StateFromProps, DispatchFromProps, any, AppState>(mapStateToProps, {})(StudentCourses);