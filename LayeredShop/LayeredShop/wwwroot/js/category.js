let dataTable

$(function () {
    loadDataTable()
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
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
                                <a onclick=del("/admin/category/delete/${data}") class="btn btn-danger">Delete</a>
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

function del(url) {
    swal.fire({
        title: 'Are you sure you want to delete?',
        text: 'you will not be able to restore the content',
        icon: 'question',
        showCancelButton: true,
        confirmButtonColor: '#ff0000',
        confirmButtonText: 'Yes',
    }).then((result) => {
        if (result.value) {
            $.ajax({
                type: 'DELETE',
                url: url,
                success: function (data) {
                    if (data.success) {
                        Swal.mixin({
                            toast: true,
                            position: 'top-end',
                        }).fire({
                            icon: 'success',
                            title: data.message
                        })
                        dataTable.ajax.reload();
                    }
                    else {
                        Swal.mixin({
                            toast: true,
                            position: 'top-end',
                        }).fire({
                            icon: 'warning',
                            title: data.message
                        })
                    }
                }
            })
        }
    })
}

