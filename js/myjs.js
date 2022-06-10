function printContent(el) {
    //alert('s');
    var restorepage = document.body.innerHTML;
    var printcontent = document.getElementById(el).innerHTML;
    document.body.innerHTML = printcontent;
    window.print();
    document.body.innerHTML = restorepage;
}
$(document).ready(function() {


    // News In text font size
    function newsInFontSize() {
        // text scale and print end
        var $affectedElements = $(".news_fonts");
        $affectedElements.each(function() {
            var $this = $(this);
            $this.data("orig-size", $this.css("font-size"));
        });

        $("#btn-increase").click(function() {
            changeFontSize(1);
        })

        $("#btn-decrease").click(function() {
            changeFontSize(-1);
        })

        $("#btn-orig").click(function() {
            $affectedElements.each(function() {
                var $this = $(this);
                $this.css("font-size", $this.data("orig-size"));
            });
        })

        function changeFontSize(direction) {
            $affectedElements.each(function() {
                var $this = $(this);
                $this.css("font-size", parseInt($this.css("font-size")) + direction);
            });
        }
    }
    newsInFontSize();


    // News In text font size

    // Header fixed end
    function fixedMobileNav() {
        var nav = $('header ');
        var main = $('main ');
        var scrolled = false;

        $(window).scroll(function() {

            if (120 < $(window).scrollTop() && !scrolled) {
                nav.addClass('visible_mob');
                main.addClass('p_top');
                scrolled = true;
            }

            if (120 > $(window).scrollTop() && scrolled) {
                nav.removeClass('visible_mob');
                main.removeClass('p_top');
                scrolled = false;
            }
        });
    }
    fixedMobileNav();
    // Header fixed end

    //Menu 
    function menuClick() {
        $(".menu_btn.open").click(function() {
            $(this).toggleClass("close");
            $("nav.nav_mobile").toggleClass("transformed");
            // $("body").toggleClass("mm_noscroll");
        });
    }
    menuClick();
    //Menu 

    //SEARCH 
    function searchClick() {
        $(".icon_search").click(function(e) {
            e.preventDefault();
            $(".hd_search").addClass("show");
        });
        $(".close_src").click(function() {
            $(".hd_search").removeClass("show");
        });
    }
    searchClick();
    //SEARCH

    //dropdown menu 
    function dropMenu() {
        // $(".hdr_menu li a").each(function() {
        //     if ($(this).siblings().hasClass("dropdown")) {
        //         $(this).addClass("arw_rt");
        //     }
        // });
        // $(".nav_desk .hdr_menu li").hover(function(e) {
        //     e.stopPropagation();
        //     e.preventDefault();
        //     $(this).toggleClass("menu_active");
        //     $(this).find(".dropdown").toggleClass("open")
        // });
        $(".nav_mobile .hdr_menu li a").click(function(e) {
            e.stopPropagation();
            e.preventDefault();
            $(this).parents("li").toggleClass("menu_active");
            $(this).parents("li").siblings().removeClass("menu_active");
            $(this).siblings(".dropdown").slideToggle();
            $(this).parents("li").siblings().find(".dropdown").slideUp();
        });
    }
    dropMenu();
    //dropdown menu 
    //language 
    function dropLangs() {
        $(".lang_sect").click(function() {
            $(this).toggleClass("clicked");
            // $(this).find(".langs").slideToggle();
        });
    }
    dropLangs();
    //language
    //collapse 
    function collapse() {
        $("body").on('click', '.collapse_btn', function() {
            $(this).find(".collapse_content").slideToggle();
            $(this).toggleClass("active")
        });
        $("body").on('click', '.collapse_content', function(e) {
            e.stopPropagation();
        });
    }
    collapse();
    //collapse
    //left menu 
    function leftMenu() {
        $("body").on('click', '.left_mobile', function() {
            $(".left_inner_menu").slideToggle();
            // $(this).toggleClass("active")
        });
    }
    leftMenu();
    //left menu

    //Equal height
    equalHeight();

    function equalHeight(event) {
        $('.wrap_operations .main_items').matchHeight({ property: 'min-height' });
        $('.product_gallery_images_upload').matchHeight({ property: 'min-height' });
    }
    //Equal height
});
var swiper = new Swiper('.manshet_news .swiper-container', {
    slidesPerView: 4,
    spaceBetween: 20,
    noSwiping: true,
    allowTouchMove: true,
    loop: true,
    speed: 1700,
    autoplay: {
        slideSpeed: 1700,
        delay: 2000,
        disableOnInteraction: false,
    },
    // pagination: {
    //     el: '.manshet_news  .swiper-pagination',
    //     clickable: true,
    // },
    navigation: {
        nextEl: '.manshet_news .swiper-button-next',
        prevEl: '.manshet_news .swiper-button-prev',
    },
});
var swiper = new Swiper('.manshet_top .swiper-container', {
    slidesPerView: 1,
    spaceBetween: 20,
    noSwiping: true,
    allowTouchMove: true,
    loop: true,
    speed: 2000,
    autoplay: {
        slideSpeed: 2000,
        delay: 2000,
        disableOnInteraction: false,
    },
    pagination: {
        el: '.manshet_top  .swiper-pagination',
        clickable: true,
    },
    navigation: {
        nextEl: '.manshet_top .swiper-button-next',
        prevEl: '.manshet_top .swiper-button-prev',
    },
});

// var swiper = new Swiper('.wrap_odds .swiper-container', {
//     slidesPerView: 4,
//     spaceBetween: 32,
//     noSwiping: false,
//     allowTouchMove: false,
//     loop: false,
//     speed: 1700,

//     breakpoints: {
//         1200: {
//             slidesPerView: 3,
//             spaceBetween: 20,
//             autoplay: {
//                 slideSpeed: 1700,
//                 delay: 1700,
//                 disableOnInteraction: false,
//             },
//             loop: true,
//             noSwiping: true,
//             allowTouchMove: true,
//         },
//         767: {
//             slidesPerView: 2,
//             spaceBetween: 20,
//             autoplay: {
//                 slideSpeed: 1700,
//                 delay: 1700,
//                 disableOnInteraction: false,
//             },
//             loop: true,
//             noSwiping: true,
//             allowTouchMove: true,
//         },
//         480: {
//             slidesPerView: 2,
//             spaceBetween: 16,
//             autoplay: {
//                 slideSpeed: 1700,
//                 delay: 1700,
//                 disableOnInteraction: false,
//             },
//             loop: true,
//             noSwiping: true,
//             allowTouchMove: true,
//         }
//     }
// });