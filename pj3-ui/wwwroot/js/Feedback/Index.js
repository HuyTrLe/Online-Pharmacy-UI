$("#btnSubmit").on("click", function () {
    let email = document.getElementById("Email").value;
    let fullName = document.getElementById("FullName").value;
    let companyName = document.getElementById("CompanyName").value;
    let phoneNumber = document.getElementById("PhoneNumber").value;
    let subject = document.getElementById("Subject").value;
    let comment = document.getElementById("Comment").value;
    var formData = new FormData();
    formData.append("Email", email);
    formData.append("FullName", fullName);
    formData.append("CompanyName", companyName);
    formData.append("PhoneNumber", phoneNumber);
    formData.append("Subject", subject);
    formData.append("Comment", comment);

    $.ajax({
        type: "POST",
        url: "/Feedback/InsertFeedback",
        data: formData,
        dataType: 'json',
        processData: false, 
        contentType: false,
        success: function (result) {
            if (result > 0) {
                Swal.fire({
                    icon: 'success',
                    title: 'Success',
                    text: 'Thanks for your feedback, we will contact you if it necessary!'
                }).then((result) => {
                    if (result.isConfirmed) {
                        window.location.href = '/';
                    }
                });             
            }
        }
    })
})