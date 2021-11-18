$(document).ready(function () {
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
