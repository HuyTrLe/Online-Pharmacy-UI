$(".btnDetail").on("click", function () {
    var ID = $(this).data("id");
    let param = {
        ID: ID
    }
    $.ajax({
        type: "POST",
        url: "/Career/GetDetailInfor",
        data: param,
        dataType: 'json',
        success: function (data) {
            if (data.success) {
                window.location.href = '/Career/Detail?result=' + JSON.stringify(data.result);
            } else {
                Swal.fire(data.error);
            }

        },

    })
})
$(".btnApply").on("click", function () {
    Swal.fire({
        title: 'Do you want to apply for this job with current resume?',
        showDenyButton: true,
        showCancelButton: true,
        confirmButtonText: 'Apply',
        denyButtonText: `Change infro user`,
    }).then((result) => {
        /* Read more about isConfirmed, isDenied below */
        if (result.isConfirmed) {
            let jobID = $(this).data("id");
            let carrer = {};
            carrer.JobID = jobID;
            let param = {
                careerGet: carrer
            }
            $.ajax({
                type: "POST",
                url: "/Career/InsertCareerJob",
                data: param,
                dataType: 'json',
                success: function (data) {
                    if (data.success) {
                       // window.location.href = '/Career/Detail?result=' + JSON.stringify(data.result);
                    } else {
                        Swal.fire(data.error);
                    }

                },

            })
        } else if (result.isDenied) {
            window.location = "/User/Detail";
        }
    })
})
