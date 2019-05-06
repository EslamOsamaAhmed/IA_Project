$(document).ready(function () {
    $("#eminvalid").fadeOut();
    $("#passinvalid").fadeOut();
    $("#unameinvalid").fadeOut();
    $("#emailinvalid").fadeOut();
    $("#emailinvalidr").fadeOut();
    $("#codeinvalid").fadeOut();
    $("#timelate").fadeOut();
    $("#resendcode").fadeOut();
    $("#ResetPass").hide();
    $("#codereset").hide();
    $("#passreset").hide();
    if (sessionStorage['UserName'] == null) {
        $("#signout").hide();
    }
    else { $("#signout").show(); }
    $("#Add_project_button").click(function () {
        if ($("#Add_Project_form").valid()) {
            var my_data = $("#Add_Project_form").serialize();
            $.ajax({
                type: "POST",
                url: "/Home/Index",
                data: my_data,
                success: function (response) {
                    $("#Add_Project_form")[0].reset();

                }
            })
        }
    })

    $(".res-t").click(function () {
        $.ajax({
            type: "GET",
            url: "/fprofile/getNotif",
            dataType: 'HTML', 
            success: function (response) {
                $(".ress").html(response);
            }
        })
    })

    $(".req").click(function () {
        $.ajax({
            type: "GET",
            url: "/fprofile/getNotifreq",
            dataType: 'HTML',
            success: function (response) {
                $(".reqs").html(response);
            }
        })
    })

    var check = 0;

    $("#login-forgot-pass").click(function () {
        $("#loginForm").hide();
        $("#ResetPass").show();
    })

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

    
    $("#register").click(function () {
        if ($("#register-form").valid()) {
            myData = $("#register-form").serialize();

            $.ajax({
                type: "POST",
                url: "/Home/Register",
                data: myData,
                success: function (response) {
                    if (response == 11) {
                        $("#username").css({
                            borderColor: "rgb(229, 145, 148)",
                            boxShadow: "0 0 0 0.2rem rgb(229, 145, 148)",
                        })
                        $("#unameinvalid").fadeIn();

                    } else if (response == 12) {
                        $("#email").css({
                            borderColor: "rgb(229, 145, 148)",
                            boxShadow: "0 0 0 0.2rem rgb(229, 145, 148)",
                        })
                        $("#emailinvalidr").fadeIn();
                    }
                    else if (response == 0) {
                        $("#username").css({
                            borderColor: "#80bdff",
                            boxShadow: "0 0 0 0.2rem #80bdff",
                        })

                        $("#email").css({
                            borderColor: "#80bdff",
                            boxShadow: "0 0 0 0.2rem #80bdff",
                        })

                        window.location.href = "/Home/index";

                        $("#emailinvalidr").fadeOut();
                        $("#unameinvalid").fadeOut();


                        alert("Registered");
                    } else {
                        alert("Error");
                    }
                }
            })
        }
    });

    $("#emailValid").hide();
    $("#passValid").hide();

    $("#signinfooter").click(function () {
        $("#loginForm").show();
        $("#ResetPass").hide();
    })

    $("#upassword").click(function () {
        var data = $("#passreset").serialize();
        $.ajax({
            type: "POST",
            url: "/Home/ResetNewPass",
            data: data,
            success: function (response) {
                if(response == 60){
                    window.location.href = "/Home/index";
                }
            }
        })
    })
    
    $("#resend").click(function () {
        var data = $("#codereset").serialize();
        $.ajax({
            type: "POST",
            url: "/Home/Resend",
            data: data,
            success: function (response) {
                $("#codeinvalid").fadeOut();
                $("#codeinvalid").fadeOut();
                $("#resendcode").fadeIn();
            }
        })
    })

    $("#resetpass").click(function () {
        var data = $("#codereset").serialize();
        $.ajax({
            type: "POST",
            url: "/Home/ResetPassword",
            data: data,
            success: function (response) {
               if (response == 25) {
                    $("#coderes").css({
                        borderColor: "rgb(229, 145, 148)",
                        boxShadow: "0 0 0 0.2rem rgb(229, 145, 148)",
                    })

                    $("#codeinvalid").fadeIn();
                    $("#timelate").fadeOut();
                    $("#resendcode").fadeOut();

               } else if (response == 35) {
                   $("#coderes").css({
                       borderColor: "rgb(229, 145, 148)",
                       boxShadow: "0 0 0 0.2rem rgb(229, 145, 148)",
                   })

                   $("#codeinvalid").fadeOut();
                   $("#timelate").fadeIn();
                   $("#resendcode").fadeOut();

               }
               else if (response == 22) {
                    $("#coderes").css({
                        borderColor: "#80bdff",
                        boxShadow: "0 0 0 0.2rem #80bdff",
                    })

                    $("#emailff").val($("#emailf").val());

                    $("#passreset").show();
                    $("#codeinvalid").fadeOut();
                    $("#timelate").fadeOut();
                    $("#resendcode").fadeOut();
                    $("#codereset").hide();
                }
            }
        })
    })

    $("#sendmail").click(function(){
        var data = $("#ResetPass").serialize();
        $.ajax({
            type: "POST",
            url: "/Home/Sendcode",
            data: data,
            success: function (response) {
                alert(response)
                if (response == 50) {
                    $("#emailreset").css({
                        borderColor: "rgb(229, 145, 148)",
                        boxShadow: "0 0 0 0.2rem rgb(229, 145, 148)",
                    })

                    $("#emailinvalid").fadeIn();

                } else if (response == 11) {
                    $("#emailreset").css({
                        borderColor: "#80bdff",
                        boxShadow: "0 0 0 0.2rem #80bdff",
                    })

                    $("#codereset").show();
                    $("#ResetPass").hide();
                    $("#emailf").val($("#emailreset").val());
                }
             }
        })
    })

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

$(window).load(function () {
    $.ajax({
        type: "GET",
        url: "/Home/Display_NotAssign",
        success: function (response) {
            $("#heree").html(response)
            $(".btn-proj").hide();
            

        }
    })

});

function newval(id) {
    alert(id)
    $.ajax({
        type: "GET",
        url: "/fprofile/AllUserstoAssign/" + id,
        success: function (response) {
            $("#show-users-role").html(response)
        }
    })
}

function del(id){
    $.ajax({
        type: "POST",
        url: "/fprofile/DeleteReq/" + id,
        success: function (response) {
            if (response == 12) {
                $(".delete").parent().parent().fadeOut();
                alert("done");
            } else {
                alert("error");
            }
        }
    })
}

function acce(id) {
    $.ajax({
        type: "POST",
        url: "/fprofile/AcceptReq/" + id,
        success: function (response) {
            if (response == 12) {
                $(".accept").parent().parent().fadeOut();
                alert("done");
            } else {
                alert("error");
            }
        }
    })
}


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
