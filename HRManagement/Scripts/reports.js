$(function () {
    $.ajax({
        url: "/api/reports/population",
        method: "GET"
    }).success(function (data) {

        for (var i = 1; i <= 2; i++) {
            $('#chart' + i).highcharts({
                chart: {
                    type: 'column'
                },
                title: {
                    text: 'Monthly Average Rainfall'
                },
                subtitle: {
                    text: 'Source: WorldClimate.com'
                },
                xAxis: {
                    categories: [
                        'Jan',
                        'Feb',
                        'Mar',
                        'Apr',
                        'May',
                        'Jun',
                        'Jul',
                        'Aug',
                        'Sep',
                        'Oct',
                        'Nov',
                        'Dec'
                    ],
                    crosshair: true
                },
                yAxis: {
                    min: 0,
                    title: {
                        text: 'Rainfall (mm)'
                    }
                },
                tooltip: {
                    headerFormat: '<span style="font-size:10px">{point.key}</span><table>',
                    pointFormat: '<tr><td style="color:{series.color};padding:0">{series.name}: </td>' +
                        '<td style="padding:0"><b>{point.y:.1f} mm</b></td></tr>',
                    footerFormat: '</table>',
                    shared: true,
                    useHTML: true
                },
                plotOptions: {
                    column: {
                        pointPadding: 0.2,
                        borderWidth: 0
                    }
                }
            });
            for (var item = 0 ; item< data.length;item++) {
                $('#chart' + i).highcharts().addSeries({ name: data[item].ExperienceLevel, data: data[item].EmploymentsPerMonth }, false);
            }
            $('#chart' + i).highcharts().redraw();
        }

    });

    $.ajax({
        url: "/api/reports/population2",
        method: "GET"
    }).success(function (data) {
            $('#chart3').highcharts({
                chart: {
                    plotBackgroundColor: null,
                    plotBorderWidth: null,
                    plotShadow: false,
                    type: 'pie'
                },
                title: {
                    text: 'Employees grouped by age'
                },
                tooltip: {
                    pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
                },
                plotOptions: {
                    pie: {
                        allowPointSelect: true,
                        cursor: 'pointer',
                        dataLabels: {
                            enabled: true,
                            format: '<b>{point.name}</b>: {point.percentage:.1f} %',
                            style: {
                                color: (Highcharts.theme && Highcharts.theme.contrastTextColor) || 'black'
                            }
                        }
                    }
                },

            });

            var formattedDate = [];

            for (var item = 0 ; item < data.length; item++) {
                formattedDate.push({ name: data[item].Description, y: data[item].Values });
            }

            $('#chart3').highcharts().addSeries({ name: "Age", colorByPoint: true , data : formattedDate});

            $('#chart3').highcharts().redraw();  
        
    });

    $.ajax({
        url: "/api/reports/population3",
        method: "GET"
    }).success(function (data) {
        $('#chart4').highcharts({
            chart: {
                plotBackgroundColor: null,
                plotBorderWidth: null,
                plotShadow: false,
                type: 'pie'
            },
            title: {
                text: 'Employees grouped by salary'
            },
            tooltip: {
                pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
            },
            plotOptions: {
                pie: {
                    allowPointSelect: true,
                    cursor: 'pointer',
                    dataLabels: {
                        enabled: true,
                        format: '<b>{point.name}</b>: {point.percentage:.1f} %',
                        style: {
                            color: (Highcharts.theme && Highcharts.theme.contrastTextColor) || 'black'
                        }
                    }
                }
            },

        });

        var formattedDate = [];

        for (var item = 0 ; item < data.length; item++) {
            formattedDate.push({ name: data[item].Description, y: data[item].Values });
        }

        $('#chart4').highcharts().addSeries({ name: "Salary", colorByPoint: true, data: formattedDate });

        $('#chart4').highcharts().redraw();

    });

    $.ajax({
        url: "/api/reports/population5",
        method: "GET"
    }).success(function (data) {
        $('#chart5').highcharts({
            chart: {
                plotBackgroundColor: null,
                plotBorderWidth: null,
                plotShadow: false,
                type: 'pie'
            },
            title: {
                text: 'Employees grouped by employment date'
            },
            tooltip: {
                pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
            },
            plotOptions: {
                pie: {
                    allowPointSelect: true,
                    cursor: 'pointer',
                    dataLabels: {
                        enabled: true,
                        format: '<b>{point.name}</b>: {point.percentage:.1f} %',
                        style: {
                            color: (Highcharts.theme && Highcharts.theme.contrastTextColor) || 'black'
                        }
                    }
                }
            },

        });

        var formattedDate = [];

        for (var item = 0 ; item < data.length; item++) {
            formattedDate.push({ name: data[item].Description, y: data[item].Values });
        }

        $('#chart5').highcharts().addSeries({ name: "Employment date", colorByPoint: true, data: formattedDate });

        $('#chart5').highcharts().redraw();

    });

});