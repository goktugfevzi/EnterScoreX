/*	################################################################
 File Name: custom.js
 Template Name: Soprtsox
 Created By: webRedox
 ################################################################# */


/* LOAD EVENT */
jQuery(window).on('load', function () {
    "use strict"; // Start of use strict
    /* PRELOADER */
    $('#preloader').hide();
    $('.cart-list').removeClass('animated')
});

jQuery('document').ready(function ($) {

    "use strict"; // Start of use strict

    /* STICKY MENU */
    var navHeight =  41;
    var topNavHeight = 50;
    var nav = $('.header-section');

    $(window).scroll(function () {
        if($(nav).hasClass('agency-header')){
            if ($(this).scrollTop() > topNavHeight) {
                nav.addClass("fixed");
            } else {
                nav.removeClass("fixed");
            }
        }else{
            if ($(this).scrollTop() > navHeight) {
                nav.addClass("fixed");
            } else {
                nav.removeClass("fixed");
            }
        }

    });

    /* === Latest News Filtter === */
    $('.button-group li').on('click', function(){
        $('.button-group li').removeClass('active');
        $(this).addClass('active');
    })

    /*== PrettyPhoto ==*/
    $("area[data-gal^='prettyPhoto']").prettyPhoto();
    $(".gallery:first a[data-gal^='prettyPhoto']").prettyPhoto({animation_speed: 'normal', theme: 'pp_default', slideshow: 3000, autoplay_slideshow: false, social_tools: ''});
    $(".gallery:gt(0) a[data-gal^='prettyPhoto']").prettyPhoto({animation_speed: 'fast', slideshow: 10000, hideflash: true});

    /* === Jquery Counter === */
    $('.countdown').downCount({
        date: '12/31/2016 12:00:00',
        offset: +1
    });

    /* === APPEAR FUNCTION === */
    $('.skillbar').each(function () {
        $(this).appear(function () {
            $(this).find('.count-bar').animate({
                width: $(this).attr('data-percent')
            }, 3000);
            var percent = jQuery(this).attr('data-percent');
            $(this).find('.count').html('<span>' + percent + '</span>');
        });
    });

    /* === Twitter ===*/
	$('#tweets').twittie({
		username: 'envato',
		count: 2,
		template: '<a href="#"><i class="fa fa-twitter"></i><div class="twitter-content"><p>{{tweet}}</p><span><b>{{date}}</b></span></div></a>',
		apiPath: './scripts/Tweetie/api/tweet.php'
	});

});

/* === BEST PLAYRE === */
(function($){

    "use strict"; // Start of use strict

    var owl = $("#bestplayer");
    owl.owlCarousel({
        items: 3,
        itemsDesktop: [1000, 2],
        itemsDesktopSmall: [900, 2],
        itemsTablet: [600, 1],
        itemsMobile: false
    });
})(jQuery);

/* === SLIDER GANE TIME === */
(function($){

    "use strict"; // Start of use strict

    var owl = $("#slider-game-time");
    owl.owlCarousel({
        items: 4,
        itemsDesktop: [1000, 4],
        itemsDesktopSmall: [900, 4],
        itemsTablet: [600, 4],
        itemsMobile: false
    });
})(jQuery);

/* === PLAYRE === */
(function($){

    "use strict"; // Start of use strict

    var owl = $("#player");
    owl.owlCarousel({
        items: 1,
        itemsDesktop: [1000, 1],
        itemsDesktopSmall: [900, 1],
        itemsTablet: [600, 1],
        itemsMobile: false
    });
    $(".player-next").on('click', function () {
        owl.trigger('owl.next');
    })
    $(".player-prev").on('click', function () {
        owl.trigger('owl.prev');
    })
})(jQuery);

