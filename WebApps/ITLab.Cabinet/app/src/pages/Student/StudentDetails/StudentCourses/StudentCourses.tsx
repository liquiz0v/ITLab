import * as React from 'react';
import { connect } from 'react-redux';
import { AppState } from '../../../../reducer';
import { Student, Course } from '../../reducer';
import '../../../../App.css';
import { Col, Row, Radio, Steps, Progress } from 'antd';

import './StudentCourses.css'

const { Step } = Steps;

interface StateFromProps {
    student?: Student,
}

interface DispatchFromProps {

}

interface OwnStateProps {
    currentLesson: number

}
interface PassedProps {
    studentCources?: Course[]
}

class StudentCourses extends React.Component<StateFromProps & DispatchFromProps & PassedProps, OwnStateProps> {
    constructor(props: StateFromProps & DispatchFromProps) {
        super(props);

        this.state = {
            currentLesson: 1
        };

    }

    componentDidMount = () => {

    }


    getEmptyCoursesContent = () => {
        return <p>На данный момент Вы не записаны на наши курсы.</p>;
    }

    onCourseSelected = (e: any) => {

        alert(e.target.value);
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

        const progressColor = {
            '0%': '#108ee9',
            '100%': '#87d068',
        };

        return (
            <>
                <div className="Profile-block-right">
                    <Row>
                        <Col span={12}>
                            {haveCources ? this.getCoursesContent() : this.getEmptyCoursesContent()}
                        </Col>

                    </Row>
                    <Row>
                        <Col span={12} >

                            <Steps progressDot current={1} size="small">
                                <Step title="1" description="" />
                                <Step title="2" description="" />
                                <Step title="3" description="" />
                                <Step title="4" description="" />
                            </Steps>
                        </Col>
                        <Col>
                            <Row>
                                <Progress className='progress-item' type="circle" width={100} percent={100} format={() => '2'} />
                                <Progress className='progress-item' type="circle" width={100} strokeColor={progressColor} percent={20} format={() => '2 из 10'}/>
                                <Progress className='progress-item' type="circle" width={100} percent={100} format={() => '3'} status="exception"/>
                                <Progress className='progress-item' type="circle" width={100} percent={100} format={() => '9 из 9'}/>
                            </Row>
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
        //studentCources: state.student.studentCourses

    };
};

export default connect<StateFromProps, DispatchFromProps, any, AppState>(mapStateToProps, {})(StudentCourses);