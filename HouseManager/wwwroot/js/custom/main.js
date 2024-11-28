function getHouseOrg() {
    var e = document.getElementById("houseOrgSelect");
    var id = e.value;
    location.href = "/HouseOrganizations/Manage/" + id;
};