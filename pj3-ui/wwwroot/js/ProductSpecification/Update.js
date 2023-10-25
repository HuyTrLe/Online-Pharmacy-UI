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
    // Using vanilla JavaScript
    document.getElementById("generateSpecInputs").addEventListener("click", function () {
        var selectedSpecID = document.getElementById("SpecID").value;

        if (selectedSpecID) {
            var selectedSpec = document.getElementById("SpecID").options[document.getElementById("SpecID").selectedIndex];
            var text = selectedSpec.text;

            // Split the text using regular expressions to extract "Name" and "Unit"
            var nameMatch = text.match(/Name: (.*?) Unit:/);
            var unitMatch = text.match(/Unit: (.*?) \(ID:/);

            var name = nameMatch ? nameMatch[1].trim() : "";
            var unit = unitMatch ? unitMatch[1].trim() : "";

            document.getElementById("SpecName").value = name;
            document.getElementById("SpecUnit").value = unit;
        } else {
            // Handle the case when no specification is selected
            document.getElementById("SpecName").value = "";
            document.getElementById("SpecUnit").value = "";
        }
    });

    // Using jQuery
    $('#generateSpecInputs').click(function () {
        // Get the selected SpecID and related data
        var selectedProductID = document.getElementById("ProductID").value;
        var selectedSpecID = document.getElementById("SpecID").value;
        var selectedSpecName = document.getElementById("SpecName").value;
        var selectedSpecUnit = document.getElementById("SpecUnit").value;

        let productSpecModel = {};
        productSpecModel.SpecName = selectedSpecName;
        productSpecModel.ProductID = selectedProductID;

        let productSpecArr = { productSpec: productSpecModel };

        $.ajax({
            type: "POST",
            url: "/ProductSpecification/CheckSpecName", // Modify the URL to match your controller action
            data: productSpecArr,
            dataType: 'json',
            success: function (result) {
                if (result == -1) {
                    Swal.fire({
                        icon: 'error',
                        title: 'Error',
                        text: 'This SpecName is already in use for this Product.'
                    });
                    // Disable the #btnAdd button
                    $('#btnAdd').prop('disabled', true);
                } else {
                    // Enable the #btnAdd button
                    $('#btnAdd').prop('disabled', false);
                }
            }
        });
    });


    
});
function checkInput() {
    var selectedSpecName = document.getElementById("SpecName").value;
    var selectedSpecUnit = document.getElementById("SpecUnit").value;
    var selectedSpecValue = document.getElementById("SpecValue").value;

    return !(!selectedSpecName || !selectedSpecUnit || !selectedSpecValue);
}

function checkSpecCount(selectedProductID, callback) {
    $.ajax({
        type: 'POST',
        url: '/ProductSpecification/CheckSpecCount',
        data: {
            ProductID: selectedProductID
        },
        dataType: 'json',
        success: function (countResult) {
            callback(countResult);
        }
    });
}

function handleAjaxRequest(formData) {
    $.ajax({
        type: 'POST',
        url: '/ProductSpecification/InsertProductSpec',
        data: formData,
        dataType: 'json',
        processData: false,
        contentType: false,
        success: function (result) {
            if (result > 0) {
                Swal.fire({
                    icon: 'success',
                    title: 'Success',
                    text: 'Add success!',
                    showConfirmButton: true,
                }).then((result) => {
                    if (result.isConfirmed) {
                        window.location.href = "ProductSpecification/IndexAdmin";
                    }
                });
            } else {
                // Handle the error or show an error message.
                Swal.fire({
                    icon: 'error',
                    title: 'Error',
                    text: 'Add fail',
                    showConfirmButton: true,
                });
            }
        }
    });
}

$('#btnAdd').on("click",function () {
    var selectedProductID = document.getElementById("ProductID").value;

    if (checkInput()) {
        checkSpecCount(selectedProductID, function (countResult) {
            if (countResult === -1) {
                Swal.fire({
                    icon: 'error',
                    title: 'Error',
                    text: 'The specification has reached the limit (10).',
                    showConfirmButton: true,
                });
            } else if (countResult === 1) {
                var selectedSpecID = document.getElementById("SpecID").value;
                var selectedSpecName = document.getElementById("SpecName").value;
                var selectedSpecUnit = document.getElementById("SpecUnit").value;
                var selectedSpecValue = document.getElementById("SpecValue").value;

                var formData = new FormData();
                formData.append("ProductID", selectedProductID);
                formData.append("SpecID", selectedSpecID);
                formData.append("SpecName", selectedSpecName);
                formData.append("SpecUnit", selectedSpecUnit);
                formData.append("SpecValue", selectedSpecValue);

                handleAjaxRequest(formData);
            }
        });
    } else {
        Swal.fire({
            icon: 'error',
            title: 'Error',
            text: 'SpecName, SpecUnit, and SpecValue are required',
            showConfirmButton: true,
        });
    }
});

