import React, { Component } from 'react';
import ApiRoutes from '../ApiRoutes';

export class Posts extends Component {
    constructor(props) {
        super();
        this.state = {
            events: []
        };
        this.fetchPostList();
    }

    fetchPostList() {
        fetch(ApiRoutes.ApiRoot + '/blog', { method: "GET" })
            .then(async (res) => {
                let json = await res.json()
                console.log(json);
                this.setState({
                    events: json
                });
            });
    }

    render() {
        return (
            <div>
                <span>Posts</span>
                <ul>
                    {
                        this.state.events.map((item, index) => (
                            <li key={index} id={item.blogId}>
                                <a href={ './posts/' + index}>
                                    {item.title} {item.blogId}
                                </a>
                            </li>
                        ))
                    }
                </ul>

            </div>
        );
    }
}