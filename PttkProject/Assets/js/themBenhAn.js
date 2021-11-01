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
(function () {

    $('#importMedicalRecord').submit(function (even) {
        

        $.ajax({
            method: $(this).attr('method'),
            url: $(this).attr('action'),
            data: $(this).serialize(),
            datatype: 'json',
            type: 'GET',
            error: function (xhr, ajaxOptions, thrownError) {
                console.log(xhr);
                console.log(ajaxOptions);
                console.log(thrownError);
            }
        }).done(function (response) {
            
            if (response != null) {
                alert(response.msg)
                console.log(response.model)
                
            }
        });
        even.preventDefault();
    })

})()
