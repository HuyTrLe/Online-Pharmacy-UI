$("#btnRegister").on("click", function () {
    let dataUser = {};
    dataUser.UserName = document.getElementById("UserName").value;
    dataUser.Email = document.getElementById("Email").value;
    dataUser.PhoneNumber = document.getElementById("PhoneNumber").value;
    dataUser.Address = document.getElementById("Address").value;
    dataUser.Password = document.getElementById("Password").value;
    dataUser.ConfirmPassword = document.getElementById("ConfirmPassword").value;
    if (!checkValid(dataUser)) {
        Swal.fire({
            title: 'All field is required',
            showConfirmButton: true
        }).then((result) => {
            return;
        })
    }
    else {
        if (Validate(dataUser)) {
            if (dataUser.Password == dataUser.ConfirmPassword) {
                let param = {
                    user: dataUser
                }
                $.ajax({
                    type: "POST",
                    url: "/User/InsertUser",
                    data: param,
                    dataType: 'json',
                    success: function (result) {
                        if (result > 0) {
                            Swal.fire({
                                icon: 'sucess!',
                                title: 'Register Success!',
                                showConfirmButton: true
                            }).then((result) => {
                                window.location = "/Home/Index";
                            })

                        }
                        else if (result == -1) {
                            Swal.fire('Register fail, This email address is already used !')
                        }
                        else {
                            Swal.fire('Register fail, contact admin to fix!')
                        }

                    }
                })
            }
            else {
                Swal.fire({
                    title: 'Password and Confirm Password not match',
                    showConfirmButton: true
                }).then((result) => {
                    return;
                })
            }
        }
       
      
        
    }
    
   
})
function checkValid(dataUser) {
    if (dataUser.UserName == "" || dataUser.Email == "" || dataUser.PhoneNumber == "" || dataUser.Address == "")
        return false;
    if (dataUser.UserName == undefined || dataUser.Email == undefined || dataUser.PhoneNumber == undefined || dataUser.Address == undefined)
        return false;
    return true
}
function Validate(dataUser) {
    let error = 0;
    if (/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/.test(dataUser.Email)) {

    } else {
        Swal.fire("You have entered an invalid email address!");
        error++;
    }
    if (/^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$/.test(dataUser.PhoneNumber)) {

    }
    else {
        Swal.fire("You have entered an invalid phone number!");
        error++;
    }
    if (error > 0)
        return (false)
    else
        return (true)
}