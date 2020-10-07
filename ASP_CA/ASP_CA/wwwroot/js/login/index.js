$(document).ready(function () {
    $("#submit").click(function () {
        var username = $("#username").val();
        var password = $("#password").val();

        if (username.length === 0 || password.length === 0) {
            $("#err_msg").html("Please fill up all fields.");
            return false;
        }

        return true;
    });
});  //Give error message when empty 