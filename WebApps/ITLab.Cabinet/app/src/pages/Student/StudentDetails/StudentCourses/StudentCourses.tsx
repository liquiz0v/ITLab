import * as React from 'react';
import { connect } from 'react-redux';
import { AppState } from '../../../../reducer';
import { Student, Course, Lesson, StudentStatistics } from '../../reducer';
import '../../../../App.css';
import { Col, Row, Radio,  Progress } from 'antd';
import "react-step-progress-bar/styles.css";
import { ProgressBar, Step } from 'react-step-progress-bar';
import { getCourseLessons, getStudentStatistics } from '../actions';

import './StudentCourses.css'
// import { StudentStatistics as StudentStatisticsPage } from 'pages/Student/StudentStatictics/StudentStatistics';

interface StateFromProps {
    student?: Student,
    courseLessons?: Lesson[],
    studentStatistics?: StudentStatistics
}

interface DispatchFromProps {
    getCourseLessons: (courseId: number) => void;
    getStudentStatistics: (courseId: number, studentId: number) => void;
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

        if(prevProps.studentCources !== this.props.studentCources){

            if(this.props.studentCources && this.props.studentCources.length > 0 && this.props.studentCources[0] && this.props.student){
                this.props.getCourseLessons(this.props.studentCources[0].CourseId);
                this.props.getStudentStatistics(this.props.studentCources[0].CourseId, this.props.student.StudentId);
            }

        }

        if(this.state.courseSelected && prevState.courseSelected !== this.state.courseSelected && this.props.student){

            this.props.getCourseLessons(this.state.courseSelected);
            this.props.getStudentStatistics(this.state.courseSelected, this.props.student.StudentId);
        }
    }

    getEmptyCoursesContent = () => {
        return <p>На данный момент Вы не записаны на наши курсы.</p>;
    }

    onCourseSelected = (e: any) => {
        this.setState({ courseSelected: e.target.value });
        
    }

    getCoursesContent = () => {
        let { studentCources, courseLessons, studentStatistics } = this.props;
        let currDate = new Date();

        let accomplishedCount: number;
        let unAccomplishedCount: number;
        
        accomplishedCount = 0;
        unAccomplishedCount = 0;

        const progressColor = { //have stayed here as template, for how set colors and etc
            '0%': '#108ee9',
            '100%': '#87d068',
        };

        const progressPerencent = (accomplishedCount/(accomplishedCount + unAccomplishedCount));
 
        if (studentCources && courseLessons && studentStatistics) {
            return (
                <>
                    <Radio.Group defaultValue={this.state.courseSelected ? this.state.courseSelected : studentCources[0].CourseId} buttonStyle="solid" onChange={this.onCourseSelected}>
                        {
                           studentCources.map((course: Course) => {
                                return <Radio.Button className='radio-button' value={course.CourseId}>{course.Name}</Radio.Button>
                            })
                        }
                    </Radio.Group>
                    
                    <Row>
                        <Col span={24} >

                            <ProgressBar percent={progressPerencent}>
                            {
                                courseLessons.map((lesson: Lesson, index: number) => {
                                    let stepContent;
                                    const lessonDate = new Date(lesson.LessonDateFrom)
                                    if (lessonDate.getTime() < currDate.getTime()) {
                                        stepContent = (<Step transition="scale">
                                            {(accomplished: true) => {
                                                accomplishedCount =+ 1;
                                                return (
                                                <div
                                                    className={`indexedStep ${accomplished ? "accomplished" : null}`}
                                                >
                                                    {index + 1}
                                                </div>
                                            )}}
                                        </Step>);
                                        return stepContent;
                                    }
                                    else {
                                        stepContent = (<Step transition="scale">
                                            {(accomplished: true) => {
                                                unAccomplishedCount =+ 1;
                                                return (
                                                <div
                                                    className={`indexedStep`}
                                                >
                                                    {index + 1}
                                                </div>
                                            )}}
                                        </Step>);
                                        return stepContent;
                                    }
                                })
                            }
                            </ProgressBar>


                        </Col>

                        <Col span={24} style={{marginTop : 50}}>

                            <Progress className='progress-item' type="circle" width={100} percent={100} 
                            format={() => studentStatistics?.StudentPositionInRating} />
                            <Progress className='progress-item' type="circle" width={100} strokeColor={progressColor} percent={(studentStatistics?.AverageMark/100)*100} 
                            format={() => `${studentStatistics?.AverageMark}`} />
                            <Progress className='progress-item' type="circle" width={100} percent={(studentStatistics?.CompletedTasksCount/studentStatistics?.OverallTasksCount)*100} 
                            format={() => `${studentStatistics?.CompletedTasksCount} из ${studentStatistics?.OverallTasksCount}`} status="exception" />
                            <Progress className='progress-item' type="circle" width={100} percent={100} 
                            format={() => `${studentStatistics?.VisitedLessons}`} />

                        </Col>
                </Row>
                </>
            );
        }

        return null;
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
        courseLessons: state.student.courseLessons,
        studentStatistics: state.student.studentStatistics
    };
};

export default connect<StateFromProps, DispatchFromProps, any, AppState>(mapStateToProps, {getCourseLessons, getStudentStatistics })(StudentCourses);