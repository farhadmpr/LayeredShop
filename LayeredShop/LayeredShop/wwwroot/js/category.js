$(function () {
    loadDataTable()
});

function loadDataTable() {
    let dataTable = $('#tblData').DataTable({
        'ajax': {
            'url': '/admin/category/GetAll',
            'type': 'GET',
            'datatype': ' json'
        },
        'columns': [
            { 'data': 'name', 'width': '50%' },
            { 'data': 'displayOrder', 'width': '20%' },
            {
                'data': 'id',
                'render': function (data) {
                    return `<div class="text-center">
                                <a href="/admin/category/insert/${data}" class="btn btn-success">Edit</a> | 
                                <a onclick=delete("/admin/category/delete/${data}") class="btn btn-danger">Delete</a>
                            </div>`
                }, 'width': '30%'
            }

        ],
        "language": {
            "emptyTable": "No records found"
        },
        "width": "100%"
    })    
}