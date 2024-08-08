$(document).ready(function () {
	$(".category").on("click", function () {

		// Lấy ID của danh mục từ thuộc tính data-category-id
		var categoryID = $(this).data('categoryid');
		let param = {
			categoryID: categoryID
		}
		// Gửi yêu cầu AJAX để lấy sản phẩm theo danh mục
		$.ajax({
			url: '/Product/ProductCategory',
			method: 'POST',
			data: param,
			success: function (data) {
				if (data != null) {
					$('#productlist').html('');
					data.forEach(function (item){
						var result = `"<div class="col-lg-4 col-md-6 service_grid_btm_left mt-lg-5 mt-4" >

																<div >
																	<img src="/assets/images/${item.thumbnail} " alt=" " class="img-fluid" width="300" height="300"/>
																	<div class="service_grid_btm_left2">
																		<h5>${item.name}</h5>
																		<a>Maecenas sodales eu velit in varius. vitae sem vitae urna tempus commodo.</a>
																		<br></br>
																		<div class="read">
																			<a class="btn" href="/Product/ProductDetails/${item.id}">Read More</a>
																		</div>
																	</div>

																</div>

															</div>
											"`;
						$('#productlist').append(result);
					})
				}

				// Cập nhật phần hiển thị sản phẩm với dữ liệu mới


			},
			error: function (xhr, status, error) {
				console.log(error);
			}
		});
	});
});

//Huy
$("#btnSubmit").on("click", function () {
    let name = document.getElementById("name").value;
    let description = document.getElementById("description").value;
    let selectedCategoryId = document.getElementById("category").value;

    // Retrieve the selected specs data from the generated labels
    let selectedSpecs = [];
    const generatedSpecs = document.getElementsByClassName("spec-label-group");
    for (let i = 0; i < generatedSpecs.length; i++) {
        let specId = generatedSpecs[i].getAttribute("data-spec-id");
        let specValue = document.getElementById(`specValue${specId}`).value;
        let specName = document.getElementById(`specName${specId}`).value;
        let specUnit = document.getElementById(`specUnit${specId}`).value;

        if (!specValue || specValue.trim() === "") {
            Swal.fire({
                icon: 'error',
                title: 'Error',
                text: 'Specification value cannot be blank or null.'
            });
            return; // Exit the function if a spec value is invalid
        }

        selectedSpecs.push({
            SpecID: parseInt(specId),
            SpecName: specName,
            SpecUnit: specUnit,
            SpecValue: specValue
        });
    }

    // Create an object with the product data
    let productData = {
        Name: name,
        Description: description,
        CategoryID: selectedCategoryId
    };

    // Check for required conditions (keep this part of your validation)
    if (!name || !description || !selectedCategoryId) {
        Swal.fire({
            icon: 'error',
            title: 'Error',
            text: 'Name, description, and category are required fields.'
        });
    } else if (name.length > 50) {
        Swal.fire({
            icon: 'error',
            title: 'Error',
            text: 'Name max 50 characters'
        });
    } else if (description.length > 200) {
        Swal.fire({
            icon: 'error',
            title: 'Error',
            text: 'Description max 200 characters'
        });
    }
    else if (selectedSpecs.length === 0) {
        Swal.fire({
            icon: 'error',
            title: 'Error',
            text: 'At least one specification must be added.'
        });
    } else if (selectedSpecs.length > 10) {
        Swal.fire({
            icon: 'error',
            title: 'Error',
            text: 'You can add a maximum of 10 specifications.'
        });
    } else {
        // Make an AJAX request to check the uniqueness of the name
        $.ajax({
            type: "POST",
            url: "/Product/CheckUniqueByName",
            data: productData,
            success: function (result) {
                if (result === 1) {
                    // Name is unique, proceed with creating the product

                    var formData = new FormData();
                    formData.append("Name", name);
                    formData.append("Description", description);
                    formData.append("CategoryID", selectedCategoryId);

                    for (let i = 0; i < selectedSpecs.length; i++) {
                        formData.append("ProductSpecifications[" + i + "].SpecID", selectedSpecs[i].SpecID);
                        formData.append("ProductSpecifications[" + i + "].SpecName", selectedSpecs[i].SpecName);
                        formData.append("ProductSpecifications[" + i + "].SpecUnit", selectedSpecs[i].SpecUnit);
                        formData.append("ProductSpecifications[" + i + "].SpecValue", selectedSpecs[i].SpecValue);
                    }

                    let imageInputCount = 0;
                    for (let i = 1; i <= 4; i++) {
                        let imageInput = document.getElementById("productImage" + i);
                        if (imageInput.files.length > 0) {
                            imageInputCount++;
                            formData.append("productImages", imageInput.files[0]);
                        }
                    }
                    if (imageInputCount < 1) {
                        Swal.fire({
                            icon: 'error',
                            title: 'Error',
                            text: 'At least one image must be uploaded.'
                        });
                        return; // Exit the function if no image is uploaded
                    }

                    // Proceed with creating the product
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
                                Swal.fire({
                                    icon: 'error',
                                    title: 'Error',
                                    text: response.message
                                });
                            }
                        },
                        error: function (xhr, status, error) {
                            Swal.fire({
                                icon: 'error',
                                title: 'Error',
                                text: error
                            });
                        }
                    });
                } else if (result === -1) {
                    // Name is not unique
                    Swal.fire({
                        icon: 'error',
                        title: 'Error',
                        text: 'Product name already have.'
                    });
                } else {
                    // An error occurred during uniqueness check
                    Swal.fire({
                        icon: 'error',
                        title: 'Error',
                        text: 'An error occurred while checking the uniqueness of the name.'
                    });
                }
            },
            error: function (xhr, status, error) {
                // Handle AJAX request errors
                Swal.fire({
                    icon: 'error',
                    title: 'Error',
                    text: 'An error occurred while checking the uniqueness of the name: ' + error
                });
            }
        });
    }
});
