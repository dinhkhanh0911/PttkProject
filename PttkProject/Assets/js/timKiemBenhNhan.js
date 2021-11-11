

$(document).ready(function () {
    handerSearchClick()
})
function handerSearchClick() {
    var searchBtn = document.querySelector('#searchBtn')
    searchBtn.addEventListener('click', timKiem)
}
const saveData = (function () {
    var data = [];
    return {
        getData(id) {
            return data[id-1]
        },
        setData(patientList) {
            data = [...patientList]
        }
    }
})()
function timKiem() {
    var searchInput = document.querySelector('#searchInput')
    var input = searchInput.value
    $.ajax({
        type: 'post',
        url: '/benh-nhan/lay-danh-sach-benh-nhan',
        datatype: 'json',
        data: {
            input:input,
        },
        success: function (data) {
            console.log(data)
            if (data.code === 200) {
                dienDanhSachBenhNhan(data)
                saveData.setData(data.data)
                handerSeeClick()
                handerDeleteClick()
                handerEditClick()
            }
        }
    })
}
function dienDanhSachBenhNhan(data) {
    var tbodyPatient = document.querySelector('#tbodyPatient')
    tbodyPatient.innerHTML=''
    var i = 1;
    for (var item of data.data) {
        var dateString = item.ngaySinh
        var date;
        if (dateString) {
            date = new Date(Number(dateString.slice(6, dateString.length - 2)))
        }
        
        let row = `
            <tr id="${item.ID}">
                <td>${item.ten}</td>
                <td>${dateString != null ? date.toLocaleDateString() : "Không có"}</td>
                <td>${item.CMND}</td>
                <td>${item.gioiTinh}</td>
                
                <td id="${i}">
                    <a id="see-${i}" class="see" title="Xem" data-toggle="modal" data-target="#patient-modal">
                        <i class="fa fa-eye" aria-hidden="true"></i>
                    </a>
                    <a id="edit-${i}" class="edit" title="Sửa">
                        <i class="fa fa-wrench" aria-hidden="true"></i>
                    </a>
                    <a id="delete-${i}" class="delete" title="Xóa">
                        <i class="fa fa-trash-o" aria-hidden="true"></i>
                    </a>
                
                </td>
            </tr>`
        i++
        $('#tbodyPatient').append(row)
    }
}

function handerSeeClick() {
    var seeElement = document.querySelectorAll('.see')
    for (var item of seeElement) {
        item.addEventListener('click', hienThiBenhNhan)
    }
}
function hienThiBenhNhan() {
    var element = document.querySelector(`#${this.id}`)
    var parent = element.parentElement
    var id = parent.id
    var data = saveData.getData(id)
    hienThiModal(data)
}
function hienThiModal(data) {
    var modal = document.querySelector('#patien-modal-body')
    console.log(data.ngaySinh)
    var dateString = data.ngaySinh
    var date;
    if (dateString != null) {
        date = new Date(Number(dateString.slice(6, dateString.length - 2)))
    }
    modal.innerHTML = `
        <div class="modal-group">
            <label class="modal-lable ">Họ và tên:</label>
            <label class="modal-value">${data.ten || "Không có"}</label>
        </div>
        <div class="modal-group">
            <label class="modal-lable">Ngày sinh:</label>
            <label class="modal-value">${date != null ? date.toLocaleDateString() : "Không có"}</label>
        </div>
        <div class="modal-group">
            <label class="modal-lable">Giới tính:</label>
            <label class="modal-value">${data.gioiTinh || "Không có"}</label>
        </div>
        <div class="modal-group">
            <label class="modal-lable">Số CCCD:</label>
            <label class="modal-value">${data.CMND || "Không có"}</label>
        </div>
        <div class="modal-group">
            <label class="modal-lable">Địa chỉ:</label>
            <label class="modal-value">${data.diaChiID || "Không có"}</label>
        </div>
        <div class="modal-group">
            <label class="modal-lable">Số điện thoại:</label>
            <label class="modal-value">${data.sdtBenhNhan || "Không có"}</label>
        </div>
        <div class="modal-group">
            <label class="modal-lable">Mã BHYT:</label>
            <label class="modal-value">${data.maBHYT || "Không có"}</label>
        </div>
        <div class="modal-group">
            <label class="modal-lable">Đối tượng cách ly:</label>
            <label class="modal-value">${data.doiTuongCachLy || "Không có"}</label>
        </div>
        <div class="modal-group">
            <label class="modal-lable">Người thân:</label>
            <label class="modal-value">${data.tenNguoiThan || "Không có"}</label>
        </div>
        <div class="modal-group">
            <label class="modal-lable">Số điện thoại người thân:</label>
            <label class="modal-value">${data.sdtNguoiThan || "Không có"}</label>
        </div>
    `
    
}

function handerDeleteClick() {
    var deleteElement = document.querySelectorAll('.delete')
    console.log(deleteElement)
    for (var item of deleteElement) {
        item.addEventListener('click', confirmDelete)
    }
}
function confirmDelete() {
    if (confirm("Bạn có thực sự muốn xóa không?")) {
        var element = document.querySelector(`#${this.id}`)
        var parent = element.parentElement.parentElement
        console.log(parent.id)
        xoaBenhNhan(parent)
    }
}
function xoaBenhNhan(element) {
    var ID = element.id
    $.ajax({
        url: '/benh-nhan/xoa-benh-nhan',
        type: 'post',
        dataType: 'json',
        data: {
            ID: ID
        },
        success: function (data) {
            if (data.code == 200) {
                element.remove()
            }
            alert(data.msg)
        }
    })
}
function handerEditClick() {
    var editElement = document.querySelectorAll('.edit')
    console.log(editElement)
    for (var item of editElement) {
        item.addEventListener('click', editPatient)
    }
}
function editPatient() {
    var element = document.querySelector(`#${this.id}`)
    var parent = element.parentElement.parentElement
    console.log(parent.id)
    window.location.href = `/benh-nhan/cap-nhat-thong-tin-benh-nhan/${parent.id}`
}