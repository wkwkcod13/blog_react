import React, { Component } from 'react';
//import { CKEditor } from '@ckeditor/ckeditor5-react';
//import ClassicEditor from '@ckeditor/ckeditor5-build-classic';
import ApiRoutes from '../ApiRoutes';
import PropTypes from 'prop-types';

export interface blog {
    blogId: string;
    subDescription: string;
    createDate: Date;
    authorId: string;
    authorName: string;
    title: string;
}

interface postEdit {
    id: string,
    blog: blog
}

export class PostEdit extends Component {
    state: postEdit;
    static protoTypes = {
        id: PropTypes.string
    }

    constructor(props: postEdit) {
        super(props);
        this.state = props;
        this.setState({ blog: {} });
        const { id } = props;
        const token = localStorage.getItem('jwtToken') ?? "";
        console.log(id);
        this.fetchBlogDetail(id, token);
    }

    fetchBlogDetail(blogId: string, token: string) {
        console.log(ApiRoutes.ApiRoot + '/blog/' + blogId);
        fetch(ApiRoutes.ApiRoot + '/blog/' + blogId, {
            method: 'GET',
            headers: {
                'Authorization': `Bearer ${token}`
            }
        }).then(async (res: Response) => {
            let json = await res.json();
            console.log(json);
            this.setState({ blog: json });
        }).catch((res) => {
        })
    }

    render() {
        return (
            <div>
                <span>
                    PostEdit {this.state.blog.title}
                </span>
                <span>{this.state.blog.blogId}</span>
                <input></input>
            </div>);
    }
}