import React, { Component } from 'react';
import DocumentsTable from './DocumentsTable';
import DocumentViewer from './DocumentViewer';
import Search from './Search';
import { Container, Row, Col } from 'reactstrap';
import { getDocument, getDocuments, searchDocument, displayDocument } from '../services/documentService';

export class Home extends Component {
    constructor(props) {
        super(props);
        this.state = {
            documents: [],
            loading: true
        };

        this.loadDocument = this.loadDocument.bind(this);
        this.searchDocuments = this.searchDocuments.bind(this);
    }

    static displayName = Home.name;

    async componentDidMount() {
        try {
            const data = await getDocuments();
            this.setState({ documents: data, loading: false });

            if (data.length > 0) {
                this.loadDocument(data[0].id);
            }
        } catch (err) {
            console.log('err', err);
        }
    }

    async loadDocument(id) {
        try {
            const data = await getDocument(id);

            const checkViewerLoaded = () => {
                console.log(window.viewerLoaded);
                if (window.viewerLoaded) {
                    clearInterval(check);
                    displayDocument(data);
                    return;
                }
            };

            var check = setInterval(checkViewerLoaded, 1000);

        } catch (err) {
            console.log('err', err);
        }
    }

    async searchDocuments(data) {
        try {
            const result = await searchDocument({
                docDate: data.docDate,
                docName: data.docName,
                docNumber: data.docNumber
            });

            this.setState({ documents: result, loading: false });

            if (result.length > 0) {
                this.loadDocument(result[0].id);
            }

        } catch (err) {
            //Display error - change status
            console.log('err', err);
        }
    }

    render () {
        return (
            <Container>
                <Row>
                    <Col lg="12">
                        <h1>Document Viewer</h1>
                        <p>React and asp.net core document viewer</p>
                    </Col>
                </Row>
                <Row>
                    <Col>
                        <Search search={this.searchDocuments} />
                    </Col>
                </Row>
                <Row>
                    <br />
                </Row>
                <Row>
                    <Col>
                        <DocumentsTable data={this.state.documents} loading={this.state.loading} />
                    </Col>
                </Row>
                <Row>
                    <Col>
                        <DocumentViewer />
                    </Col>
                </Row>
            </Container>
        );
  }
}
