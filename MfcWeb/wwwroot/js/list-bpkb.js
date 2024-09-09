$(document).ready(function () {
    console.log("masuk");
    $("#myTable").DataTable({
        scrollx: true,
        searching: true,
        ajax: {
            url: "/Bpkb/LoadData",
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
            { data: "agreement_number", autoWidth: true },
            { data: "bpkb_no", autoWidth: true },
            { data: "branch_id", autoWidth: true },
            { data: "bpkb_date", autoWidth: true },
            { data: "faktur_no", autoWidth: true },
            { data: "faktur_date", autoWidth: true },
            { data: "location_id", autoWidth: true },
            { data: "police_no", autoWidth: true },
            { data: "bpkb_date_in", autoWidth: true },
            { data: "created_by", autoWidth: true },
            { data: "created_on", autoWidth: true },
            { data: "last_updated_by", autoWidth: true },
            { data: "last_updated_on", autoWidth: true },
        ]
    })
})
