import { updateObject } from '../../helpers/updateObjectHelper'
import { GET_STUDENT_INFORMATION } from './StudentDetails/actions'
import { GET_STUDENT_COURSES } from './StudentDetails/actions'
import { GET_COURSE_LESSONS } from './StudentDetails/actions'
import { GET_STUDENT_STATISTICS } from './StudentDetails/actions'

export type Student = {
    StudentId: number;
    Name: string;
    Password: string;
    AvatarPhoto: string;
};

export type Lesson = {
    LessonId: number;
    Name: string;
    Description: string;
    LessonDateFrom: Date;
    LessonDateTo: Date;
}

export type Course = {
    CourseId: number;
    Name: string;
    Description: string;
    Lessons: Lesson[];
};

export type StudentStatistics = {
    StudentId: number;
    StudentPositionInRating: number;
    AverageMark: number;
    CompletedTasksCount: number;
    OverallTasksCount: number;
    CompletedLessons: number;
    VisitedLessons: number;
}

export type StudentState = {
    student?: Student,
    studentCourses?: Course[],
    courseLessons?: Lesson[],
    studentStatistics?: StudentStatistics
};

const initialState: StudentState = {
    student: undefined,
    studentCourses: [],
    courseLessons: [],
    studentStatistics: undefined
}

export const reducer = (state: StudentState = initialState, action: any) => {
    switch (action.type) {
        case GET_STUDENT_INFORMATION.REQUEST:
            return updateObject(state, { student : undefined });
        case GET_STUDENT_INFORMATION.SUCCESS:
            return updateObject(state, { student: action.student });
        case GET_STUDENT_COURSES.REQUEST:
            return updateObject(state, { studentCourses : undefined });
        case GET_STUDENT_COURSES.SUCCESS:
            return updateObject(state, { studentCourses: action.studentCourses });
        case GET_COURSE_LESSONS.REQUEST:
            return updateObject(state, { courseLessons: undefined });
        case GET_COURSE_LESSONS.SUCCESS:
            return updateObject(state, { courseLessons: action.courseLessons });
        case GET_STUDENT_STATISTICS.REQUEST:
            return updateObject(state, { studentStatistics: undefined});
        case GET_STUDENT_STATISTICS.SUCCESS:
            return updateObject(state, { studentStatistics: action.studentStatistics});

        default:
            return state;
    }
}