/* === RECENT RESULT === */
(function($){

    "use strict"; // Start of use strict

    var owl = $("#recent-result");
    owl.owlCarousel({
        items: 1,
        itemsDesktop: [1000, 1],
        itemsDesktopSmall: [900, 1],
        itemsTablet: [600, 1],
        itemsMobile: false
    });
    $(".recent-re-next").on('click', function () {
        owl.trigger('owl.next');
    })
    $(".recent-re-prev").on('click', function () {
        owl.trigger('owl.prev');
    })
})(jQuery);

/* === CLUB RANK  === */
(function($){

    "use strict"; // Start of use strict

    var owl = $("#club-rank");
    owl.owlCarousel({
        items: 1,
        itemsDesktop: [1000, 1],
        itemsDesktopSmall: [900, 1],
        itemsTablet: [600, 1],
        itemsMobile: false
    });
    $(".club-rank-next").on('click', function () {
        owl.trigger('owl.next');
    })
    $(".club-rank-perv").on('click', function () {
        owl.trigger('owl.prev');
    })
})(jQuery);

/* === HOT VIDEO  === */
(function($){

    "use strict"; // Start of use strict

    var owl = $("#hot-video");
    owl.owlCarousel({
        items: 4,
        itemsDesktop: [1000, 4],
        itemsDesktopSmall: [900, 3],
        itemsTablet: [600, 1],
        itemsMobile: false
    });
    $(".video-next").on('click', function () {
        owl.trigger('owl.next');
    })
    $(".video-perv").on('click', function () {
        owl.trigger('owl.prev');
    })
})(jQuery);

/* === TWITTER SLIDER === */
(function($){

    "use strict"; // Start of use strict

    var owl = $("#twitter-slide");
    owl.owlCarousel({
        items: 1,
        itemsDesktop: [1000, 1],
        itemsDesktopSmall: [900, 1],
        itemsTablet: [600, 1],
        itemsMobile: false
    });
    $(".twitter-next").on('click', function () {
        owl.trigger('owl.next');
    })
    $(".twitter-perv").on('click', function () {
        owl.trigger('owl.prev');
    })
})(jQuery);

/* === UPDATE NEWS === */
(function($){

    "use strict"; // Start of use strict

    var owl = $("#update-news");
    owl.owlCarousel({
        items: 3,
        itemsDesktop: [1000, 2],
        itemsDesktopSmall: [900, 2],
        itemsTablet: [600, 1],
        itemsMobile: false
    });
    $(".update-news-next").on('click', function () {
        owl.trigger('owl.next');
    })
    $(".update-news-perv").on('click', function () {
        owl.trigger('owl.prev');
    })
})(jQuery);

/* === NEXT MATCH === */
(function($){

    "use strict"; // Start of use strict

    var owl = $("#next-match");
    owl.owlCarousel({
        items: 1,
        itemsDesktop: [1000, 1],
        itemsDesktopSmall: [900, 1],
        itemsTablet: [600, 1],
        itemsMobile: false
    });
    $(".next-match-next").on('click', function () {
        owl.trigger('owl.next');
    })
    $(".next-match-perv").on('click', function () {
        owl.trigger('owl.prev');
    })
})(jQuery);

/* === LATEST BLOG === */
(function($){

    "use strict"; // Start of use strict

    var owl = $("#latest-blog");
    owl.owlCarousel({
        items: 2,
        itemsDesktop: [1000, 2],
        itemsDesktopSmall: [900, 2],
        itemsTablet: [600, 1],
        itemsMobile: false
    });
    $(".next-match-next").on('click', function () {
        owl.trigger('owl.next');
    })
    $(".next-match-perv").on('click', function () {
        owl.trigger('owl.prev');
    })
})(jQuery);

/* === RECENT PRODUCT === */
(function($){

    "use strict"; // Start of use strict

    var owl = $("#recent-product");
    owl.owlCarousel({
        items: 4,
        itemsDesktop: [1000, 3],
        itemsDesktopSmall: [900, 2],
        itemsTablet: [600, 1],
        itemsMobile: false
    });
    $(".next-match-next").on('click', function () {
        owl.trigger('owl.next');
    })
    $(".next-match-perv").on('click', function () {
        owl.trigger('owl.prev');
    })
})(jQuery);



