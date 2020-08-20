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
class LessonDetailed extends React.Component<StateFromProps & DispatchFromProps & PassedProps & RouteComponentProps, OwnStateProps> {
    constructor(props: StateFromProps & DispatchFromProps & PassedProps & RouteComponentProps) {
        super(props);
        
        this.state = {

        };
    }

    render() {
        return (
            <div>
                LessonId: {this.props.history.location.search}
                <button onClick={() => this.props.history.push('/general')} > hui </button>
            </div>
        )
    }
}

export default withRouter(LessonDetailed);
