
$("#btnInsert").on("click", function () {
    let dataCareer = {};
    dataCareer.Title = document.getElementById("Title").value;
    dataCareer.Position = document.getElementById("Position").value;
    dataCareer.TimeStart = document.getElementById("TimeStart").value;
    dataCareer.TimeEnd = document.getElementById("TimeEnd").value;
    dataCareer.Price = document.getElementById("Price").value;
    dataCareer.Status = document.getElementById("Status").value;
    dataCareer.Skill = document.getElementById("Skill").value;
    dataCareer.ShortDescription = document.getElementById("ShortDescription").value;
    dataCareer.Description = document.getElementById("Description").value;
    if (dataCareer.TimeStart > dataCareer.TimeEnd) {
        Swal.fire("Time Start need smaller Time End");
        return;
    }
    if (dataCareer.Title == "" || dataCareer.Position == "" || dataCareer.TimeStart == "" || dataCareer.TimeEnd == "" || dataCareer.Price == 0 || dataCareer.ShortDescription == "" || dataCareer.Description == "") {
        Swal.fire("Please fill all field");
        return;
    }
    else if (dataCareer.ShortDescription.length > 500 || dataCareer.ShortDescription.length < 100) {
        Swal.fire("Short Description length is need between 100 and 500");
        return;
    }
    else
    {
        let param = {
            careerModel: dataCareer
        }
        $.ajax({
            type: "POST",
            url: "/Career/InsertCareerAdmin",
            data: param,
            dataType: 'json',
            success: function (result) {
                if (result > 0) {
                    window.location = "/Career/IndexAdmin";
                }
                else {
                    Swal.fire("Insert fail");
                }

            },

        })
    }

})