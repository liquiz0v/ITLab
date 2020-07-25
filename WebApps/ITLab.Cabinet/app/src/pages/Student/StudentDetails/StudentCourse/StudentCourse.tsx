import * as React from 'react';
import { connect } from 'react-redux';
import { AppState } from '../../../../reducer';
import { Student, Course } from '../../reducer';
import '../../../../App.css';
import { Button, Col, Row } from 'antd';

interface StateFromProps {
    student?: Student,
}

interface DispatchFromProps {

}

interface OwnStateProps {

}
interface PassedProps {
    studentCources?: Course[]
}

class StudentCourse extends React.Component<StateFromProps & DispatchFromProps & PassedProps, OwnStateProps> {
    constructor(props: StateFromProps & DispatchFromProps) {
        super(props);

        this.state = {

        };

    }

    componentDidMount = () => {

    }

    getButton = (content: any) => {

        return <Button type="primary">content</Button>;
    };

    getEmptyCoursesContent = () => {
        return <p>На данный момент Вы не записаны на наши курсы.</p>;
    }

    getCoursesContent = () => {
        return (
            this.props.studentCources ? this.props.studentCources.map((cource: Course) => {
                this.getButton(cource.Name);
            }) : null
        );
    }

    render() {
        let { studentCources } = this.props;

        const haveCources = studentCources ? studentCources.length > 0 : false;

        return (
            <>
                <div className="Profile-block-right">
                    <Row>
                        <Col span={12}>
                            {haveCources ? this.getCoursesContent() : this.getEmptyCoursesContent()}
                        </Col>
                        <Col span={12}>

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

export default connect<StateFromProps, DispatchFromProps, any, AppState>(mapStateToProps, {})(StudentCourse);