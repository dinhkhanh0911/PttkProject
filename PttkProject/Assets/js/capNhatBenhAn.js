$(document).ready(function () {
    load()
})
const saveData = (function () {
    var data = [];
    return {
        getData(id) {
            return data[id - 1]
        },
        setData(patientList) {
            data = [...patientList]
        }
    }
})()
function load() {
    var benhAnID = document.querySelector('#benhAnID').value
    console.log(benhAnID);
    $.ajax({
        type: 'post',
        url: './layDSThongTin',
        datatype: 'json',
        data: {
            benhAnID: benhAnID
        },
        success: function (data) {
            
            if (data.code === 200) {
                
                fillDataTTTV(data.thongTinTruyVets)
                fillDataTTDT(data.thongTinDieuTris)
                //saveData.setData(data.data)
                handerSeeClick()
                //handerDeleteClick()
            }
        }
    })
}
function fillDataTTTV(thongTinTruyVets) {
    thongTinTruyVets.sort(function (a, b) {
        var date1 = new Date(Number(a.thoiGian.slice(6, a.thoiGian.length - 2)))
        var date2 = new Date(Number(b.thoiGian.slice(6, b.thoiGian.length - 2)))
        return date1 - date2;
    })
    console.log(thongTinTruyVets)
    var tbodyPatient = document.querySelector('#tbodyThongTinTruyVet')
    tbodyPatient.innerHTML = ''
    var i = 1;
    for (var item of thongTinTruyVets) {
        
        var dateString = item.thoiGian
        var date = new Date(Number(dateString.slice(6, dateString.length - 2)))
        let row = `
            <tr id="${item.ID}">
                <td>${date.toLocaleDateString()}</td>
                <td>${(item.diaChiChiTiet ? item.diaChiChiTiet + " - " : "")}${item.xa} - ${item.huyen} - ${item.tinh}</td>
                
                <td data-value="${i}">
                    <a id="see-tttv-${i}" class="see-tttv" title="Settings" data-toggle="modal" data-target="#infor-modal">
                        <i class="fa fa-eye" aria-hidden="true"></i>
                    </a>
                    <a id="edit-tttv-${i}" class="edit-tttv" title="Settings">
                        <i class="fa fa-wrench" aria-hidden="true"></i>
                    </a>
                    <a id="delete-tttv-${i}" class="delete-tttv" title="Delete">
                        <i class="fa fa-trash-o" aria-hidden="true"></i>
                    </a>
                
                </td>
            </tr>`
        i++
        $('#tbodyThongTinTruyVet').append(row)
    }
}
function fillDataTTDT(thongTinDieuTris) {
    var tbodyPatient = document.querySelector('#tbodyThongTinDieuTri')
    tbodyPatient.innerHTML = ''
    var i = 1;
    for (var item of thongTinDieuTris) {
        
        var dateString = item.ngay
        var date = new Date(Number(dateString.slice(6, dateString.length - 2)))
        let row = `
            <tr id="${item.ID}">
                <td>${item.gioPhut || ""}</td>
                <td>${date.toLocaleDateString()}</td>
                <td>${item.tinhTrangBenh || ""}</td>
                <td>${item.yLenh || ""}</td>
                
                <td data-value="${i}">
                    <a id="see-ttdt-${i}" class="see-ttdt" title="Settings" data-toggle="modal" data-target="#patient-modal">
                        <i class="fa fa-eye" aria-hidden="true"></i>
                    </a>
                    <a id="edit-ttdt-${i}" class="edit-ttdt" title="Settings">
                        <i class="fa fa-wrench" aria-hidden="true"></i>
                    </a>
                    <a id="delete-ttdt-${i}" class="delete-ttdt" title="Delete">
                        <i class="fa fa-trash-o" aria-hidden="true"></i>
                    </a>
                
                </td>
            </tr>`
        i++
        $('#tbodyThongTinDieuTri').append(row)
    }
}
function handerSeeClick() {
    var seeElement = document.querySelectorAll('.see-tttv')
    for (var item of seeElement) {
        item.addEventListener('click', show)
    }
    var seeElement = document.querySelectorAll('.see-ttdt')
    for (var item of seeElement) {
        item.addEventListener('click', show)
    }
}
function show() {
    var element = document.querySelector(`#${this.id}`)
    var parent = element.parentElement
    var dataValue = parent.id
    var data = saveData.getData(dataValue)
    console.log(parent.attributes["data-value"].value)
    /*showModal(data)*/

}
function showModal(data) {
    var modal = document.querySelector('#patien-modal-body')
    var dateString = data.ngaySinh
    var date = new Date(Number(dateString.slice(6, dateString.length - 2)))
    modal.innerHTML = `
        <div class="modal-group">
            <label class="modal-lable ">Họ và tên:</label>
            <label class="modal-value">${data.ten || "Không có"}</label>
        </div>
        <div class="modal-group">
            <label class="modal-lable">Ngày sinh:</label>
            <label class="modal-value">${date.toLocaleDateString() || "Không có"}</label>
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
        //parent.remove()
    }
}
function themThongTinTruyVet() {
    var benhAnID = document.querySelector('#benhAnID').value;
    window.location.href = `./ThemThongTinTruyVet/${benhAnID}`
}
function themThongTinDieuTri() {
    var benhAnID = document.querySelector('#benhAnID').value;
    window.location.href = `./themThongTinDieuTri/${benhAnID}`
}