/* GOOGLE MAP */
"use strict"; // Start of use strict
function initGoogleMaps() {
    // Basic options for a simple Google Map
    // For more options see: https://developers.google.com/maps/documentation/javascript/reference#MapOptions
    var mapOptions = {
        // How zoomed in you want the map to start at (always required)
        zoom: 11,
        scrollwheel: false,
        navigationControl: false,
        mapTypeControl: false,
        scaleControl: false,
        draggable: false,
        // The latitude and longitude to center the map (always required)
        center: new google.maps.LatLng(40.7127, -74.0059), // New york

        // How you would like to style the map.
        // This is where you would paste any style found on Snazzy Maps.
        styles: [{"featureType": "water", "elementType": "geometry", "stylers": [{"color": "#e9e9e9"}, {"lightness": 17}]}, {"featureType": "landscape", "elementType": "geometry", "stylers": [{"color": "#f5f5f5"}, {"lightness": 20}]}, {"featureType": "road.highway", "elementType": "geometry.fill", "stylers": [{"color": "#ffffff"}, {"lightness": 17}]}, {"featureType": "road.highway", "elementType": "geometry.stroke", "stylers": [{"color": "#ffffff"}, {"lightness": 29}, {"weight": 0.2}]}, {"featureType": "road.arterial", "elementType": "geometry", "stylers": [{"color": "#ffffff"}, {"lightness": 18}]}, {"featureType": "road.local", "elementType": "geometry", "stylers": [{"color": "#ffffff"}, {"lightness": 16}]}, {"featureType": "poi", "elementType": "geometry", "stylers": [{"color": "#f5f5f5"}, {"lightness": 21}]}, {"featureType": "poi.park", "elementType": "geometry", "stylers": [{"color": "#dedede"}, {"lightness": 21}]}, {"elementType": "labels.text.stroke", "stylers": [{"visibility": "on"}, {"color": "#ffffff"}, {"lightness": 16}]}, {"elementType": "labels.text.fill", "stylers": [{"saturation": 36}, {"color": "#333333"}, {"lightness": 40}]}, {"elementType": "labels.icon", "stylers": [{"visibility": "off"}]}, {"featureType": "transit", "elementType": "geometry", "stylers": [{"color": "#f2f2f2"}, {"lightness": 19}]}, {"featureType": "administrative", "elementType": "geometry.fill", "stylers": [{"color": "#fefefe"}, {"lightness": 20}]}, {"featureType": "administrative", "elementType": "geometry.stroke", "stylers": [{"color": "#fefefe"}, {"lightness": 17}, {"weight": 1.2}]}]
    };

    // Get the HTML DOM element that will contain your map
    // We are using a div with id="map" seen below in the <body>
    var mapElement = document.getElementById('map');

    // Create the Google Map using our element and options defined above
    var map = new google.maps.Map(mapElement, mapOptions);

    // Let's also add a marker while we're at it
    var marker = new google.maps.Marker({
        position: new google.maps.LatLng(40.7127, -74.0059),
        map: map,
        title: 'Find us here!'
    });
}
if ($("#map").length > 0) {
    // When the window has finished loading create our google map below
    var googleMaps = google.maps.event.addDomListener(window, 'load', initGoogleMaps);
}

/* === RANGE SLIDER === */
$( function() {

    "use strict"; // Start of use strict

$( "#slider-range" ).slider({
range: true,
min: 0,
max: 500,
values: [ 75, 300 ],
slide: function( event, ui ) {
$( "#rangeA" ).val( "$" + ui.values[ 0 ] );
$( "#rangeB" ).val( "$" + ui.values[ 1 ] );
}
});
$( "#rangeA" ).val( "$" + $( "#slider-range" ).slider( "values", 0 ) );
$( "#rangeB" ).val( "$" + $( "#slider-range" ).slider( "values", 1 ) );
});




