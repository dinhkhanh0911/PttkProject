//datatable
var table;
$(document).ready(function () {

    table = $('#datatable').DataTable({
        "language": {
            "search": "Tìm kiếm",
            "lengthMenu": "Hiển thị _MENU_ bản ghi trên 1 trang",
            "zeroRecords": "Không tìm thấy dữ liệu",
            "info": "Hiển thị _PAGE_ trên _PAGES_",
            "infoEmpty": "Không có dữ liệu tương ứng",
            "infoFiltered": "(Tìm từ _MAX_ bản ghi)",
            "paginate": {
                "first": "Đầu",
                "last": "Cuối",
                "next": "Sau",
                "previous": "Trước"
            },
        }
    });
    var idBenhNhan;
    $('#datatable tbody').on('click', 'tr', function () {
        idBenhNhan = table.row(this).data()[0];
        console.log(table.row(this).data());
        //$.ajax({
        //    url: '@Url..Action("BenhNhan","layBenhNhan")',
        //    type: 'post',
        //    datatype: 'json',
        //    data: d,
        //    success: function (data) {
        //        if (data.code === 200) {
        //            fill(data.listRoom)
        //        }
        //    }
        //})
        $("#patien-modal-body").append("<h2>"+ idBenhNhan + "</h2>");
        $("#patient-modal").modal();
    });
    bieudotheongay()
    bieudotheodotuoi()
    bieudonamnu()

});
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
        },

    }).done(function (response) {
        if (response.code == 200) {
            console.log(response.data);
            let data1 = response.data.map(obj => Object.values(obj));
            $("#datatable").DataTable().clear();
            $("#datatable").DataTable().rows.add(data1);
            $("#datatable").DataTable().draw();

        }
        else {
        }
    });
    event.preventDefault();
});

function bieudotheongay() {
    const labels = [
        '15/11',
        '16/11',
        '17/11',
        '18/11',
        '19/11',
        '20/11',
    ];
    const data = {
        labels: labels,
        datasets: [{
            label: 'My First dataset',
            backgroundColor: '#17a2b8',
            borderColor: 'rgb(255, 99, 132)',
            data: [9128, 3812, 1939, 10905, 37735, 12012],
        }]
    };
    const config = {
        type: 'bar',
        data: data,
        options: {},

    };
    const myChart = new Chart(
        document.getElementById('bieudotheongay'),
        config
    );
};
function bieudotheodotuoi() {
    var xValues = ['<13', '13-17', '18-24', '25-34', '35-44', '45-54', '55-64', '>65'];
    var yValues = [7852, 16515, 35621, 21002, 5006, 2153, 4562, 32150];

    new Chart("bieudotheodotuoi", {
        type: "bar",
        data: {
            fill: false,
            lineTension: 0,
            labels: xValues,
            datasets: [{
                backgroundColor: '#17a2b8',
                borderColor: "rgba(0,0,255,0.1)",
                data: yValues
            }]
        },
        options: {
            legend: { display: false },
        }
    });
};
function bieudonamnu() {
    const labels = [
        'Nam',
        'Nữ',
    ];
    var barColors = ["17a2b8", "pink"];
    const data = {
        labels: labels,
        datasets: [{
            label: 'My First dataset',
            backgroundColor: barColors,
            borderColor: 'rgb(255, 99, 132)',
            data: [9128, 3812],
        }]
    };
    const config = {
        type: 'pie',
        data: data,
        options: {},

    };
    const myChart = new Chart(
        document.getElementById('bieudonamnu'),
        config
    );
};
