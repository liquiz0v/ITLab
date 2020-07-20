import { updateObject } from '../../helpers/updateObjectHelper'
import { GET_STUDENT_INFORMATION } from './StudentDetails/actions'

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
};

const initialState: StudentState = {
    student: undefined,
    studentCourses: []
}

export const reducer = (state: StudentState = initialState, action: any) => {
    switch (action.type) {
        case GET_STUDENT_INFORMATION.REQUEST:
            return updateObject(state, { student : undefined });
        case GET_STUDENT_INFORMATION.SUCCESS:
            return updateObject(state, { student: action.student });

        default:
            return state;
    }
}


