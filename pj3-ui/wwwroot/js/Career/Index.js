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
                window.location.href = '/Career/Detail?data=' + JSON.stringify(data.result);
            } else {
                Swal.fire(data.error);
            }

        },

    })
})
$(".btnApply").on("click", function () {
    let author = $(this).data("author");
    if (author != 0) {
        Swal.fire({
            title: 'Do you want to apply for this job with current resume?',
            showDenyButton: true,
            showCancelButton: true,
            confirmButtonText: 'Apply',
            denyButtonText: `Change infro user`,
        }).then(async (result) => {
            /* Read more about isConfirmed, isDenied below */
            if (result.isConfirmed) {
                if (await CheckResume()) {
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
                }
                else {
                    Swal.fire({
                        icon: 'error',
                        title: 'Oops...',
                        text: 'User have not resume, please update resume!'
                    })
                }
                
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
function CheckResume() {
    return new Promise(function (resolve, reject) {
        $.ajax({
            type: "POST",
            url: "/Career/CheckResume",
            dataType: 'json',
            success: function (data) {
                if (data.result === 1) {
                    resolve(true);
                } else {
                    resolve(false);
                }
            },
            error: function () {
                resolve(false);
            }
        });
    });
}
