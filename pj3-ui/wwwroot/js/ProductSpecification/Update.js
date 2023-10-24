$(document).ready(function () {
    $(document).on("click", ".btnSubmit", function () {
        // Get the specId from the data attribute of the clicked button
        var specId = $(this).data("spec-id");
        var modal = $("#detailModal_" + specId);
        var specName = modal.find("#SpecName_" + specId).val();
        var productID = modal.find("#ProductID_" + specId).val();
        var specID = modal.find("#SpecID_" + specId).val();
        var specUnit = modal.find("#SpecUnit_" + specId).val();
        var specValue = modal.find("#SpecValue_" + specId).val();

        var formData = new FormData();
        formData.append("ID", specId);
        formData.append("SpecName", specName);
        formData.append("ProductID", productID);
        formData.append("SpecID", specID);
        formData.append("SpecUnit", specUnit);
        formData.append("SpecValue", specValue);

        $.ajax({
            type: "POST",
            url: "/ProductSpecification/Update", // Modify the URL to match your controller action
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
                            window.location.href = '/ProductSpecification/IndexAdmin';
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
            url: "/ProductSpecification/Delete", // Modify the URL to match your controller action
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
                            window.location.href = '/ProductSpecification/IndexAdmin';
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
