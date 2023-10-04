$("#btnlogin").on("click", function () {
    let email = document.getElementById("email").value;
    let password = document.getElementById("password").value;
    var formData = new FormData();
    formData.append("Email", email);
    formData.append("Password", password);
    $.ajax({
        type: "POST",
        url: "/User/Login",
        data: formData,
        dataType: 'json',
        processData: false, 
        contentType: false,
        success: function (result) {
            if (result.id > 0) {
                alert("Login complete");              
            }


        }
    })
})