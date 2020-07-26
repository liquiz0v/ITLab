import axios from '../../../api/axiosInstance';
import { Student, Course } from '../reducer';

//Get student info
export enum GET_STUDENT_INFORMATION {
    REQUEST = 'GET_STUDENT_INFORMATION_REQUEST',
    SUCCESS = 'GET_STUDENT_INFORMATION_SUCCESS',
}

export const getStudentInfoRequest = () => {
    return {
        type: GET_STUDENT_INFORMATION.REQUEST
    };
};

export const getStudentInfoSuccess = (student: Student) => {
    return {
        type: GET_STUDENT_INFORMATION.SUCCESS,
        student: student
    };
};


export const getStudentInfo = (userId: number) => {
    return (dispatch: any) => {
        dispatch(getStudentInfoRequest());
        const queryParams = `?studentId=${userId}`;
        axios.get(`Student/GetStudent${queryParams}`)
            .then(response => {
                dispatch(getStudentInfoSuccess(response.data));
            })
            .catch((error: any) => {
                alert(error.response); //wii be antd alert with good design
            });
    };
};


//Get student courses
export enum GET_STUDENT_COURSES {
    REQUEST = 'GET_STUDENT_COURSES_REQUEST',
    SUCCESS = 'GET_STUDENT_COURSES_SUCCESS',
}
export const getStudentCoursesRequest = () => {
    return {
        type: GET_STUDENT_COURSES.REQUEST
    };
};

export const getStudentCoursesSuccess = (studentCourses: Course[]) => {
    return {
        type: GET_STUDENT_COURSES.SUCCESS,
        studentCourses: studentCourses
    };
};

export const getStudentCourses = (userId: number) => {
    return (dispatch: any) => {
        dispatch(getStudentCoursesRequest());
        const queryParams = `?studentId=${userId}`;
        axios.get(`Course/GetStudentCourses${queryParams}`)
            .then(response => {
                dispatch(getStudentCoursesSuccess(response.data));
            })
            .catch((error: any) => {
                alert(error.response); //wii be antd alert with good design
            });
    };
};




//for test POST METHOD 
export const getUserInfoPost = (userId: number) => {
    return (dispatch: any) => {
        dispatch(getStudentInfoRequest());
        axios.post('/users', { userId: userId }) //any object for params 
            .then(response => {
                dispatch(getStudentInfoSuccess(response.data));
            })
            .catch((error: any) => {
                alert(error.response);
            });
    };
};
