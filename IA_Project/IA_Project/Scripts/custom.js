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
    });
});
