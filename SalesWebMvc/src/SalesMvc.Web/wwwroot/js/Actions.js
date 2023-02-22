$(document).ready(function () {
    $(".btn-danger").click(function (e) {
        let result = confirm("Confirm?");
        if (!result) {
            e.preventDefault();
        }
    });
    $('.money').mask('000.000.000.000.000,00', { reverse: true });
});