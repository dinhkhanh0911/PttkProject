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
                    $('#tbPhong').append(`
                            <tr id="${item.ID}">
                                <td>${item.tenPhong}</td>
                                <td>${item.soGiuongHienTai}</td>
                                <td>${item.soGiuongToiDa}</td>
                                <td>
                                    <a onclick="xem(${item.ID})" class="see" title="Xem" >
                                        <i class="fa fa-eye" aria-hidden="true"></i>
                                    </a>
                                    <a href="/phong-benh/cap-nhat-phong-benh/${item.ID}" class="edit" title="Sửa">
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
             <label class="modal-lable">Tên phòng:</label>
             <label class="modal-value">${data.tenPhong}</label></div>
             <div class="modal-group">
            <label class="modal-lable">số giường hiện tại:</label>
            <label class="modal-value">${data.soGiuongHienTai}</label></div>
            <div class="modal-group">
            <label class="modal-lable">Số giường tối đa:</label>
             <label class="modal-value">${data.soGiuongToiDa}</label>
             </div>`);

    $('#patient-modal').modal();
}
function xoa(id) {
    $.ajax({
        url: 'xoaPhong',
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