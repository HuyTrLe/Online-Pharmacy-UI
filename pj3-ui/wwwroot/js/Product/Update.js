$(document).ready(function () {
    // Use delegated event handling to target dynamically generated buttons
    $(document).on("click", ".btnSubmit", function () {
        let modalContent = $(this).closest(".modal-content");

        let name = modalContent.find("#name").val();
        let description = modalContent.find("#description").val();
        let selectedCategoryId = modalContent.find("#category").val();
        let categoryID = modalContent.find("#category0").val();
        let productID = modalContent.find("#ID").val();

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
                performUpdate(name, description, selectedCategoryId || categoryID, deleted, productID);
            });
        } else {
            // For other cases (e.g., "Active"), set the "Deleted" value to 0 and proceed with the AJAX request.
            performUpdate(name, description, selectedCategoryId || categoryID, deleted, productID);
        }
    });
});

function performUpdate(name, description, selectedCategoryId, deleted, productID) {
    var formData = new FormData();
    formData.append("CategoryID", selectedCategoryId);
    formData.append("Deleted", deleted);
    formData.append("ID", productID);
    formData.append("Name", name);
    formData.append("Description", description);

    $.ajax({
        type: "POST",
        url: "/Product/UpdateProduct",
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
                        window.location.href = '/Product/IndexAdmin';
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
