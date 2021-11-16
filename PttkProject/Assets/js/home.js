
$(document).ready(function(){
    taiDuLieuMucDoTangTruong()
    taiDuLieuBieuDo2()
    taiDuLieuBieuDo3()
})
function taiDuLieuMucDoTangTruong(){
        var xValues = [50,60,70,80,90,100,110,120,130,140,150];
    var yValues = [7,8,8,9,9,9,10,11,14,14,15];

    new Chart("bieu_do_tang_truong", {
        type: "line",
        data: {
            labels: xValues,
        datasets: [{
            fill: false,
        lineTension: 0,
        backgroundColor: "rgba(0,0,255,1.0)",
        borderColor: "rgba(0,0,255,0.1)",
        data: yValues
                    }]
                },
        options: {
            legend: {display: false},
        scales: {
            yAxes: [{ticks: {min: 6, max:16}}],
            }
        }
    });
}
function taiDuLieuBieuDo2(){
    var xValues = ["Ca đang nhiễm bệnh", "Ca khỏi bệnh", "Ca tử vong"];
    var barColors = [
        "#b91d47",
        "#00aba9",
        "#2b5797"
    ];
    (function () {
        $.ajax({
            type: 'get',
            datatype: 'json',
            url: '/trang-chu/lay-du-lieu-bieu-do-tron',
            success: function (data) {
                if (data.code === 200) {
                    const yValues = [...data.list];
                    new Chart("myChart", {
                        type: "pie",
                        data: {
                            labels: xValues,
                            datasets: [
                                {
                                    backgroundColor: barColors,
                                    data: yValues
                                }
                            ]
                        },
                        options: {
                            plugins: {
                                legend: {
                                    labels: {
                                        // This more specific font property overrides the global property
                                        font: {
                                            size: 30
                                        }
                                    }
                                }
                            }
                        }
                    });
                }
            }

        })
    }())
}
function taiDuLieuBieuDo3(){
    var xValues = ["Italy", "France", "Spain", "USA", "Argentina"];
    var yValues = [55, 49, 44, 24, 15];
    var barColors = ["red", "green","blue","orange","brown"];

    new Chart("iChart", {
        type: "bar",
        data: {
            labels: xValues,
            datasets: [{
                backgroundColor: barColors,
                data: yValues
            }]
        },
    options: {
        indexAxis: 'y',
    legend: {display: false},
    title: {
        display: true,
    text: "World Wine Production 2018"
            }
        }
    });
}
