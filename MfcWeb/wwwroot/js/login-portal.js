$(document).ready(function () {

    $(document).on("click", "#btn-login", function (e) {
        e.preventDefault();
        $(".loading-screen").css("display", "grid");

        let username = $("#username").val();
        let password = $("#password").val();

        let model = {
            username,
            password
        }

        $.ajax({
            url: '/Login/Login',
            type: "POST",
            contentType: 'application/json',
            data: JSON.stringify(model),
            success: function (response) {
                $(".loading-screen").css("display", "none");
                console.log(response);

                if (response == "success") {
                    swal("Success!", "Login Success", "success").then(() => {
                        window.location.href = "/Bpkb/ListBpkb";
                    })
                } else {
                    $("#msg-login").css("display", "block");
                }
            },
            error: function (request, status, error) {
                $(".loading-screen").css("display", "none");
                $("#msg-login").css("display", "block");
                console.log(request.responseText);
            }
        })
    })

    $(document).on("click", "#btn-register", function (e) {
        console.log("masuk")
        e.preventDefault();
        $(".loading-screen").css("display", "grid");

        let username = $("#username").val();
        let password = $("#password").val();

        let model = {
            username,
            password
        }

        $.ajax({
            url: '/Login/Register',
            type: "POST",
            contentType: 'application/json',
            data: JSON.stringify(model),
            success: function (response) {
                $(".loading-screen").css("display", "none");
                console.log(response);

                if (response == "success") {
                    swal("Success!", "Register Success", "success").then(() => {
                        window.location.href = "/Login/Login";
                    })
                } else {
                    $("#msg-login").css("display", "block");
                }
            },
            error: function (request, status, error) {
                $(".loading-screen").css("display", "none");
                $("#msg-login").css("display", "block");
                console.log(request.responseText);
            }
        })
    })
})