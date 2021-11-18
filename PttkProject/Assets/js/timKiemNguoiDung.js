var dspb = [];
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
        }
    }).done(function (response) {
        if (response.code == 200) {
            if (response.data.length == 0) {
                $('#patient-modal-body').empty();
                $('#patient-modal-body').text("Không có dữ liệu");
                $('#patient-modal').modal();
            }
            else {
                $('#tbodyUser').empty();
                for (let item of response.data) {
                    dspb.push(item);
                    $('#tbodyUser').append(`
                            <tr id="${item.ID}">
                                <td>${item.ten}</td>
                                <td>${item.ngaySinh != null ? new Date(Number(item.ngaySinh.slice(6, item.ngaySinh.length - 2))).toLocaleDateString() : "Không có"}</td>
                                <td>${item.CMND}</td>
                                <td>${item.gioiTinh}</td>
                                <td>
                                    <a onclick="xem(${item.ID})" class="see" title="Xem" >
                                        <i class="fa fa-eye" aria-hidden="true"></i>
                                    </a>
                                    <a href="/nguoi-dung/cap-nhat-tt-nguoi-dung/${item.ID}" class="edit" title="Sửa">
                                        <i class="fa fa-wrench" aria-hidden="true"></i>
                                    </a>
                                    <a onclick="xoa(${item.ID})" class="delete" title="Xóa">
                                        <i class="fa fa-trash-o" aria-hidden="true"></i>
                                    </a>

                                </td>
                            </tr>`);
                }
            }

        }
        else {
            $('#patient-modal-body').empty();
            $('#patient-modal-body').text(response.mgs);
            $('#patient-modal').modal();
        }
    });
    event.preventDefault();
});
function xem(id) {
    let data;
    for (let s of dspb) {
        if (s.ID == id) data = s;
    }
    $('#patient-modal-body').empty();
    $('#patient-modal-body').append(`<div class="modal-group">
             <label class="modal-lable">Họ và tên:</label>
             <label class="modal-value">${data.ten}</label></div>
             <div class="modal-group">
            <label class="modal-lable">Ngày sinh:</label>
            <label class="modal-value">${data.ngaySinh != null ? new Date(Number(data.ngaySinh.slice(6, data.ngaySinh.length - 2))).toLocaleDateString() : "Không có"}</label></div>
            <div class="modal-group">
            <label class="modal-lable">Giới tính:</label>
             <label class="modal-value">${data.gioiTinh}</label>
             </div>
            <div class="modal-group">
            <label class="modal-lable">Số CCCD:</label>
            <label class="modal-value">${data.CMND}</label>
            </div>
            <div class="modal-group">
            <label class="modal-lable">Địa chỉ:</label>
            <label class="modal-value">${data.diaChiChiTiet+data.xa.tenXa+data.xa.huyen.tenHuyen+data.xa.huyen.tinh.tenTinh}label>
            </div>
            <div class="modal-group">
            <label class="modal-lable">Vị trí làm việc:</label>
            <label class="modal-value">${data.viTriLamViec.tenViTri}</label>
            </div>
            
            <div class="modal-group">
            <label class="modal-lable">Số điện thoại:</label>
            <label class="modal-value">${data.sdt}</label>
            </div>`);

    $('#patient-modal').modal();
}
function xoa(id) {
    $.ajax({
        url: 'xoaNguoiDung',
        dataType: 'json',
        data: {
            ID: id
        },
        type: 'POST',
        error: function (xhr, ajaxOptions, thrownError) {
            console.log(xhr);
            console.log(ajaxOptions);
            console.log(thrownError);
        },
        success: function (res) {
            $('#patient-modal-body').empty();
            $('#patient-modal-body').text(res.mgs);
            $('#patient-modal').modal();
        }
    });
    event.preventDefault();

}