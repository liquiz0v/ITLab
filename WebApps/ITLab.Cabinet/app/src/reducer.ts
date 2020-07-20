
import { combineReducers } from 'redux';

import { reducer as studentReducer, StudentState } from './pages/Student/reducer';


export type Dictionary = {
    Id: number;
    Name: string;
};

export interface AppState {
    student: StudentState;
}
const rootReducer = combineReducers<AppState>({
    student: studentReducer,
});

export default rootReducer;