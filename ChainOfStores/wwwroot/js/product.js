var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/admin/employee/getall' },

        "columns": [
            { data: 'firstName', "width": "9%" },
            { data: 'lastName', "width": "9%" },
            { data: 'phoneNumber', "width": "9%" },
            { data: 'dateOfEmployment', "width": "9%" },
            { data: 'shopId', "width": "8%" },
            { data: 'storageId', "width": "8%" },
            { data: 'bakeryId', "width": "8%" },
            { data: 'salaryId', "width": "9%" },
            { data: 'role.name', "width": "9%" },
            {
                data: 'id',
                "render": function (data) {
                    return `<div class="w-75 btn-group" role="group">
                    <a href = "/admin/employee/upsert?id=${data}" class="btn btn-primary mx-2" > <i class="bi bi-pencil-square"></i>Edit</a >   
                    <a onClick=Delete('/admin/employee/delete/${data}') class="btn btn-danger mx-2"><i class="bi bi-trash-fill"></i>Delete</a>
                    </div > `
                },
                "width": "22%"
            }
        ]
    });
}

function Delete(url) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    dataTable.ajax.reload();
                    toastr.success(data.message);
                }
            })
        }
    })
}
