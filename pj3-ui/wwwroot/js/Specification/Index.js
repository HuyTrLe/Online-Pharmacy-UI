$(document).ready(function () {
    $(document).on("click", ".btnSubmit", function () {
        var specId = $(this).data("spec-id");
        var modal = $("#detailModal_" + specId);
        var name = modal.find("#Name").val();
        var unit = modal.find("#Unit").val();

        if (unit.trim() === "") {
            unit = 'none';
        }

        var formData = new FormData();
        formData.append("ID", specId);
        formData.append("Name", name);
        formData.append("Unit", unit);

        $.ajax({
            type: "POST",
            url: "/Specification/Update",
            data: formData,
            dataType: 'json',
            processData: false,
            contentType: false,
            success: function (result) {
                if (result > 0) {
                    Swal.fire({
                        icon: 'success',
                        title: 'Success',
                        text: 'Update success!'
                    }).then((result) => {
                        if (result.isConfirmed) {
                            window.location.href = '/Specification/IndexAdmin';
                        }
                    });
                } else {
                    Swal.fire({
                        icon: 'error',
                        title: 'Error',
                        text: 'Update failed'
                    });
                }
            }
        });
    });
});
