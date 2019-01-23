/**
 * Get document by ID
 * @param {number} id Document system ID
 * @returns {object} Document
 */
export async function getDocument(id) {
    return await (await (fetch(`api/document/document?id=${id}`)
        .then(response => {
            if (!response.ok) {
                throw Error('System error');
            }

            return response.json();
        })
        .catch(err => {
            throw err;
        })
    ))
}
/**
 * Get all documents
 * @returns {array} Array of documents
 */
export async function getDocuments() {
    return await (await (fetch(`api/document/getall`)
        .then(response => {
            if (!response.ok) {
                throw Error('System error');
            }

            return response.json();
        })
        .catch(err => {
            throw err;
        })
    ))
}

/**
 * Search document by search criteria
 * @param {object} data Search criteria
 * @returns {object} Document
 */
export async function searchDocument(data) {
    return await (await (fetch(`api/document/searchdocuments`,
            {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(
                    {
                        DocDate: data.docDate,
                        DocName: data.docName,
                        DocNumber: data.docNumber
                    })
            }
        ).then(response => {
            if (!response.ok) {
                throw Error('System error');
            }

            return response.json();
        })
        .catch(err => {
            throw err;
        })
    ))
}

/**
 * Display document in docuvieware
 * @param {object} data File object
 */
export function displayDocument(data) {
        window.DocuViewareAPI.LoadFromByteArray("DocuVieware1", new Buffer(data.file, 'base64'), null, data.fileName,
        () => { }, () => { }
    );
}
