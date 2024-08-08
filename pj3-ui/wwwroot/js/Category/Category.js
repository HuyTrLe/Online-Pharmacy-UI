$(document).ready(function () {
    // Use delegated event handling to target dynamically generated buttons
    $(document).on("click", ".btnSubmit", function () {
        let modalContent = $(this).closest(".modal-content");

        let Name = modalContent.find("#name").val();
        let ID = modalContent.find("#ID").val();
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
                performUpdate(Name,ID);
            });
        } else {
            // For other cases (e.g., "Active"), set the "Deleted" value to 0 and proceed with the AJAX request.
            performUpdate(Name,ID);
        }
    });
});

function performUpdate(Name,ID) {
    var formData = new FormData();
    formData.append("ID", ID);
    formData.append("Name", Name);


    $.ajax({
        type: "POST",
        url: "/Category/UpdateCategory",
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

