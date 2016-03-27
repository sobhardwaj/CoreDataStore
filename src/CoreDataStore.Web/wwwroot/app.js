!function() {
    var a = angular.module("mainApp", ["ui.router"]);

    a.config([
        "$stateProvider", "$urlRouterProvider", function(a, b) {
            b.otherwise("/home/overview"), a.state("home",
                { "abstract": !0, url: "/home", templateUrl: "/templates/home.html" })
                .state("overview",
                {
                    parent: "home",
                    url: "/overview",
                    templateUrl: "/templates/overview.html",
                    controller: "OverviewController",
                    resolve: {
                        DataEventRecordsService: "DataEventRecordsService",
                        dataEventRecords: ["DataEventRecordsService", function(a) { return a.GetDataEventRecords() }]
                    }
                })
                .state("details",
                {
                    parent: "overview",
                    url: "/details/:id",
                    templateUrl: "/templates/details.html",
                    controller: "DetailsController",
                    resolve: {
                        DataEventRecordsService: "DataEventRecordsService",
                        dataEventRecord: [
                            "DataEventRecordsService", "$stateParams", function(a, b) {
                                var c = b.id;
                                return console.log(b.id), a.GetDataEventRecord({ id: c })
                            }
                        ]
                    }
                })
                .state("create",
                {
                    parent: "overview",
                    url: "/create",
                    templateUrl: "/templates/create.html",
                    controller: "DetailsController",
                    resolve: {
                        dataEventRecord: [
                            function() {
                                return { Id: "", Name: "", Description: "", Timestamp: "2015-08-28T09:57:32.4669632" }
                            }
                        ]
                    }
                })
        }
    ]), a.run([
        "$rootScope", function(a) {
            a.$on("$stateChangeError",
                function(a, b, c, d, e, f) {
                    console.log(a), console.log(b), console.log(c), console.log(d), console.log(e), console.log(f)
                }), a.$on("$stateNotFound",
                function(a, b, c, d) { console.log(a), console.log(b), console.log(c), console.log(d) })
        }
    ]);
}(), function() {
    "use strict";

    function a(a, b, c, d, e) {
        b.info("DetailsController called"), a
                .message = "dataEventRecord Create, Update or Delete", a.DataEventRecordsService = d, a.state = e,
            a.dataEventRecord = c, a.Update = function() {
                b.info("Updating"), b.info(c), a.DataEventRecordsService.UpdateDataEventRecord(c), a.state
                    .go("overview")
            }, a.Create = function() {
                b.info("Creating"), b.info(c), a.DataEventRecordsService.AddDataEventRecord(c), a.state.go("overview")
            }
    }

    var b = angular.module("mainApp");
    b.controller("DetailsController", ["$scope", "$log", "dataEventRecord", "DataEventRecordsService", "$state", a])
}(), function() {
    "use strict";

    function a(a, b, c, d) {
        b.info("OverviewController called"), a.message = "Overview", a.DataEventRecordsService = d, b
            .info(c), a.dataEventRecords = c, a.Delete = function(c) {
            b.info("deleting"), a.DataEventRecordsService.DeleteDataEventRecord(c)
        }
    }

    var b = angular.module("mainApp");
    b.controller("OverviewController", ["$scope", "$log", "dataEventRecords", "DataEventRecordsService", a])
}(), function() {
    "use strict";

    function a(a, b, c) {
        b.info("DataEventRecordsService called");
        var d = function(b) {
                var d = c.defer();
                return console.log("addDataEventRecord started"), console
                    .log(b), a({ url: "api/DataEventRecords", method: "POST", data: b })
                    .success(function(a) { d.resolve(a) })
                    .error(function(a) { d.reject(a) }), d.promise
            },
            e = function(b) {
                var d = c.defer();
                return console.log("addDataEventRecord started"), console
                    .log(b), a({ url: "api/DataEventRecords/" + b.Id, method: "PUT", data: b })
                    .success(function(a) { d.resolve(a) })
                    .error(function(a) { d.reject(a) }), d.promise
            },
            f = function(b) {
                var d = c.defer();
                return console.log("DeleteDataEventRecord begin"), console
                    .log(b), a({ url: "api/DataEventRecords/" + b, method: "DELETE", data: "" })
                    .success(function(a) { d.resolve(a) })
                    .error(function(a) { d.reject(a) }), d.promise
            },
            g = function() {
                return b
                    .info("DataEventRecordService DataEventRecords called"),
                a.get("/api/DataEventRecords").then(function(a) { return a.data })
            },
            h = function(c) {
                return b.info("DataEventRecordService GetDataEventRecord called: " + c.id), b
                    .info(c), a.get("/api/DataEventRecords/" + c.id).then(function(a) { return a.data })
            };
        return{
            AddDataEventRecord: d,
            UpdateDataEventRecord: e,
            DeleteDataEventRecord: f,
            GetDataEventRecords: g,
            GetDataEventRecord: h
        }
    }

    var b = angular.module("mainApp");
    b.factory("DataEventRecordsService", ["$http", "$log", "$q", a])
}();