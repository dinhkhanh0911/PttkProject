
$(document).ready(function () {
    handerSearchClick()
})
function handerSearchClick() {
    var searchBtn = document.querySelector('#searchBtn')
    searchBtn.addEventListener('click', search)
}
function search() {
    var searchInput = document.querySelector('#searchInput')
    var input = searchInput.value
    $.ajax({
        type: 'post',
        url: './getPatientList',
        datatype: 'json',
        data: {
            input:input,
        },
        success: function (data) {
            console.log(data);
        }
    })
}