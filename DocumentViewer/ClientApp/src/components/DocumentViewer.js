import React, { Component } from 'react';
import './DocumentViewer.css';

export default class DocumentViewer extends Component {
    constructor(props) {
        super(props);
        this.state = {
            viewerHtml: '',
            loading: true
        };
    }

    render() {
        return (
            <div>
                <p>Document viewer</p>
                <div id="dvContainer">
                </div>
            </div>
            )
    }
}