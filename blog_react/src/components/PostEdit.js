import React, { Component } from 'react';
import { CKEditor } from '@ckeditor/ckeditor5-react';
import ClassicEditor from '@ckeditor/ckeditor5-build-classic';
import ApiRoutes from '../ApiRoutes';

export class PostEdit extends Component {
    constructor(props) {
        super(props);
        this.state = {
            blog: {}
        };
        const { id } = this.props;
        console.log(id);

        this.fetchBlogDetail(id);
    }

    fetchBlogDetail(blogId) {
        console.log(ApiRoutes.ApiRoot + '/blog/' + blogId);
        fetch(ApiRoutes.ApiRoot + '/blog/' + blogId, { method: 'GET' })
            .then(async (res) => {
                let json = await res.json();
                console.log(json);
                this.setState({ blog: json });
            })
            .catch((res) => {
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

                <CKEditor
                    editor={ClassicEditor}
                    data="<p>Hello from CKEditor 5!</p>"
                />
            </div>);
    }
}