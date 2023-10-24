﻿$(document).ready(function () {
    $(document).on("click", ".btnSubmit", function () {
        var specId = $(this).data("spec-id");
        var modal = $("#detailModal_" + specId);
        var name = modal.find("#Name_" + specId).val();
        var unit = modal.find("#Unit_" + specId).val();

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

    // Handle the delete action for the same item
    $(".btnDelete").on("click", function () {
        var specId = $(this).data("spec-id");

        Swal.fire({
            title: 'Are you sure?',
            text: 'Do you want to delete this item?',
            icon: 'warning',
            showCancelButton: true,
            confirmButtonText: 'Yes, delete it!',
            cancelButtonText: 'No, cancel!',
        }).then((result) => {
            if (result.isConfirmed) {
                // User confirmed the delete, proceed with the delete action.
                performDelete(specId);
            }
        });
    });

    function performDelete(specId) {
        $.ajax({
            type: "POST",
            url: "/Specification/DeleteSpecification", // Modify the URL to match your controller action
            data: { id: specId },
            dataType: 'json',
            success: function (result) {
                if (result > 0) {
                    Swal.fire({
                        icon: 'success',
                        title: 'Success',
                        text: 'Delete success!'
                    }).then((result) => {
                        if (result.isConfirmed) {
                            window.location.href = '/Specification/IndexAdmin';
                        }
                    });
                } else {
                    Swal.fire({
                        icon: 'error',
                        title: 'Error',
                        text: 'Delete failed'
                    });
                }
            }
        });
    }
});
