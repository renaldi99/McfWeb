$(document).ready(function () {
    var agreement_number = $("#agreement_number").val();

    $('#bpkb_date_in').datetimepicker({
        format: 'YYYY-MM-DD HH:mm:ss',
    });

    $('#bpkb_date').datetimepicker({
        format: 'YYYY-MM-DD HH:mm:ss',
    });

    $('#faktur_date').datetimepicker({
        format: 'YYYY-MM-DD HH:mm:ss',
    });

    $.ajax({
        url: '/Bpkb/LoadStorage',
        type: "GET",
        contentType: 'application/json',
        success: function (response) {
            var str = "";
            console.log("stg: ", response.data)
            for (var i = 0; i < response.data.length; i++) {
                str += `<option value=${response.data[i].location_id}>${response.data[i].location_name}</option>`
            }

            $("#location_id").append(str)
        },
        error: function (request, status, error) {
            console.log(request.responseText);
        }
    });

    $.ajax({
        url: `/Bpkb/GetBpkb?agreement_number=${agreement_number}`,
        type: "GET",
        contentType: 'application/json',
        success: function (response) {
            let data = response.data;
            $("#branch_id").val(data.branch_id);
            $("#bpkb_no").val(data.bpkb_no);
            $("#bpkb_date_in").val(formatDateTime(data.bpkb_date_in));
            $("#bpkb_date").val(formatDateTime(data.bpkb_date));
            $("#faktur_no").val(data.faktur_no);
            $("#faktur_date").val(formatDateTime(data.faktur_date));
            $("#police_no").val(data.police_no);
            $("#location_id").val(data.location_id).trigger("change");
        },
        error: function (request, status, error) {
            console.log(request.responseText);
        }
    });

    

    $(document).on("click", "#btn_save", function (e) {
        e.preventDefault();
        $(".loading-screen").css("display", "grid");

        let branch_id = $("#branch_id").val();
        let bpkb_no = $("#bpkb_no").val();
        let bpkb_date_in = $("#bpkb_date_in").val();
        let bpkb_date = $("#bpkb_date").val();
        let faktur_no = $("#faktur_no").val();
        let faktur_date = $("#faktur_date").val();
        let police_no = $("#police_no").val();
        let location_id = $("#location_id").val();
        let user_id = $("#user_id").val();
        let agreement_number = $("#agreement_number").val();

        var databpkb = {
            agreement_number,
            branch_id,
            bpkb_no,
            bpkb_date_in,
            bpkb_date,
            faktur_no,
            faktur_date,
            police_no,
            location_id,
            user_id,
        }

        console.log("data bpkb: ", databpkb);
        $.ajax({
            url: '/Bpkb/UpdateBpkb',
            type: "POST",
            contentType: 'application/json',
            data: JSON.stringify(databpkb),
            success: function (response) {
                $(".loading-screen").css("display", "none");
                console.log(response);

                if (response == "success") {
                    swal("Success!", "Update Data Success", "success").then(() => {
                        window.location.href = "/Bpkb/ListBpkb";
                    });
                }
            },
            error: function (request, status, error) {
                $(".loading-screen").css("display", "none");

                console.log(request.responseText);
            }
        })
    });

})


let formatDateTime = (dateTimeString) => {
    if (!dateTimeString) return null;

    // Split the string at "T"
    const parts = dateTimeString.split("T");
    if (parts.length !== 2) return null; // Ensure it has both date and time

    // Extract date and time
    const datePart = parts[0]; // "YYYY-MM-DD"
    const timePart = parts[1].split(".")[0]; // "HH:mm:ss"

    // Combine into the desired format
    return `${datePart} ${timePart}`;
}