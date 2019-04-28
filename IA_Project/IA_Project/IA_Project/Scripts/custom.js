$(document).ready(function () {
    $("#eminvalid").fadeOut();
    $("#passinvalid").fadeOut();
    var check = 0;

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

    $(".req-t ").click(function () {
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

    $(".users-t ").click(function () {
        $(".project-t").removeClass("active-t");
        $(this).addClass("active-t");
        $(".display_users").removeClass("noactive");
        $(".display_projects").addClass("noactive")
    });
        
    $(".project-t").click(function () {
        $(".users-t").removeClass("active-t");
        $(this).addClass("active-t");
        $(".display_projects").removeClass("noactive");
        $(".display_users").addClass("noactive")
    });

    $(".add-t ").click(function () {
        $(".delete-t").removeClass("active-t");
        $(this).addClass("active-t");
        $(".add-user").removeClass("noactive");
        $(".delet-user").addClass("noactive")
    });

    $(".delete-t").click(function () {
        $(".add-t").removeClass("active-t");
        $(this).addClass("active-t");
        $(".delet-user").removeClass("noactive");
        $(".add-user").addClass("noactive")
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

    /*
    $("#submit").click(function () {
        if ($("#register-form").valid()) {
            myData = $("#register-form").serialize();

            $.ajax({
                type: "POST",
                url: "/Home/Register",
                data: myData,
                success: function (response) {
                    alert("Inserted Successfully . . ");
                }
            })
        }
    });*/

    $("#Add_project_button").click(function () {

        var my_data = $("#Add_Project_form").serialize();
        $.ajax({
            type: "POST",
            url: "/Home/Index",
            data: my_data,
            success: function (response) {
                $("#project_name").val("");
                $("#des_project").val("");
                $("#p_status").removeAttr('checked');
                $("#start_time").val("");
                $("#end_time").val("");
                $("#price").val("");
            }
        })
        if ($("#Add_Project_form").valid()) {
            var my_data = $("#Add_Project_form").serialize();
            $.ajax({
                type: "POST",
                url: "/Home/Index",
                data: my_data,
                success: function (response) {
                    $("#confirm_message").modal('show');
                    $("#project_name").val("");
                    $("#des_project").val("");
                    $("#p_status").removeAttr('checked');
                    $("#start_time").val("");
                    $("#end_time").val("");
                    $("#price").val("");
                }
            })
        }
    })

    $("#emailValid").hide();
    $("#passValid").hide();

    $("#login").click(function () {
        var data = $("#loginForm").serialize();
        $.ajax({
            type: "post",
            url: "/Home/Login",
            data: data,
            success: function (result) {
                if (result == "notexist") {
                    $("#login-name").css({
                        borderColor: "rgb(229, 145, 148)",
                        boxShadow: "0 0 0 0.2rem rgb(229, 145, 148)",
                    })
                    $("#eminvalid").fadeIn();
                }
                else if (result == "wrongpass") {
                    $("#login-pass").css({
                        borderColor: "rgb(229, 145, 148)",
                        boxShadow: "0 0 0 0.2rem rgb(229, 145, 148)",
                    })
                    $("#eminvalid").fadeIn();
                }
                else {
                    window.location.href = "/Home/index";
                    $("#login-name").css({
                        borderColor: "#80bdff",
                        boxShadow: "0 0 0 0.2rem #80bdff",
                    })

                    $("#login-pass").css({
                        borderColor: "#80bdff",
                        boxShadow: "0 0 0 0.2rem #80bdff",
                    })
                    $("#eminvalid").fadeOut();
                    $("#passinvalid").fadeOut();
                }
            }
        })
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

// Ajax for add project 
