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
    return {
        type: GET_STUDENT_INFORMATION.SUCCESS,
        student: student
    };
};

export const getUserInfo = (userId: number) => {
    return (dispatch: any) => {
        dispatch(getStudentInfoRequest());
        const queryParams = `${userId}`;
        axios.get('/users' + queryParams)
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
