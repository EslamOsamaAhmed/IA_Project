$(document).ready(function () {
    $(".dash-page").click(function () {
        $(".dash-page").removeClass("active");
        $(this).addClass("active");

        if ($(this).hasClass("profile-tab")) {
            $(".tab-content").removeClass("active-content").addClass("noactive");
            $(".show-profile").addClass("active-content").removeClass("noactive")
        }

        if ($(this).hasClass("edit-rprofile-tab")) {
            $(".tab-content").removeClass("active-content").addClass("noactive");
            $(".edit-profile").addClass("active-content").removeClass("noactive")
        }

        if ($(this).hasClass("dashboard-tab")) {
            $(".tab-content").removeClass("active-content").addClass("noactive");
            $(".dahsboard-content").addClass("active-content").removeClass("noactive")
        }

        if ($(this).hasClass("curr-rpoject-tab")) {
            $(".tab-content").removeClass("active-content").addClass("noactive");
            $(".current-proj-content").addClass("active-content").removeClass("noactive")
        }

        if ($(this).hasClass("complete-project-tab")) {
            $(".tab-content").removeClass("active-content").addClass("noactive");
            $(".complete-proj-content").addClass("active-content").removeClass("noactive")
        }

        if ($(this).hasClass("assign-project-tab")) {
            $(".tab-content").removeClass("active-content").addClass("noactive");
            $(".assign-proj-content").addClass("active-content").removeClass("noactive")
        }

        if ($(this).hasClass("request-res-tab")) {
            $(".tab-content").removeClass("active-content").addClass("noactive");
            $(".request-response-content").addClass("active-content").removeClass("noactive")
        }

        if ($(this).hasClass("prev-del-project-tab")) {
            $(".tab-content").removeClass("active-content").addClass("noactive");
            $(".prev-proj-content").addClass("active-content").removeClass("noactive")
        }
    });

    $(".req-t").click(function () {
        $(".res-t").removeClass("active-t");
        $(this).addClass("active-t");
        $(".reqs").removeClass("noactive");
        $(".ress").addClass("noactive")
    });

    $(".res-t").click(function () {
        $(".req-t").removeClass("active-t");
        $(this).addClass("active-t");
        $(".ress").removeClass("noactive");
        $(".reqs").addClass("noactive")
    });
    // login and register
    $(".register-switch").click(function () {
        $(this).addClass("text-hide");
        $(".login-switch").removeClass("text-hide");

    });
    $(".login-switch").click(function () {
        $(this).addClass("text-hide");
        $(".register-switch").removeClass("text-hide");

    });

});

// Draw the chart and set the chart values
function drawChart() {
    var data = google.visualization.arrayToDataTable([
    ['Task', 'Hours per Day'],
    ['Completed', 8],
    ['Done', 2],
    ['Failed', 4],
    ['Delveired', 2],
    ]);

    var data_2 = google.visualization.arrayToDataTable([
          ['Projects', 'Status'],
          ['Completed', 12.2],
          ['Done', 9.1],
          ['Failed', 12.2],
          ['Delveired', 22.9],
       ]);

    var options = {
        title: 'Projects',
        legend: { position: 'none' },
        width: '800',
        height: '400'
    };

    var options = { 'title': 'Projects', 'width': 800, 'height': 400 };
    // Optional; add a title and set the width and height of the chart

    // Display the chart inside the <div> element with id="piechart"
    var chart = new google.visualization.PieChart(document.getElementById('piechart'));
    var chart_2 = new google.visualization.Histogram(document.getElementById('piechart-2'));

    chart.draw(data, options);
    chart_2.draw(data_2,options);
}

google.charts.load('current', { 'packages': ['corechart'] });
google.charts.setOnLoadCallback(drawChart);
