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