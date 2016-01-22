/// <reference path="jquery-1.11.3.js" />
$(document).on("ready",function(){
    $("#formLogin").hide();
});

function muestraLogin(){
    $(".inicio").hide();
    $("#formLogin").show('slow');
}

function EnviaDemo(){
        console.log("Entro al submit del formulario");
        window.location.replace("views/Default/default.html");
};