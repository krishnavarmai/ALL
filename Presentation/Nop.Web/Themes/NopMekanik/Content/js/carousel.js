
$(window).load(function () {
    function handleOwlCarouselControl(element, show) {
        if (show) {
            $(element).find('.owl-controls').show();
        }
        else {
            $(element).find('.owl-controls').hide();
        }
    }

    var owl0 = $(".home-page-category-grid .owl-carousel, .home-page-product-grid .owl-carousel, .bestsellers .owl-carousel, .also-purchased-products-grid .owl-carousel, .related-products-grid .owl-carousel, .cross-sells .owl-carousel");
    owl0.on('initialized.owl.carousel', function (event) {
        handleOwlCarouselControl(event.target, event.page.count > 1);
    });
    owl0.on('resized.owl.carousel', function (event) {
        handleOwlCarouselControl(event.target, event.page.count > 1);
    });
    owl0.owlCarousel({
        responsive: {
            0: {
                items: 1
            },
            390: {
                items: 2
            },
            768: {
                items: 3
            },
            1200: {
                items: 4
            },
            1500: {
                items: 5
            }
        },
        nav: true,
    });


    var owl1 = $(".featured-product-grid .owl-carousel");
    owl1.on('initialized.owl.carousel', function (event) {
        handleOwlCarouselControl(event.target, event.page.count > 1);
    });
    owl1.on('resized.owl.carousel', function (event) {
        handleOwlCarouselControl(event.target, event.page.count > 1);
    });
    owl1.owlCarousel({
        responsive: {
            0: {
                items: 1
            },
            390: {
                items: 2
            },
            768: {
                items: 3
            }
        },
        nav: true,
    });
});


$(document).ready(function () {
    //Lazy Load
    $("img.lazy").show().lazyload({
        skip_invisible: false
    });

    /* Scroll to Top */
    $(".totop").hide();

    $(function () {
        $(window).scroll(function () {
            if ($(this).scrollTop() > 300) {
                $('.totop').fadeIn();
            }
            else {
                $('.totop').fadeOut();
            }
        });

        $('.totop a').click(function (e) {
            e.preventDefault();
            $('body,html').animate({ scrollTop: 0 }, 500);
        });

    });
});