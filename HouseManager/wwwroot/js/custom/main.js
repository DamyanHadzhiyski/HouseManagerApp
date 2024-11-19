(function ($) {
    "use strict";

    // Sidebar Toggler
    $('.sidebar-toggler').click(function () {
        $('.sidebar, .content').toggleClass("open");
        return false;
    });
})(jQuery);

function store() {
    sessionStorage.setItem('house-organization', '1')
}