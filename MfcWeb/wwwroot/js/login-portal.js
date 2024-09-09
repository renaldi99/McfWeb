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
                console.log(response);
                if (response.is_success) {
                    $(".loading-screen").css("display", "none");

                    window.location.href = "/Bpkb/ListBpkb";
                }
            },
            error: function (request, status, error) {
                $(".loading-screen").css("display", "none");
                alert(request.responseText);
            }
        })
    })
})