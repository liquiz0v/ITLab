import * as React from 'react';
import { connect } from 'react-redux';
import { AppState } from '../../../../reducer';
import { Student, Course, Lesson } from '../../reducer';
import '../../../../App.css';
import { Col, Row, Radio } from 'antd';
import "react-step-progress-bar/styles.css";
import { ProgressBar, Step } from 'react-step-progress-bar';
import { getCourseLessons } from '../actions';

import './StudentCourses.css'

interface StateFromProps {
    student?: Student,
    courseLessons?: Lesson[]
}

interface DispatchFromProps {
    getCourseLessons: (courseId: number) => void;
}

interface OwnStateProps {
    courseSelected?: number;

}
interface PassedProps {
    studentCources?: Course[];
}

class StudentCourses extends React.Component<StateFromProps & DispatchFromProps & PassedProps, OwnStateProps> {
    constructor(props: StateFromProps & DispatchFromProps & PassedProps) {
        super(props);

        this.state = {

        };

    }

    componentDidUpdate = (prevProps: any, prevState: OwnStateProps) => {

        if(prevState.courseSelected && prevState.courseSelected !== this.state.courseSelected){
            if(this.state.courseSelected)
                this.props.getCourseLessons(this.state.courseSelected);
        }
    }

    getEmptyCoursesContent = () => {
        return <p>На данный момент Вы не записаны на наши курсы.</p>;
    }

    onCourseSelected = (e: any) => {
        this.props.getCourseLessons(e.value);
        this.setState({ courseSelected: e.value });
    }

    getCoursesContent = () => {
        let { studentCources, courseLessons } = this.props;
        let currDate = new Date();

        console.log(courseLessons);

        if (studentCources && courseLessons) {
            return (
                <>
                    <Radio.Group defaultValue={studentCources[0].CourseId} buttonStyle="solid" onChange={(e: any) => this.onCourseSelected(e)}>
                        {
                            studentCources.map((course: Course) => {
                                return <Radio.Button className='radio-button' value={course.CourseId}>{course.Name}</Radio.Button>
                            })
                        }
                    </Radio.Group>

                    <ProgressBar>
                    {
                        courseLessons.map((lesson: Lesson) => {
                            console.log(lesson);
                            let stepContent;
                            const lessonDate = new Date(lesson.LessonDateFrom)
                            if (lessonDate.getTime() < currDate.getTime()) {
                                stepContent = (<Step transition="scale">
                                    {(accomplished: true) => (
                                        <div
                                            className={`indexedStep ${accomplished ? "accomplished" : null}`}
                                        >
                                            1
                                        </div>
                                    )}
                                </Step>);
                                return stepContent;
                            }
                            else {
                                stepContent = (<Step transition="scale">
                                    {(accomplished: true) => (
                                        <div
                                            className={`indexedStep`}
                                        >
                                            1
                                        </div>
                                    )}
                                </Step>);
                                return stepContent;
                            }
                        })
                    }
                    </ProgressBar>
                </>
            );
        }

        return null;
    }

    render() {
        let { studentCources } = this.props;

        const haveCources = studentCources ? studentCources.length > 0 : false;

        console.log(studentCources);
        
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
        courseLessons: state.student.courseLessons
    };
};

export default connect<StateFromProps, DispatchFromProps, any, AppState>(mapStateToProps, {getCourseLessons})(StudentCourses);