$(document).ready(function () {

    $(document).on("click", "#btn_save_loc", function (e) {
        e.preventDefault();
        console.log("masuk");
        $(".loading-screen").css("display", "grid");

        let location_name = $("#location_name").val();

        var dataloc = {
            location_name,
        }

        $.ajax({
            url: '/Storage/AddStorage',
            type: "POST",
            contentType: 'application/json',
            data: JSON.stringify(dataloc),
            success: function (response) {
                $(".loading-screen").css("display", "none");

                if (response == "success") {
                    swal("Success!", "Add Location Success", "success").then(() => {
                        window.location.href = "/Storage/ListStorage";
                    });
                };
            },
            error: function (request, status, error) {
                $(".loading-screen").css("display", "none");
                console.log(request.responseText);
            }
        })
    });

})
