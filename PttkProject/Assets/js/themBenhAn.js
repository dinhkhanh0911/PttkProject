$(document).ready(function () {
    handerchangeTypeRoom()
})
function handerchangeTypeRoom() {
    var loaiPhong = document.querySelector('#loaiPhong')
    loaiPhong.addEventListener('change', fillDataRoom)
}
function fillDataRoom() {
    var val = $(this).find('option:selected').val()
    $.ajax({
        url:'./getListRoom',
        type: 'post',
        datatype: 'json',
        data: {
            loaiPhongID:val
        },
        success: function (data) {
            if (data.code === 200) {
                fill(data.listRoom)
                
            }
        }
    })
}
function fill(data) {
    var phongBenh = document.querySelector('#phongBenh')
    phongBenh.innerHTML = ''
    for (var item of data) {
        var option = `
            <option value="${item.ID}">
                ${item.tenPhong}
            </option>
        `
        $('#phongBenh').append(option) 
    }
}