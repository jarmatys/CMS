jQuery(window).on("load", function () {
    "use strict";

    /*  ===================================
     Loading Timeout
     ====================================== */
    $("#loader-fade").fadeOut(800);
});

jQuery(function ($) {
    "use strict";

    var $window = $(window);
    var windowsize = $(window).width();

    /* ===================================
       Nav Scroll
       ====================================== */
    //scroll sections
    if($("body").hasClass("intrective")){
        $(".scroll").on("click", function (event) {
            event.preventDefault();
            $("html,body").animate({
                scrollTop: $(this.hash).offset().top}, 700);
        });

    }else {

    $(".scroll").on("click", function(event){
        event.preventDefault();
        $('html,body').animate({
            scrollTop: $(this.hash).offset().top
        }, 700);
    });
    }
    /* ====================================
      Nav Fixed On Scroll
   ======================================= */

    if ($("nav.navbar").hasClass("static-nav")) {
        $window.scroll(function () {
            var $scroll = $window.scrollTop();
            var $navbar = $(".static-nav");
            if ($scroll >= 80) {
                $navbar.addClass("fixed-menu");
            } else {
                $navbar.removeClass("fixed-menu");
            }
        });
    }

    /*bottom menu fix*/
    if ($("nav.navbar").hasClass("bottom-nav")) {
        var navHeight = $(".bottom-nav").offset().top;
        $window.scroll(function () {
            if ($window.scrollTop() > navHeight) {
                $('.bottom-nav').addClass('fixed-menu');
            } else {
                $('.bottom-nav').removeClass('fixed-menu');
            }
        });
    }

    /* ===================================
       Side Bar/Full Menu On click
       ====================================== */

    /* ------- Full Menu Toggle ------ */
    $(".menu_bars").on("click",function () {
        $(".overlay-menu").addClass("open");
    });

    if($(".side-nav-content li a").hasClass("scroll")){
        $(".side-nav-content li a").on("click",function () {
            $(".overlay-menu").removeClass("open");
        });
    }

    $(".menu_bars2").on("click",function () {
        $(".overlay-menu").removeClass("open");
    });

    if ($(".side-right-btn").length) {

        $(".side-right-btn").click(function () {
            $(".navbar.navbar-right").toggleClass('show');
        }),
            $(".navbar.navbar-right .navbar-nav .nav-link").click(function () {
                $(".navbar.navbar-right").toggleClass('show');
            });

    }

    /* =====================================
            Wow
       ======================================== */

    if ($(window).width() > 767) {
        var wow = new WOW({
            boxClass: 'wow',
            animateClass: 'animated',
            offset: 0,
            mobile: false,
            live: true
        });
        new WOW().init();
    }

    /* ----- Full Screen ----- */
    function resizebanner() {
        var $fullscreen = $(".full-screen");
        $fullscreen.css("height", $window.height());
        $fullscreen.css("width", $window.width());
    }
    resizebanner();
    $window.resize(function () {
        resizebanner();
    });

    /* ===================================
       Features Section Number Scroller
       ====================================== */

    $(".stats").appear(function () {
        $('.numscroller').each(function () {
            $(this).prop('Counter',0).animate({
                Counter: $(this).text()
            }, {
                duration: 5000,
                easing: 'swing',
                step: function (now) {
                    $(this).text(Math.ceil(now));
                }
            });
        });
    });

    /* ===================================
       Equal Heights
       ====================================== */
    checheight();
    $window.on("resize", function () {
        checheight();
    });

    function checheight() {
        var $smae_height = $(".equalheight");
        if ($smae_height.length) {
            if (windowsize > 767) {
                $smae_height.matchHeight({
                    property: "height",
                });
            }
        }
    }

    /* ===================================
       Animated Progress Bar
       ====================================== */

    $(".progress-bar").each(function () {
        $(this).appear(function () {
            $(this).animate({width: $(this).attr("aria-valuenow") + "%"}, 2000)
        });
    });

    /* ===================================
       Parallax
       ====================================== */
    if (windowsize > 992) {
        $(".parallaxie").parallaxie({
            speed: 0.4,
            offset: 0,
        });
    }

    /* ===================================
       Fancy Box
       ====================================== */
    $('[data-fancybox]').fancybox({
        protect: true,
        animationEffect: "fade",
        hash: null,
    });

    /* ===================================
       Rotating Text
       ====================================== */

    $("#js-rotating").Morphext({
        // The [in] animation type. Refer to Animate.css for a list of available animations.
        animation: "flipInX",
        // An array of phrases to rotate are created based on this separator. Change it if you wish to separate the phrases differently (e.g. So Simple | Very Doge | Much Wow | Such Cool).
        separator: ",",
        // The delay between the changing of each phrase in milliseconds.
        speed: 3000,
        complete: function () {
            // Called after the entrance animation is executed.
        }
    });

    /* ===================================
       Type Text
       ====================================== */

    if ($("#typewriting").length) {
        var app = document.getElementById("typewriting");
        var typewriter = new Typewriter(app, {
            loop: true
        });
        typewriter.typeString('Way to achieve success').pauseFor(2000).deleteAll()
            .typeString('Style to achieve success').pauseFor(2000).deleteAll()
            .typeString('Method to achieve success').start();
    }

    if ($("#personal").length) {
        var app = document.getElementById("personal");
        var personal = new Typewriter(app, {
            loop: true
        });
        personal.typeString('UI/UX Designer').pauseFor(2000).deleteAll()
            .typeString('Web Developer').pauseFor(2000).deleteAll()
            .typeString('Wordpress Developer').start();
    }

    /* =====================================
       Coming Soon Count Down
       ====================================== */


    if ($(".count_down").length) {
        $('.count_down').downCount({
            date: '03/3/2019 12:00:00',
            offset: +10
        });
    }

    /* ===================================
       Swiper
       ======================================*/
    if ($(".swiper-container").hasClass("team-member-slider")) {
    var swiper = new Swiper('.swiper-container', {
        slidesPerView: 3,
        allowTouchMove: true,
        loop: true,
        centeredSlides: true,
        slideToClickedSlide: true,
        effect: "coverflow",
        grabCursor: true,
        autoplay: {
            delay: 1200
        },
        navigation: {
            nextEl: '.swiper-button-next',
            prevEl: '.swiper-button-prev',
        },
        coverflow: {
            rotate: 0,
            stretch: 100,
            depth: 200,
            modifier: 1,
            slideShadows: false
        },
        breakpoints: {
            // when window width is <= 768px
            767: {
                slidesPerView: 1,
                centeredSlides: false,
                effect: "slide",
            }
        }
    });
    }

    /* ===================================
       Owl Carousel
       ====================================== */
    /* RTL */
    if ($("body").hasClass("rtl-layout")) {
        $(".owl-team").owlCarousel({
            items: 3,
            margin: 30,
            dots: false,
            nav: false,
            loop: true,
            autoplay: true,
            smartSpeed: 1000,
            navSpeed: true,
            autoplayHoverPause: true,
            responsiveClass: true,
            rtl: callback,
            responsive: {
                992: {
                    items: 4,
                },
                600: {
                    items: 2,
                },
                320: {
                    items: 1,
                },
            }
        });
        $(".owl-testimonial").owlCarousel({
            autoplay: 1000,
            smartSpeed: 1500,
            margin: 30,
            slideBy: 1,
            autoplayHoverPause: true,
            loop: true,
            dots: false,
            nav: false,
            rtl: callback,
            responsive: {
                1200: {
                    items: 4
                },
                992: {
                    items: 3
                },
                600: {
                    items: 2
                },
                320: {
                    items: 1
                },
            }
        });
    }

    /* Our Team */
    $(".owl-team").owlCarousel({
        items: 3,
        margin: 30,
        dots: false,
        nav: false,
        loop:true,
        autoplay: true,
        smartSpeed:1000,
        navSpeed: true,
        autoplayHoverPause:true,
        responsiveClass:true,
        responsive: {
            992: {
                items: 4,
            },
            600: {
                items: 2,
            },
            320: {
                items: 1,
            },
        }
    });

    /* Testimonial One */
    $(".owl-testimonial").owlCarousel({
        autoplay: 1000,
        smartSpeed: 1500,
        margin: 30,
        slideBy: 1,
        autoplayHoverPause: true,
        loop: true,
        dots: false,
        nav: false,
        responsive: {
            1200: {
                items: 4
            },
            992: {
                items: 3
            },
            600: {
                items: 2
            },
            320: {
                items: 1
            },
        }
    });

    /* Testimonial Two */
    $('.testimonial-two').owlCarousel({
        loop: true,
        smartSpeed: 500,
        responsiveClass: true,
        nav:false,
        dots:false,
        autoplay: true,
        autoplayHoverPause: true,
        autoplayTimeout: 3000,
        responsive: {
            0: {
                items: 1,
                margin: 30,
            },
            480: {
                items: 1,
                margin: 30,
            },
            992: {
                items: 1,
                margin: 30,
            }
        }
    })

    /* Brand Carousel */
    $('.brand-carousel').owlCarousel({
        margin: 75,
        nav: false,
        navText: [
            '<i class="ti ti-angle-left"></i>',
            '<i class="ti ti-angle-right"></i>'
        ],
        dots: false,
        autoWidth: false,
        autoplay: 300,
        autoplayHoverPause: false,
        loop: true,
        rtl: callback,
        responsive: {
            0: {
                items: 1
            },
            480: {
                items: 2
            },
            600: {
                items: 4
            },
            1000: {
                items: 5
            }
        }
    });

    /*Simple text fading banner*/
    $("#text-fading").owlCarousel({
        items: 1,
        autoplay: true,
        autoplayHoverPause: true,
        loop: true,
        mouseDrag: false,
        animateIn: "fadeIn",
        animateOut: "fadeOut",
        dots: true,
        nav: false,
        rtl: callback,
        responsive: {
            0: {
                items: 1
            }
        }
    });

    /* ===================================
       Slick
       ====================================== */
    $('.carousel-content').slick({
        slidesToShow: 1,
        slidesToScroll: 1,
        asNavFor: '.carousel-img',
        dots: false,
        infinite: true,
        verticalReverse: true,
        verticalSwiping: true,
        useTransform: true,
        useCSS: false,
        rtl: callback,
        responsive: [
            {
                breakpoint: 768,
                settings: {
                    touchMove: true,
                    verticalReverse: false,
                    verticalSwiping: false,
                    swipe: true,
                    useTransform: false,
                    useCSS: false,
                }
            }
        ]
    });

    $('.carousel-img').slick({
        slidesToShow: 1,
        slidesToScroll: 1,
        autoplay: true,
        asNavFor: '.carousel-content',
        dots: false,
        infinite: true,
        verticalReverse: true,
        verticalSwiping: true,
        useTransform: false,
        useCSS: true,
        rtl: callback,
        responsive: [
            {
                breakpoint: 768,
                settings: {
                    verticalReverse: false,
                    verticalSwiping: false,
                    swipe: true,
                    useTransform: false,
                    useCSS: false,
                }
            }
        ]
    });


    /* ===================================
       Cube Portfolio
       ====================================== */

    (function ($, window, document, undefined) {

        // init cubeportfolio
        $('#js-grid-mosaic-flat').cubeportfolio({
            filters: '#js-filters-mosaic-flat',
            layoutMode: 'mosaic',
            defaultFilter: '*',
            animationType: 'scaleSides',
            gapHorizontal: -1,
            gapVertical: -1,
            gridAdjustment: 'responsive',
            caption: 'zoom',
            displayType: 'fadeIn',
            displayTypeSpeed: 100,
            sortByDimension: true,
            mediaQueries: [{
                width: 1500,
                cols: 4
            },{
                width: 1100,
                cols: 4
            }, {
                width: 768,
                cols: 2
            }, {
                width: 480,
                cols: 1
            }, {
                width: 320,
                cols: 1
            }],
            // lightbox
            lightboxDelegate: '.cbp-lightbox',
            lightboxGallery: true,
            lightboxTitleSrc: 'data-title',
            lightboxCounter: '<div class="cbp-popup-lightbox-counter">{{current}} of {{total}}</div>',

            plugins: {
                loadMore: {
                    element: '#js-loadMore-mosaic-flat',
                    action: 'click',
                    loadItems: 3,
                }
            },
        })

        /*Blog Masonry*/
        $("#blog-masonry").cubeportfolio({
            layoutMode: 'grid',
            defaultFilter: '*',
            animationType: "scaleSides",
            gapHorizontal: 30,
            gapVertical: 30,
            gridAdjustment: "responsive",
            mediaQueries: [{
                width: 1500,
                cols: 3
            }, {
                width: 1100,
                cols: 3
            }, {
                width: 992,
                cols: 2
            }, {
                width: 600,
                cols: 2
            }, {
                width: 480,
                cols: 1
            }, {
                width: 320,
                cols: 1
            }]
        });
        /*Portfolio Three*/
        $('#js-grid-mosaic').cubeportfolio({
            filters: '.filtering',
            layoutMode: 'grid',
            sortByDimension: true,
            mediaQueries: [{
                width: 1500,
                cols: 2
            },{
                width: 1100,
                cols: 2
            }, {
                width: 768,
                cols: 2
            }, {
                width: 600,
                cols: 2
            }, {
                width: 320,
                cols: 1
            }],
            defaultFilter: '*',
            animationType: 'fadeOut',
            gapHorizontal: 20,
            gapVertical: 60,
            gridAdjustment: 'responsive',
            caption: 'zoom',

            // lightbox
            lightboxDelegate: '.cbp-lightbox',
            lightboxGallery: true,
            lightboxTitleSrc: 'data-title',
            lightboxCounter: '<div class="cbp-popup-lightbox-counter">{{current}} of {{total}}</div>',

            plugins: {
                loadMore: {
                    element: "#js-loadMore-lightbox-gallery",
                    action: "click",
                    loadItems: 5,
                }
            }

        })

    })(jQuery, window, document);


    function callback() {
        if($("body").hasClass("rtl-layout")){
            rtl: true
        }
    }
    /* =====================================
       Portfolio Filter
       ======================================= */

    /*Portfolio Two*/

    // isotope
    $('.gallery').isotope({
        // options
        itemSelector: '.items'
    });

    var $gallery = $('.gallery').isotope({
        // options
    });

    // filter items on button click
    $('.filtering').on('click', 'span', function () {

        var filterValue = $(this).attr('data-filter');

        $gallery.isotope({filter: filterValue});

    });

    $('.filtering').on('click', 'span', function () {

        $(this).addClass('active').siblings().removeClass('active');

    });

    setTimeout(function (){
        $('.filtering .active').click();
    }, 1500);

});