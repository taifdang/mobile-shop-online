$(document).ready(function () {
    $(".owl-carousel").owlCarousel({
        autoplay: true,
        autoplayTimeout: 2500,
        loop: true,
        autoplayHoverPause: true,
        dots: false,
        nav: false,
        responsive: {
            0: {
                items: 1,
                margin: 50
            },
            390: {
                items: 1,
                margin: 70
            },
            412: {
                items: 2,
                margin: 62
            },
            600: {
                items: 3,
                margin: 60
            },
            1024: {
                items: 4,
                margin: 70
            }
        }
    });
    $(".owl-item").css("width", "180px")
    $(".owl-stage").css("height", "400px")
});

