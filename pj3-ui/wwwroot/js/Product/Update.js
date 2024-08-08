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
        let originalName = modalContent.find("#originalName").val(); // Add this line

        // Validate name and description
        if (!isInputValid(name, description)) {
            return; // Validation failed, don't proceed with the update
        }

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
                performUpdate(name, description, selectedCategoryId || categoryID, deleted, productID, originalName);
            });
        } else {
            // For other cases (e.g., "Active"), set the "Deleted" value to 0 and proceed with the AJAX request.
            performUpdate(name, description, selectedCategoryId || categoryID, deleted, productID, originalName);
        }
    });
});

function performUpdate(name, description, selectedCategoryId, deleted, productID, originalName) {
    if (name !== originalName) {
        // The input name has been modified, check if it's unique
        checkUniqueName(name, function (isUnique) {
            if (isUnique > 0) {
                // Name is unique, proceed with the update using the input name
                performUpdateWithNewName(name, description, selectedCategoryId || categoryID, deleted, productID);
            } else {
                // Show an error message that the name is not unique
                Swal.fire({
                    icon: 'error',
                    title: 'Error',
                    text: 'Product name is not unique.'
                });
            }
        });
    } else {
        // The input name is the same as the original name, no need to update the name
        performUpdateWithNewName(name, description, selectedCategoryId || categoryID, deleted, productID);
    }
}

function performUpdateWithNewName(name, description, selectedCategoryId, deleted, productID) {
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

function checkUniqueName(name, callback) {
    // Make an AJAX request to check the uniqueness of the name
    $.ajax({
        type: "POST",
        url: "/Product/CheckUniqueByName",
        data: { Name: name },
        success: function (isUnique) {
            callback(isUnique);
        },
        error: function (xhr, status, error) {
            // Handle AJAX request errors
            Swal.fire({
                icon: 'error',
                title: 'Error',
                text: 'An error occurred while checking the uniqueness of the name: ' + error
            });
            callback(false); // Consider it not unique in case of an error
        }
    });
}

function isInputValid(name, description) {
    if (!name) {
        Swal.fire({
            icon: 'error',
            title: 'Error',
            text: 'Name cannot be empty.'
        });
        return false;
    }

    if (name.length > 50) {
        Swal.fire({
            icon: 'error',
            title: 'Error',
            text: 'Name must be 50 characters or less.'
        });
        return false;
    }

    if (description && description.length > 200) {
        Swal.fire({
            icon: 'error',
            title: 'Error',
            text: 'Description must be 200 characters or less.'
        });
        return false;
    }

    return true;
}