
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
        idBenhNhan = table.row(this).data();
        console.log(table.row(this).data());
        $("#patien-modal-body").empty();
        $("#patien-modal-body").append(
            `<div class="modal-group">
             <label class="modal-lable">Họ và tên:</label>
             <label class="modal-value">${table.row(this).data()[1]}</label></div>
             <div class="modal-group">
            <label class="modal-lable">Ngày sinh:</label>
            <label class="modal-value">${table.row(this).data()[2]}</label></div>
            <div class="modal-group">
            <label class="modal-lable">Số CMND:</label>
            <label class="modal-value">${table.row(this).data()[3]}</label>
            </div>
            <div class="modal-group">
            <label class="modal-lable">Số điện thoại:</label>
            <label class="modal-value">${table.row(this).data()[4]}</label>
            </div>
            <div class="modal-group">
            <label class="modal-lable">Ngày nhiễm bệnh:</label>
             <label class="modal-value">${table.row(this).data()[5]}</label>
             </div>
            <div class="modal-group">
            <label class="modal-lable">Phòng bệnh:</label>
            <label class="modal-value">${table.row(this).data()[6]}</label>
            </div>
            <div class="modal-group">
            <label class="modal-lable">Trạng thái hiện tại:</label>
            <label class="modal-value">${table.row(this).data()[7]}</label>
            </div>         
            
            </div>`);
        $("#patient-modal").modal();
    });
});