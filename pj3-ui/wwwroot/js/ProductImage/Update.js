$(document).ready(function () {
    $(document).on("click", ".btnSubmit", function () {
        var specId = $(this).data("spec-id");
        var imageInput = document.getElementById("productImage_" + specId);
        var formData = new FormData();

        if (imageInput.files.length > 0) {
            formData.append("productImageFile", imageInput.files[0]);
        } else {
            var existingImage = $("#existingImage_" + specId).val(); // Get the existing image path
            formData.append("Image", existingImage); // Append existing image when no new image is selected
        }

        // Get the existing product image data from the view
        var productImage = {
            ID: specId,
            ProductID: $("#ProductID_" + specId).val()
        };

        // Include ID and ProductID in the formData
        formData.append("ID", productImage.ID);
        formData.append("ProductID", productImage.ProductID);

        $.ajax({
            type: "POST",
            url: "/ProductImage/Update",
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
                            window.location.href = '/ProductImage/IndexAdmin';
                        }
                    });
                } else {
                    Swal.fire({
                        icon: 'error',
                        title: 'Error',
                        text: 'Update failed'
                    });
                }
            },
            error: function (xhr, status, error) {
                var errorMessage = xhr.responseText || error;
                Swal.fire({
                    icon: 'error',
                    title: 'Error',
                    text: errorMessage
                });
            }
        });
    });

    $(document).on("click", "#btnAdd", function (e) {
        e.preventDefault(); // Prevent the default form submission

        var imageInput = document.getElementById("productImage");
        var productId = $("#productID").val(); // Get the selected product ID

        var formData = new FormData();

        // Check if an image file was selected
        if (imageInput.files.length > 0) {
            formData.append("productImageFile", imageInput.files[0]);
            formData.append("productID", productId);

            // Check if adding the image exceeds the limit
            $.ajax({
                type: "POST",
                url: "/ProductImage/CheckProductImage", // Controller action to check the limit
                data: formData,
                processData: false,
                contentType: false,
                success: function (checkResult) {
                    if (checkResult === -1) {
                        // Exceeded the image limit
                        Swal.fire({
                            icon: 'error',
                            title: 'Error',
                            text: 'You have reached the maximum number of images for this product.'
                        });
                    } else if (checkResult === 1) {
                        // Proceed with image upload
                        $.ajax({
                            type: "POST",
                            url: "/ProductImage/InsertImage", // Controller action to insert the image
                            data: formData,
                            processData: false,
                            contentType: false,
                            success: function (result) {
                                if (result > 0) {
                                    Swal.fire({
                                        icon: 'success',
                                        title: 'Success',
                                        text: 'Image added!'
                                    }).then((result) => {
                                        if (result.isConfirmed) {
                                            // Optionally, you can close the modal here
                                            $('#addImageModal').modal('hide');
                                            window.location.reload();
                                            // You might want to refresh the product image list or take other actions
                                            // depending on your specific requirements.
                                        }
                                    });
                                } else {
                                    Swal.fire({
                                        icon: 'error',
                                        title: 'Error',
                                        text: 'Image upload failed'
                                    });
                                }
                            },
                            error: function (xhr, status, error) {
                                var errorMessage = xhr.responseText || error;
                                Swal.fire({
                                    icon: 'error',
                                    title: 'Error',
                                    text: errorMessage
                                });
                            }
                        });
                    }
                },
                error: function (xhr, status, error) {
                    var errorMessage = xhr.responseText || error;
                    Swal.fire({
                        icon: 'error',
                        title: 'Error',
                        text: errorMessage
                    });
                }
            });
        } else {
            // Handle the case where no image was selected
            Swal.fire({
                icon: 'error',
                title: 'Error',
                text: 'Please select an image to upload.'
            });
        }
    });

    $(".btnDelete").on("click", function () {
        var specId = $(this).data("spec-id");

        Swal.fire({
            title: 'Are you sure?',
            text: 'Do you want to delete this image?',
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
            url: "/ProductImage/DeleteProductImage", // Modify the URL to match your controller action
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
                            window.location.reload();
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
