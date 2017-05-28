
var model = kendo.observable({
    mostPopularCars: new kendo.data.DataSource({
        transport: {
            read: {
                url: "../Api/GetMostPopularCars",
                dataType: "json"
            }
        }
    }),
    cars: new kendo.data.DataSource({
        transport: {
            read: {
                url: "../Api/GetCars",
                dataType: "json"
            }
        },
        pageSize: 10
    }),
    showCar: function (event) {
        router.navigate("/car/" + event.data.Id);
    },
    idCar : 0,
    car: {},
    onClick: function () {
        var params = {
            Mark: model.get("mark"),
            Model: model.get("model"),
            Year: model.get("year"),
            Cost: model.get("cost"),
            Valuta: model.get("valuta"),
            Transmission: model.get("transmission"),
            Type: model.get("type"),
            Amount: model.get("amount"),
            Mileage: model.get("mileage"),
        };
        $.post('../Api/Search',
            params,
            function (data) {
                model.set("cars", data);
                var query = "";
                for (key in params) {
                    query += key,
                        query += "=";
                    query += params[key];
                    query += "&";
                }
                router.navigate("/search?" + query);
            });
    },
    marks: new kendo.data.DataSource({
        transport: {
            read: {
                url: "../Api/GetMarks",
                dataType: "json"
            }
        }
    }),
    valutas: [
        "Белорусские рубли",
        "Доллары",
        "Евро"
    ],
    mark: "",
    model: "",
    year: 1950,
    cost: 9999,
    valuta: "Белорусские рубли",
    mileage: 9999999,
    amount: 0,
    transmission: true,
    type: "Дизель",
    state: "Новое",
    file:'',
    newModel: "",
    isVisible: false,
    resultModels: [],
    onSelect: function () {
        $.get('../Api/GetModels', function (data) {     
            model.set("resultModels", data[model.get("mark")]);
            model.set("model", "");
        });
    },
    queryParams: {},
    fill: function (event) {
        var tmpData = this.get("resultModels");
        tmpData.push(this.get("newModel"));
        this.set("resultModels", tmpData);
    },

    show: function () {
        if (this.get("isVisible")) {
            this.set("isVisible", false);
        }
        else {
            this.set("isVisible", true);
        }

    },
    sendNewCar: function () {
        console.log(model.get("file"));
        var params = {
            Mark: model.get("mark"),
            Model: model.get("model"),
            Year: model.get("year"),
            Cost: model.get("cost"),
            Valuta: model.get("valuta"),
            Transmission: model.get("transmission"),
            Type: model.get("type"),
            State: model.get("state"),
            Amount: model.get("amount"),
            Mileage: model.get("mileage"),
            File:model.get("file")
        };
        $.post('../Api/Create',
            params,
            function (data) {
                alert("Добавлено!");
            });
    }
});

kendo.bind($("#view"), model);

var router = new kendo.Router();
        var layoutUser = new kendo.Layout('indexUser');
        

        var viewMain = new kendo.View("main",{model: model });
        var viewSearch = new kendo.View("search", { model: model });
        var viewCar = new kendo.View("car", { model: model });

        layoutUser.render($("#app"));

        router.route("/", function () {
            layoutUser.showIn("#content", viewMain);
        });

        router.route("/admin", function () {
            layoutUser.showIn("#content", viewMain);
        });

      


        router.route("/search", function (params) {
            model.set("queryParams", params); 
            layoutUser.showIn("#content", viewSearch);
            $.post('../Api/Search',
                params,
                function (data) {
                    model.set("cars", data);
                });
        });

        router.route("/car/:id", function (id) {
            $.get('../Api/GetCar/'+id, function (data) {
                model.set("car",data);
                layoutUser.showIn("#content", viewCar);
            });
            
        });

       

        $(function () {
        router.start();
    });