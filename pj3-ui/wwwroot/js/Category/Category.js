$(document).ready(function () {
    // Use delegated event handling to target dynamically generated buttons
    $(document).on("click", ".btnSubmit", function () {
        let modalContent = $(this).closest(".modal-content");

        let name = modalContent.find("#name").val();
        let categoryID = modalContent.find("#ID").val();
        let deleted = modalContent.find("#delete").val();

        if (deleted === "Deactive") {
            Swal.fire({
                title: 'Are you sure?',
                text: 'Do you want to deactivate this product?',
                icon: 'warning',
                showCancelButton: true,
                confirmButtonText: 'Yes, deactivate it!',
                cancelButtonText: 'No, cancel!',
            }).then((result) => {
                if (result.isConfirmed) {
                    // User confirmed deactivation, set the "Deleted" value to 1.
                    deleted = true;
                } else {
                    // User canceled deactivation, no action is taken.
                    deleted = false;
                    return;
                }
                performUpdate(name, categoryID);
            });
        } else {
            // For other cases (e.g., "Active"), set the "Deleted" value to 0 and proceed with the AJAX request.
            performUpdate(name, categoryID);
        }
    });
});

function performUpdate(name, categoryID) {
    var formData = new FormData();
    formData.append("ID", productID);
    formData.append("Name", name);

    $.ajax({
        type: "POST",
        url: "/Category/UpdateAdmin",
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
                        window.location.href = '/Category/IndexAdmin';
                    }
                });
            } else {
                // Handle the error or show an error message.
                Swal.fire({
                    icon: 'error',
                    title: 'Error',
                    text: 'Update fail'
                });
            }
        }
    });
}
