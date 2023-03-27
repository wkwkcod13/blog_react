import React, { Component } from 'react';
import { CKEditor } from '@ckeditor/ckeditor5-react';
import ClassicEditor from '@ckeditor/ckeditor5-build-classic';

export class PostEdit extends Component {
    render() {
        return (
            <div>
                <span>
                    PostEdit
                </span>
                <CKEditor
                    editor={ClassicEditor}
                    data="<p>Hello from CKEditor 5!</p>"
                />
            </div>);
    }
}