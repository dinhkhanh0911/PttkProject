$(document).ready(function () {
    load()
})
const DSThongTinTruyVet = (function () {
    var data = [];
    return {
        getData(id) {
            return data[id - 1]
        },
        setData(thongTinTruyVets) {
            data = [...thongTinTruyVets]
        }
    }
})()
const DSThongTinDieuTri = (function () {
    var data = [];
    return {
        getData(id) {
            return data[id - 1]
        },
        setData(thongTinDieuTris) {
            data = [...thongTinDieuTris]
        }
    }
})()
function load() {
    var benhAnID = document.querySelector('#ID').value;
    console.log(benhAnID);
    $.ajax({
        type: 'post',
        url: '/benh-nhan/lay-danh-sach-thong-tin',
        datatype: 'json',
        data: {
            benhAnID: benhAnID
        },
        success: function (data) {
            
            if (data.code === 200) {
                
                fillDataTTTV(data.thongTinTruyVets)
                fillDataTTDT(data.thongTinDieuTris)
                
                DSThongTinTruyVet.setData(data.thongTinTruyVets)
                DSThongTinDieuTri.setData(data.thongTinDieuTris)
                handerSeeClick()
                handerDeleteClick()
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
    var tbodyPatient = document.querySelector('#tbodyThongTinTruyVet')
    tbodyPatient.innerHTML = ''
    var i = 1;
    for (var item of thongTinTruyVets) {
        
        var dateString = item.thoiGian
        var date = new Date(Number(dateString.slice(6, dateString.length - 2)))
        let row = `
            <tr data-value="${item.ID}">
                <td>${date.toLocaleDateString()}</td>
                <td>${(item.diaChiChiTiet ? item.diaChiChiTiet + " - " : "")}${item.xa} - ${item.huyen} - ${item.tinh}</td>
                
                <td data-value="${i}" class="tttv">
                    <a id="see-tttv-${i}" class="see-tttv" title="Xem" data-toggle="modal" data-target="#infor-modal">
                        <i class="fa fa-eye" aria-hidden="true"></i>
                    </a>
                    <a id="delete-tttv-${i}" class="delete-tttv" title="Xóa">
                        <i class="fa fa-trash-o" aria-hidden="true"></i>
                    </a>
                
                </td>
            </tr>`
        i++
        $('#tbodyThongTinTruyVet').append(row)
    }
}
function fillDataTTDT(thongTinDieuTris) {
    thongTinDieuTris.sort(function (a, b) {
        var date1 = new Date(Number(a.ngay.slice(6, a.ngay.length - 2)))
        var date2 = new Date(Number(b.ngay.slice(6, b.ngay.length - 2)))
        return date1 - date2;
    })
    var tbodyPatient = document.querySelector('#tbodyThongTinDieuTri')
    tbodyPatient.innerHTML = ''
    var i = 1;
    for (var item of thongTinDieuTris) {
        
        var dateString = item.ngay
        var date = new Date(Number(dateString.slice(6, dateString.length - 2)))
        let row = `
            <tr data-value="${item.ID}">
                <td>${item.gioPhut || ""}</td>
                <td>${date.toLocaleDateString()}</td>
                <td>${item.tinhTrangBenh || ""}</td>
                <td>${item.yLenh || ""}</td>
                
                <td data-value="${i}" class="ttdt">
                    <a id="see-ttdt-${i}" class="see-ttdt" title="Xem" data-toggle="modal" data-target="#infor-modal">
                        <i class="fa fa-eye" aria-hidden="true"></i>
                    </a>
                    
                    <a id="delete-ttdt-${i}" class="delete-ttdt" title="Xóa">
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
    var dataValue = parent.attributes["data-value"].value
    var data;
    if (parent.className === "ttdt") {
        data = DSThongTinDieuTri.getData(dataValue)
        
        showModalTTDT(data)
    }
    else {
        data = DSThongTinTruyVet.getData(dataValue)
        
        showModalTTTV(data)
    }
    
    

}
function showModalTTDT(data) {
    var modalTitle = document.querySelector('#infor-modal-tittle')
    modalTitle.textContent= "Thông tin điều trị"
    var modal = document.querySelector('#infor-modal-body')
    var dateString = data.ngay
    var date = new Date(Number(dateString.slice(6, dateString.length - 2)))
    modal.innerHTML = `
        <div class="modal-group">
            <label class="modal-lable ">Giờ phút:</label>
            <label class="modal-value">${data.gioPhut || "Không có"}</label>
        </div>
        <div class="modal-group">
            <label class="modal-lable">Ngày:</label>
            <label class="modal-value">${date.toLocaleDateString() || "Không có"}</label>
        </div>
        <div class="modal-group">
            <label class="modal-lable">Tình trạng bệnh:</label>
            <label class="modal-value">${data.tinhTrangBenh || "Không có"}</label>
        </div>
        <div class="modal-group">
            <label class="modal-lable">Y lệnh:</label>
            <label class="modal-value">${data.yLenh || "Không có"}</label>
        </div>
    `

}
function showModalTTTV(data) {
    var modalTitle = document.querySelector('#infor-modal-tittle')
    modalTitle.textContent = "Thông tin truy vết"
    var modal = document.querySelector('#infor-modal-body')
    var dateString = data.thoiGian
    var date = new Date(Number(dateString.slice(6, dateString.length - 2)))
    modal.innerHTML = `
        <div class="modal-group">
            <label class="modal-lable ">Thời gian:</label>
            <label class="modal-value">${date.toLocaleDateString() || "Không có"}</label>
        </div>
        <div class="modal-group">
            <label class="modal-lable">Địa chỉ:</label>
            <label class="modal-value">${data.diaChiChiTiet || "Không có"}</label>
        </div>
        <div class="modal-group">
            <label class="modal-lable">Xã:</label>
            <label class="modal-value">${data.xa || "Không có"}</label>
        </div>
        <div class="modal-group">
            <label class="modal-lable">Huyện:</label>
            <label class="modal-value">${data.huyen || "Không có"}</label>
        </div>
        <div class="modal-group">
            <label class="modal-lable">Tỉnh:</label>
            <label class="modal-value">${data.tinh || "Không có"}</label>
        </div>
    `

}

function handerDeleteClick() {
    var seeElement = document.querySelectorAll('.delete-tttv')
    for (var item of seeElement) {
        item.addEventListener('click', confirmDelete)
    }
    var seeElement = document.querySelectorAll('.delete-ttdt')
    for (var item of seeElement) {
        item.addEventListener('click', confirmDelete)
    }
}
function confirmDelete() {
    if (confirm("Bạn có thực sự muốn xóa không?")) {
        var element = document.querySelector(`#${this.id}`)
        var parent = element.parentElement.parentElement
        if (element.className === "delete-tttv") {
            deleteTTTV(parent)
        }
        else {
            deleteTTDT(parent)
        }
    }
}
function deleteTTTV(element) {
    var ID = element.attributes["data-value"].value
    $.ajax({
        url: '/benh-nhan/xoa-thong-tin-truy-vet',
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
function deleteTTDT(element) {
    var ID = element.attributes["data-value"].value
    $.ajax({
        url: '/benh-nhan/xoa-thong-tin-dieu-tri',
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
function themThongTinTruyVet() {
    var benhAnID = document.querySelector('#ID').value;
    console.log(benhAnID)
    window.location.href = `/benh-nhan/them-thong-tin-truy-vet/${benhAnID}`
}
function themThongTinDieuTri() {
    var benhAnID = document.querySelector('#ID').value;
    window.location.href = `/benh-nhan/them-thong-tin-dieu-tri/${benhAnID}`
}
function xuatTTTruyVet(id) {

    window.location = "/XuatDuLieu/xuatTTTruyVet/" + id;
}
function xuatTTDieuTri(id) {
    window.location = "/XuatDuLieu/XuatTTTDieuTri/" + id;
}
function xuatbenhan(id) {
    window.location = "/XuatDuLieu/xuatThongTinBenhAn" + id;
}
