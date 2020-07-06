import * as React from 'react';
import { Menu } from 'antd'

import { Link } from 'react-router-dom';



class MainLayout extends React.Component<any> {
    constructor(props: any ) {
        super(props);
        
        this.state = {

        };

    }

    render() {
        return (
             <Menu>
             <Menu.Item key="/StudentDetails">
                <span>
                    <Link to="/student-details">
                        <div>Student Details</div>
                    </Link>
                </span>
             </Menu.Item>
            <Menu.Item key="/b">
                <span>
                    <Link to="/b">
                        <div>b</div>
                    </Link>
                </span>
             </Menu.Item>
             </Menu>
        );
    }
}


export default MainLayout;