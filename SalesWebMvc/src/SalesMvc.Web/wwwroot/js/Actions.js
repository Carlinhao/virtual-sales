$(document).ready(function () {
    $(".btn-danger").click(function (e) {
        var result = confirm("Confirm?");
        if (result == false) {
            e.preventDefault();
        }
    });
});