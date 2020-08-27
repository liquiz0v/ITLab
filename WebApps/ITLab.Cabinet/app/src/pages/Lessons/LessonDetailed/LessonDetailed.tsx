import React from 'react'
import {RouteComponentProps, withRouter} from 'react-router-dom';

interface StateFromProps {
    
}

interface DispatchFromProps {
   
}

interface OwnStateProps {

}

interface PassedProps {

}
class LessonDetailed extends React.Component<StateFromProps & DispatchFromProps & PassedProps & any & RouteComponentProps, OwnStateProps> {
    constructor(props: StateFromProps & DispatchFromProps & PassedProps & any & RouteComponentProps) {
        super(props);
        
        this.state = {

        };
    }

    render() {
        return (
            <div>
                LessonId: {this.props.history.location.search}
                <button onClick={() => this.props.history.push('/general')} > btn </button>
            </div>
        )
    }
}

export default withRouter(LessonDetailed);
