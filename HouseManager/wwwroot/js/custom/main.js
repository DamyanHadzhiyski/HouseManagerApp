(function ($) {
    "use strict";

    // Sidebar Toggler
    $('.sidebar-toggler').click(function () {
        $('.sidebar, .content').toggleClass("open");
        return false;
    });
})(jQuery);

function getHouseOrg() {
    var e = document.getElementById("houseOrgSelect");
    var id = e.value;
    location.href = "/HouseOrganizations/Manage/" + id;
}