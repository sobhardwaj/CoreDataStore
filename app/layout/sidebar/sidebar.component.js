System.register(['@angular/core', '../../core/menu/menu.service', '../../core/settings/settings.service', '@angular/router'], function(exports_1, context_1) {
    "use strict";
    var __moduleName = context_1 && context_1.id;
    var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
        var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
        if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
        else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
        return c > 3 && r && Object.defineProperty(target, key, r), r;
    };
    var __metadata = (this && this.__metadata) || function (k, v) {
        if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
    };
    var core_1, menu_service_1, settings_service_1, router_1;
    var SidebarComponent;
    return {
        setters:[
            function (core_1_1) {
                core_1 = core_1_1;
            },
            function (menu_service_1_1) {
                menu_service_1 = menu_service_1_1;
            },
            function (settings_service_1_1) {
                settings_service_1 = settings_service_1_1;
            },
            function (router_1_1) {
                router_1 = router_1_1;
            }],
        execute: function() {
            SidebarComponent = (function () {
                function SidebarComponent(menu, settings, injector) {
                    this.menu = menu;
                    this.settings = settings;
                    this.injector = injector;
                    this.menuItems = menu.getMenu();
                }
                SidebarComponent.prototype.ngOnInit = function () {
                    var _this = this;
                    this.router = this.injector.get(router_1.Router);
                    this.router.events.subscribe(function (val) {
                        // close any submenu opened when route changes
                        _this.removeFloatingNav();
                        // scroll view to top
                        window.scrollTo(0, 0);
                    });
                };
                SidebarComponent.prototype.toggleSubmenuClick = function (event) {
                    var _this = this;
                    if (!this.isSidebarCollapsed() && !this.isSidebarCollapsedText() && !this.isEnabledHover()) {
                        event.preventDefault();
                        var target = $(event.target || event.srcElement || event.currentTarget);
                        var ul_1, anchor = target;
                        // find the UL
                        if (!target.is('a')) {
                            anchor = target.parent('a').first();
                        }
                        ul_1 = anchor.next();
                        // hide other submenus
                        var parentNav_1 = ul_1.parents('.sidebar-subnav');
                        $('.sidebar-subnav').each(function (idx, el) {
                            var $el = $(el);
                            // if element is not a parent or self ul
                            if (!$el.is(parentNav_1) && !$el.is(ul_1)) {
                                _this.closeMenu($el);
                            }
                        });
                        // abort if not UL to process
                        if (!ul_1.length) {
                            return;
                        }
                        // any child menu should start closed
                        ul_1.find('.sidebar-subnav').each(function (idx, el) {
                            _this.closeMenu($(el));
                        });
                        // toggle UL height
                        if (parseInt(ul_1.height(), 0)) {
                            this.closeMenu(ul_1);
                        }
                        else {
                            // expand menu
                            ul_1.on('transitionend', function () {
                                ul_1.height('auto').off('transitionend');
                            }).height(ul_1[0].scrollHeight);
                            // add class to manage animation
                            ul_1.addClass('opening');
                        }
                    }
                };
                // Close menu collapsing height
                SidebarComponent.prototype.closeMenu = function (elem) {
                    elem.height(elem[0].scrollHeight); // set height
                    elem.height(0); // and move to zero to collapse
                    elem.removeClass('opening');
                };
                SidebarComponent.prototype.toggleSubmenuHover = function (event) {
                    var self = this;
                    if (this.isSidebarCollapsed() || this.isSidebarCollapsedText() || this.isEnabledHover()) {
                        event.preventDefault();
                        this.removeFloatingNav();
                        var target = $(event.target || event.srcElement || event.currentTarget);
                        var ul = void 0, anchor = target;
                        // find the UL
                        if (!target.is('a')) {
                            anchor = target.parent('a');
                        }
                        ul = anchor.next();
                        if (!ul.length) {
                            return; // if not submenu return
                        }
                        var $aside = $('.aside');
                        var $asideInner = $aside.children('.aside-inner'); // for top offset calculation
                        var $sidebar = $asideInner.children('.sidebar');
                        var mar = parseInt($asideInner.css('padding-top'), 0) + parseInt($aside.css('padding-top'), 0);
                        var itemTop = ((anchor.parent().position().top) + mar) - $sidebar.scrollTop();
                        var floatingNav_1 = ul.clone().appendTo($aside);
                        var vwHeight = $(window).height();
                        // let itemTop = anchor.position().top || anchor.offset().top;
                        floatingNav_1
                            .removeClass('opening') // necesary for demo if switched between normal//collapsed mode
                            .addClass('nav-floating')
                            .css({
                            position: this.settings.layout.isFixed ? 'fixed' : 'absolute',
                            top: itemTop,
                            bottom: (floatingNav_1.outerHeight(true) + itemTop > vwHeight) ? 0 : 'auto'
                        });
                        floatingNav_1
                            .on('mouseleave', function () { floatingNav_1.remove(); })
                            .find('a').on('click', function (e) {
                            e.preventDefault(); // prevents page reload on click
                            // get the exact route path to navigate
                            self.router.navigate([$(this).attr('route')]);
                        });
                        this.listenForExternalClicks();
                    }
                };
                SidebarComponent.prototype.listenForExternalClicks = function () {
                    var _this = this;
                    var $doc = $(document).on('click.sidebar', function (e) {
                        if (!$(e.target).parents('.aside').length) {
                            _this.removeFloatingNav();
                            $doc.off('click.sidebar');
                        }
                    });
                };
                SidebarComponent.prototype.removeFloatingNav = function () {
                    $('.nav-floating').remove();
                };
                SidebarComponent.prototype.isSidebarCollapsed = function () {
                    return this.settings.layout.isCollapsed;
                };
                SidebarComponent.prototype.isSidebarCollapsedText = function () {
                    return this.settings.layout.isCollapsedText;
                };
                SidebarComponent.prototype.isEnabledHover = function () {
                    return this.settings.layout.asideHover;
                };
                SidebarComponent = __decorate([
                    core_1.Component({
                        selector: 'app-sidebar',
                        templateUrl: 'app/layout/sidebar/sidebar.component.html'
                    }), 
                    __metadata('design:paramtypes', [menu_service_1.MenuService, settings_service_1.SettingsService, core_1.Injector])
                ], SidebarComponent);
                return SidebarComponent;
            }());
            exports_1("SidebarComponent", SidebarComponent);
        }
    }
});
