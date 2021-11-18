//datatable
var table;
$(document).ready(function () {

    table = $('#datatable').DataTable({
        "language": {
            "search": "Tìm kiếm",
            "lengthMenu": "Hiển thị _MENU_ bản ghi trên 1 trang",
            "zeroRecords": "Không tìm thấy dữ liệu",
            "info": "Hiển thị _PAGE_ trên _PAGES_",
            "infoEmpty": "Không có dữ liệu tương ứng",
            "infoFiltered": "(Tìm từ _MAX_ bản ghi)",
            "paginate": {
                "first": "Đầu",
                "last": "Cuối",
                "next": "Sau",
                "previous": "Trước"
            },
        }
    });
    var idBenhNhan;
    $('#datatable tbody').on('click', 'tr', function () {
        idBenhNhan = table.row(this).data()[0];
        console.log(table.row(this).data());
        //$.ajax({
        //    url: '@Url..Action("BenhNhan","layBenhNhan")',
        //    type: 'post',
        //    datatype: 'json',
        //    data: d,
        //    success: function (data) {
        //        if (data.code === 200) {
        //            fill(data.listRoom)
        //        }
        //    }
        //})
        $("#patien-modal-body").append("<h2>"+ idBenhNhan + "</h2>");
        $("#patient-modal").modal();
    });

});
$('form').submit(function (event) {
    $.ajax({
        method: $(this).attr('method'),
        url: $(this).attr('action'),
        data: $(this).serialize(),
        type: 'POST',
        error: function (xhr, ajaxOptions, thrownError) {
            console.log(xhr);
            console.log(ajaxOptions);
            console.log(thrownError);
        },

    }).done(function (response) {
        if (response.code == 200) {
            console.log(response.data);
            let data1 = response.data.map(obj => Object.values(obj));
            $("#datatable").DataTable().clear();
            $("#datatable").DataTable().rows.add(data1);
            $("#datatable").DataTable().draw();

        }
        else {
        }
    });
    event.preventDefault();
});
