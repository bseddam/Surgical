$(document).ready(function() {

    $('.lightgallery').lightGallery({
        pager: true
    });

    $(".left_div_ob_ot").on("click", function() {
        $(".left_div_ob").css("left", "0px");
        $(".left_div_ob_ot").css("display", "none");
        $(".left_div_ob_zak").css("display", "block");
    })

    $(".left_div_ob_zak").on("click", function() {
        $(".left_div_ob").css("left", "-100%");
        $(".left_div_ob_ot").css("display", "block");
        $(".left_div_ob_zak").css("display", "none");
    })
});