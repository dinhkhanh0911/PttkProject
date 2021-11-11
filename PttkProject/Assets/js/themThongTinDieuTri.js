$(document).ready(function () {
    
})

;(function () {

    $('#themThongTinDieuTri').submit(function (even) {


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

}())
