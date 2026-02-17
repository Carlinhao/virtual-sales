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
    
    $(".btn-imagem-delete").click(function () {
        var inputHidden = $(this).parent().find("input[name=image]");
        var imageUp = $(this).parent().find(".img-upload");
        
        $.ajax({
            type: "GET",
            url: "/Employee/Image/Delete?pathFile=" + encodeURIComponent(inputHidden.val()),
            error: function () {
                alert("Error when delete image!");
            },
            success: function () {
                imageUp.attr("src", "~/img/imagem-padrao.png");
            }
        });
    });
    
    $(".input-file").on('change', function () {
        var files = $('.input-file').prop("files");
        var form = new FormData();

        form.append("file", files[0]);
        var campoHidden = $(this).parent().find("input[name=image]");
        var imageUp = $(this).parent().find(".img-upload");
        
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
                var caminho = data.caminho;
                imageUp.attr("src", caminho);
                campoHidden.val(caminho);            
            }
        });
    });
}