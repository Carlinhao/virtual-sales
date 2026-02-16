$(document).ready(function () {
    $(".btn-danger").click(function (e) {
        let result = confirm("Confirm?");
        if (!result) {
            e.preventDefault();
        }
    });
    $('.money').mask('000.000.000.000.000,00', { reverse: true });

    AjaxImageUpload();
});

function AjaxImageUpload() {
    $(".img-upload").click(function () {
        $(this).parent().find(".input-file").click();
    });

    $(".input-file").on('change', function () {
        var files = $('.input-file').prop("files");
        var form = new FormData();

        form.append("file", files[0]);

        $.ajax({
            type: "POST",
            url: "/Employee/Image/Import",
            data: form,
            contentType: false,
            processData: false,
            error: function () {
                alert("Error when import image!");
            },
            success: function (data) {
                alert("Success");
            }
        });
    });
}