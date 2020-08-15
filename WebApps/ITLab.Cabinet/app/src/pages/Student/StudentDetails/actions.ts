import axios from '../../../api/axiosInstance';
import { Student, Course, Lesson, StudentStatistics } from '../reducer';

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
                console.log('ERROR: ',error.response);  //wii be antd alert with good design
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
                console.log('ERROR: ',error.response);  //wii be antd alert with good design
            });
    };
};


//Get course lessons
export enum GET_COURSE_LESSONS {
    REQUEST = 'GET_COURSE_LESSONS_REQUEST',
    SUCCESS = 'GET_COURSE_LESSONS_SUCCESS',
}
export const getCourseLessonsRequest = () => {
    return {
        type: GET_COURSE_LESSONS.REQUEST
    };
};

export const getCourseLessonsSuccess = (courseLessons: Lesson[]) => {
    return {
        type: GET_COURSE_LESSONS.SUCCESS,
        courseLessons: courseLessons
    };
};

export const getCourseLessons = (courseId: number) => {
    return (dispatch: any) => {
        dispatch(getCourseLessonsRequest());
        const queryParams = `?courseId=${courseId}`;
        axios.get(`Course/GetCourseLessons${queryParams}`)
            .then(response => {
                dispatch(getCourseLessonsSuccess(response.data));
            })
            .catch((error: any) => {
                console.log('ERROR: ',error.response); 
            });
    };
};

//Get course lessons
export enum GET_STUDENT_STATISTICS {
    REQUEST = 'GET_STUDENT_STATISTICS_REQUEST',
    SUCCESS = 'GET_STUDENT_STATISTICS_SUCCESS',
}
export const getStudentStatisticsRequest = () => {
    return {
        type: GET_STUDENT_STATISTICS.REQUEST
    };
};

export const getStudentStatisticsSuccess = (studentStatistics: StudentStatistics) => {
    return {
        type: GET_STUDENT_STATISTICS.SUCCESS,
        studentStatistics: studentStatistics
    };
};

export const getStudentStatistics = (courseId: number, studentId?: number) => {
    return (dispatch: any) => {
        dispatch(getStudentStatisticsRequest());
        const queryParams = `?studentId=${studentId}&courseId=${courseId}`;
        axios.get(`Course/GetStudentStatistics${queryParams}`)
            .then(response => {
                dispatch(getStudentStatisticsSuccess(response.data));
            })
            .catch((error: any) => {
                console.log('ERROR: ',error.response); 
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
                console.log('ERROR: ',error.response); 
            });
    };
};
