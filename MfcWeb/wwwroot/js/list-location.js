$(document).ready(function () {
    let userData = JSON.parse(localStorage.getItem("user"));


    $(document).on("click", "#add_storage", function (e) {
        e.preventDefault();
        window.location.href = "/Storage/AddStorage";

    })

    $("#myTableLoc").DataTable({
        scrollx: true,
        searching: true,
        ajax: {
            url: "/Storage/LoadData",
            type: "GET",
            contentType: 'application/json',
            dataType: "json",
            dataSrc: function (data) {
                if (data.is_success) {
                    return data.data;
                } else {
                    return [];
                }
            }
        },
        columns: [
            { data: "location_id", autoWidth: true },
            { data: "location_name", autoWidth: true },
        ]
    })
})
