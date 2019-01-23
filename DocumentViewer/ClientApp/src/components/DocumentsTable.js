import React, { Component } from 'react';
import './DocumentsTable.css';
import Moment from 'react-moment';
import { getDocument, displayDocument } from '../services/documentService';

export default class DocumentsTable extends Component {
    constructor(props) {
        super(props);

        this.renderDocumentsTable = this.renderDocumentsTable.bind(this);
    };
    
    async rowClick(id) {
        try {
            const data = await getDocument(id);
            displayDocument(data);
        } catch (err) {
            console.log('err', err);
        }
    }

    renderDocumentsTable(documents) {
        return (
            <table className='table table-hover'>
                <thead>
                    <tr>
                        <th>Document Number</th>
                        <th>Document Name</th>
                        <th>Date</th>
                    </tr>
                </thead>
                <tbody>
                    {documents.map(x =>
                        <tr key={x.id} onClick={ () => this.rowClick(x.id)}>
                            <td>{x.documentNumber}</td>
                            <td>{x.documentName}</td>
                            <td><Moment format="DD/MM/YYYY HH:mm:ss">{x.datetime}</Moment></td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.props.loading
            ? <p><em>Loading documents...</em></p>
            : this.renderDocumentsTable(this.props.data);

        return (
            <div>
                {contents}
            </div>
        );
    }
}