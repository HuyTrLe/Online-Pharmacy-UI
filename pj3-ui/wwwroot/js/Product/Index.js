﻿$("#btnSubmit").on("click", function () {
    let name = document.getElementById("name").value;
    let description = document.getElementById("description").value;
    let selectedCategoryId = document.getElementById("category").value;

    // Retrieve the selected specs data from the generated labels
    let selectedSpecs = [];
    const generatedSpecs = document.getElementsByClassName("spec-label-group");
    for (let i = 0; i < generatedSpecs.length; i++) {
        let specId = generatedSpecs[i].getAttribute("data-spec-id");
        let specValue = document.getElementById(`specValue${specId}`).value;
        let specName = document.getElementById(`specName${specId}`).value; // Get SpecName
        let specUnit = document.getElementById(`specUnit${specId}`).value; // Get SpecUnit
        selectedSpecs.push({
            SpecID: parseInt(specId), // Parse to an integer as it's an ID
            SpecName: specName,
            SpecUnit: specUnit,
            SpecValue: specValue
        });
    }

    var formData = new FormData();
    formData.append("Name", name);
    formData.append("Description", description);
    formData.append("CategoryID", selectedCategoryId);

    // Append the selected specs data to the form data
    for (let i = 0; i < selectedSpecs.length; i++) {
        formData.append("ProductSpecifications[" + i + "].SpecID", selectedSpecs[i].SpecID);
        formData.append("ProductSpecifications[" + i + "].SpecName", selectedSpecs[i].SpecName);
        formData.append("ProductSpecifications[" + i + "].SpecUnit", selectedSpecs[i].SpecUnit);
        formData.append("ProductSpecifications[" + i + "].SpecValue", selectedSpecs[i].SpecValue);
    }

    for (let i = 1; i <= 4; i++) {
        let imageInput = document.getElementById("productImage" + i);

        if (imageInput.files.length > 0) {
            formData.append("productImages", imageInput.files[0]);
        }
    }

    $.ajax({
        type: "POST",
        url: "/Product/InsertProduct",
        data: formData,
        processData: false,
        contentType: false,
        success: function (response) {
            if (response.success) {
                Swal.fire({
                    icon: 'success',
                    title: 'Success',
                    text: 'Add product success!'
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
                    text: response.message
                });
            }
        },
        error: function (xhr, status, error) {
            // Handle the error or show an error message.
            Swal.fire({
                icon: 'error',
                title: 'Error',
                text: error
            });
        }
    });
});