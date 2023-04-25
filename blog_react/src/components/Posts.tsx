import React, { Component } from 'react';
import ApiRoutes from '../ApiRoutes';
import jwtToken from './jwtToken';
import { blog } from './PostEdit';

//interface blog {
//    blogId: string;
//    subDescription: string;
//    createDate: Date;
//    authorId: string;
//    authorName: string;
//    title: string;
//}
interface posts {
    events: blog[]
}
export class Posts extends Component {
    state: posts;
    constructor(props: posts) {
        super(props);
        this.state = props;
        this.setState({ events: [] });

        console.log(jwtToken.fnTokenGet());
        this.fetchPostList();
    }

    async fetchPostList() {
        fetch(ApiRoutes.ApiRoot + '/blog', {
            method: "GET",
            headers: {
                Authorization: `Bearer ${jwtToken.fnTokenGet()}`
            }
        })
            .then(async (res) => {
                let json = await res.json() as blog[];
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
                        this.state.events?.map((item, index) => (
                            <li key={index} id={item.blogId}>
                                <a href={'./posts/' + index}>
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