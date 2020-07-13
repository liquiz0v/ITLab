import axios from '../../../api/axiosInstance';
import { Student } from '../reducer';

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
    console.log(student);
    return {
        
        type: GET_STUDENT_INFORMATION.SUCCESS,
        student: student
    };
};

export const getStudentInfo = (userId: number) => {
    return (dispatch: any) => {
        dispatch(getStudentInfoRequest());
        const queryParams = `?studentId=${userId}`;
        axios.get(`Student/GetStudent${queryParams}`) // http://25.42.18.21:82/api/Student/GetStudent?studentId=1
            .then(response => {
                dispatch(getStudentInfoSuccess(response.data));
            })
            .catch((error: any) => {
                alert(error.response);
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
