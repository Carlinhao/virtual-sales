$(document).ready(function () {
    $(".btn-danger").click(function (e) {
        var result = confirm("Do you want to delete the record?");
        if (result == false) {
            e.preventDefault();
        }
    });
});