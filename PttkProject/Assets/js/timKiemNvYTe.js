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
                                <td>${item.namKinhNghiem}</td>
                                <td>${item.gioiTinh}</td>
                                <td>${item.viTriLamViec.tenViTri}</td>
                                
                                <td>
                                    <a onclick="xem(${item.ID})" class="see" title="Xem" >
                                        <i class="fa fa-eye" aria-hidden="true"></i>
                                    </a>
                                    <a href="/nhan-vien-y-te/cap-nhat-thong-tin-nhan-vien-y-te/${item.ID}" class="edit" title="Sửa">
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
             <label class="modal-value">${data.ten || "Không có"}</label></div>
             <div class="modal-group">
            <label class="modal-lable">Ngày sinh:</label>
            <label class="modal-value">${data.ngaySinh != null ? new Date(Number(data.ngaySinh.slice(6, data.ngaySinh.length - 2))).toLocaleDateString() : "Không có"}</label></div>
            <div class="modal-group">
            <label class="modal-lable">Giới tính:</label>
             <label class="modal-value">${data.gioiTinh || "Không có"}</label>
             </div>
            <div class="modal-group">
            <label class="modal-lable">Năm kinh nghiệm:</label>
            <label class="modal-value">${data.namKinhNghiem || "Không có"}</label>
            </div>
            <div class="modal-group">
            <label class="modal-lable">Số CCCD:</label>
            <label class="modal-value">${data.CMND || "Không có"}</label>
            </div>
            <div class="modal-group">
            <label class="modal-lable">Bằng cấp:</label>
            <label class="modal-value">${data.bangCap || "Không có"}</label>
            </div>
            
            <div class="modal-group">
            <label class="modal-lable">Địa chỉ:</label>
            <label class="modal-value">${data.xaID}</label>
            </div>
            <div class="modal-group">
            <label class="modal-lable">Vị trí làm việc:</label>
            <label class="modal-value">${data.viTriLamViec.tenViTri || "Không có"}</label>
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