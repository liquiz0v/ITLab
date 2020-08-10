import { updateObject } from '../../helpers/updateObjectHelper'
import { GET_STUDENT_INFORMATION } from './StudentDetails/actions'
import { GET_STUDENT_COURSES } from './StudentDetails/actions'
import { GET_COURSE_LESSONS } from './StudentDetails/actions'

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

export type StudentState = {
    student?: Student,
    studentCourses?: Course[],
    courseLessons?: Lesson[]
};

const initialState: StudentState = {
    student: undefined,
    studentCourses: [],
    courseLessons: [],
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

        default:
            return state;
    }
}


