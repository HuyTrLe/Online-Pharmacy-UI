﻿$(".btnDetail").on("click", function () {
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
    let author = $(this).data("author");
    if (author != 0 && typeof author === "number") {
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
                window.scrollTo(0, 0);
                $.ajax({
                    type: "POST",
                    url: "/Career/InsertCareerJob",
                    data: param,
                    dataType: 'json',
                    success: function (data) {
                        if (data.success) {
                            Swal.fire({
                                icon: 'success',
                                title: 'Apply Success!',
                                showConfirmButton: false,
                                timer: 2000
                            }).then((result) => {
                                window.location = "/Career/Index";
                            })    
                        } else {
                            Swal.fire(data.error);
                        }

                    },

                })
            } else if (result.isDenied) {
                window.location = "/User/Detail";
            }
        })
    }
    else {
        Swal.fire({
            title: 'Apply for job',
            text: "You need login to apply this job!",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Yes, Login!'
        }).then((result) => {
            if (result.isConfirmed) {
                window.location = "/User/Index";
            }
        })
    }

})

