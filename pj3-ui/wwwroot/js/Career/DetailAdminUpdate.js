
$("#btnUpdate").on("click", function () {
    let dataCareer = {};
    dataCareer.ID = document.getElementById("ID").value;
    dataCareer.Title = document.getElementById("Title").value;
    dataCareer.Position = document.getElementById("Position").value;
    dataCareer.TimeStart = document.getElementById("TimeStart").value;
    dataCareer.TimeEnd = document.getElementById("TimeEnd").value;
    dataCareer.Price = document.getElementById("Price").value;
    dataCareer.Status = document.getElementById("Status").value;
    dataCareer.ShortDescription = document.getElementById("ShortDescription").value;
    dataCareer.Description = document.getElementById("Description").value;
    if (dataCareer.Title == "" || dataCareer.Position == "" || dataCareer.TimeStart == "" || dataCareer.TimeEnd == "" || dataCareer.Price == 0 || dataCareer.ShortDescription == "" || dataCareer.Description == "") {
        Swal.fire("Please fill all field");
        return;
    }
    else {
        let param = {
            careerModel: dataCareer
        }
        $.ajax({
            type: "POST",
            url: "/Career/UpdateCareer",
            data: param,
            dataType: 'json',
            success: function (result) {
                if (result > 0) {
                    Swal.fire({
                        icon: 'success',
                        title: 'Update Success!',
                        showConfirmButton: false,
                        timer: 1500
                    }).then((result) => {
                        window.location = "/Career/IndexAdmin";
                    })    
                    
                }
                else {
                    Swal.fire("Update fail");
                }

            },

        })
    }

})