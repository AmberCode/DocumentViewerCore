import React, { Component } from 'react';

export default class Search extends Component {
    constructor(props) {
        super(props);
        this.state = {
            docDate: '',
            docName: '',
            docNumber: ''
        };

        this.handleInputChange = this.handleInputChange.bind(this);
        this.search = this.search.bind(this);
    };

    handleInputChange(event) {
        const { target: { name, value } } = event         
        this.setState({ [name]: value });
    }

    search() {
        this.props.search(this.state);
    }

    render() {
        return (<div>
            <div className="form-row align-items-center">
                <div className="col-auto">
                    <input type="date" id="searchDate" name="docDate" value={this.state.date} onChange={this.handleInputChange} />
                </div>
                <div className="col-auto">
                    <input type="text" className="form-control" id="searchDocName"
                        name="docName" placeholder="Document Name" value={this.state.docName} onChange={this.handleInputChange} />                   
                </div>
                <div className="col-auto">
                    <input type="number" className="form-control" id="searchDocNumber"
                        name="docNumber" placeholder="Document Number" value={this.state.docNumber} onChange={this.handleInputChange} />
                </div>
                <div className="col-auto">
                    <button type="button" className="btn btn-primary" onClick={this.search}>Search</button>
                </div>
            </div>
        </div>
        )
    }
};
