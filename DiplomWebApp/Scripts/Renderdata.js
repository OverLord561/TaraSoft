$(document).ready(function () {

    new Render();




    function GetOwners(data) {


        $.getJSON("/Home/GetOwners", function (data) {
            var items = [];
            RenderOwners(data);
        });
    };


    function RenderOwners(data) {
        $.each(data, function (key, val) {

            var table = document.getElementById("Owners");
            var row = document.createElement('tr');
            var td = document.createElement('td');
            td.innerHTML = val["Name"];
            td.className = "searchInfoOwners";
            td.dataset["firmId"] = val["FirmId"];
            td.dataset["id"] = val["Id"];
            row.appendChild(td);

            table.appendChild(row);
        });
        $(".searchInfoOwners").on("click", function (event) {

            GetProducts($(this).data("id"));
            var name = this.innerHTML;

            $("#OwnerDetails").text(name);
            $("#NameofOwner").text("Товари: " + name);
            
        });
        $(".searchInfoOwners").hover(function (event) {
            $(this).css("background-color", "#f5f5f5");
        });
        $(".searchInfoOwners").mouseleave(function (event) {
            $(this).css("background-color", "white");
        });
    }

    function SortOwners(event, id) {
        $.post("/Home/GetOwners", { firmId: id }).done(function (data) {
            $("#Owners").empty();            
            
            RenderOwners(data)
        }, "json");
    }


    function GetFirms() {

        $.getJSON("/Home/GetFirms", function (data) {
            RenderFirms(data);
        });
    };
    function RenderFirms(data) {
        $.each(data, function (key, val) {

            var table = document.getElementById("Firms");
            var row = document.createElement('tr');
            var td = document.createElement('td');
            td.innerHTML = val["Name"];
            td.className = "searchInfoFirms";
            td.dataset["id"] = val["Id"];
            row.appendChild(td);

            table.appendChild(row);

        });
        $(".searchInfoFirms").on("click", function () {
            var name = this.innerHTML;
            $("#Products").empty();
            $("#NameOfFirm").text("Власники. " + name);
            $("#FirmDetails").text(name);
            $("#OwnerDetails").text("Власник");
            SortOwners(event, $(this).data("id"));
            GetFirmById($(this).data("id"));
        });

        $(".searchInfoFirms").hover(function (event) {
            $(this).css("background-color", "#f5f5f5");
        });
        $(".searchInfoFirms").mouseleave(function (event) {
            $(this).css("background-color", "white");
        });
    }


    function GetFirmById(id)
    {
        $("#Products").empty();
        $.post("/Home/GetFirms", { id: id }).done(function (data) {
            //$.each(data, function (key, val) {
                $("#f_adr").text(data["Adress"]);
                $("#f_tel").text(data["Phone"]);
                $("#f_cod").text(data["Code"]);
            //});
        }, "json");
    };
    function GetProducts(ownerid) {
        $.post("/Home/GetProducts", { ownerid: ownerid }).done(function (data) {
            $("#Products").empty();
            RenderProducts(data)
        }, "json");


        $.post("/Home/GetOwnerById", { ownerid: ownerid }).done(function (data) {
           
            $("#o_tel").text(data["Telephone"]);
            $("#o_cod").text(data["Code"]);
        }, "json");
        


    };

    function RenderProducts(data) {
        $.each(data, function (key, val) {

            var table = document.getElementById("Products");
            var row = document.createElement('tr');
            for (var prop in val) {
                var td = document.createElement('td');
                td.innerHTML = val[prop];
                td.className = "searchInforProducts";
                row.appendChild(td);
            }           

            table.appendChild(row);

        });
        

        $(".searchInforProducts").hover(function (event) {
            $(this).css("background-color", "#f5f5f5");
        });
        $(".searchInforProducts").mouseleave(function (event) {
            $(this).css("background-color", "white");
        });
    };

    function Render() {

        GetFirms();
        GetOwners();


    };




});

