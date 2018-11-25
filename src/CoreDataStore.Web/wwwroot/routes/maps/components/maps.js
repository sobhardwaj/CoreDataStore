"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var maps_1 = require("../services/maps");
var MapsComponent = /** @class */ (function () {
    function MapsComponent(mapsservice) {
        this.mapsservice = mapsservice;
        this.maps = [];
        this.markers = [];
        this.zoom = 12;
        this.scrollwheel = true;
        this.markers.push({ lat: 33.790807, lng: -117.835734, label: '' });
    }
    MapsComponent.prototype.mapChanged = function (mapId) {
        var _this = this;
        this.mapsservice.getMapsId(mapId).subscribe(function (data) {
            _this.features = data.features || [];
            var i = 0;
            _this.markers = [];
            _this.features.forEach(function (f) {
                var map = {};
                if (f.geometry && f.geometry.coordinates) {
                    i++;
                    map.lng = f.geometry.coordinates[0];
                    map.lat = f.geometry.coordinates[1];
                    map.label = String(i);
                    _this.markers.push(map);
                }
            });
        });
    };
    ;
    MapsComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.mapsservice.getMaps().subscribe(function (data) {
            _this.maps = data || [];
            _this.mapId = data[0].id;
            _this.mapChanged(_this.mapId);
        }, function (err) { return console.log(err); });
    };
    MapsComponent = __decorate([
        core_1.Component({
            selector: 'app-google',
            providers: [maps_1.MapsService],
            templateUrl: 'app/routes/maps/components/maps.html'
        }),
        __metadata("design:paramtypes", [maps_1.MapsService])
    ], MapsComponent);
    return MapsComponent;
}());
exports.MapsComponent = MapsComponent;
//# sourceMappingURL=maps.js.map