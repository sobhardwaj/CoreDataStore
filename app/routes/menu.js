"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var Home = {
    text: 'Home',
    link: '/home',
    icon: 'icon-home'
};
var Maps = {
    text: 'Maps',
    link: '/maps',
    icon: 'icon-map'
};
var Diagnostics = {
    text: 'Diagnostics',
    link: '/diagnostics',
    icon: 'icon-speedometer'
};
var References = {
    text: 'LPC Reports',
    link: '/references',
    icon: 'icon-grid'
};
var Elements = {
    text: 'Elements',
    link: '/elements',
    icon: 'icon-chemistry',
    submenu: [{
            text: 'Buttons',
            link: '/elements/buttons'
        }, {
            text: 'Interaction',
            link: '/elements/interaction'
        }, {
            text: 'Notification',
            link: '/elements/notification'
        }, {
            text: 'Spinners',
            link: '/elements/spinners'
        }, {
            text: 'Dropdown',
            link: '/elements/dropdown'
        }, {
            text: 'Nav Tree',
            link: '/elements/navtree'
        }, {
            text: 'Sortable',
            link: '/elements/sortable'
        }, {
            text: 'Grid',
            link: '/elements/grid'
        }, {
            text: 'Grid Masonry',
            link: '/elements/gridmasonry'
        }, {
            text: 'Typography',
            link: '/elements/typography'
        }, {
            text: 'Font Icons',
            link: '/elements/iconsfont'
        }, {
            text: 'Weahter Icons',
            link: '/elements/iconsweather'
        }, {
            text: 'Colors',
            link: '/elements/colors'
        }, {
            text: 'Infinite Scroll',
            link: '/elements/infinitescroll'
        }]
};
var Forms = {
    text: 'Forms',
    link: '/forms',
    icon: 'icon-note',
    submenu: [{
            text: 'Standard',
            link: '/forms/standard'
        }, {
            text: 'Extended',
            link: '/forms/extended'
        }, {
            text: 'Validation',
            link: '/forms/validation'
        }, {
            text: 'Upload',
            link: '/forms/upload'
        }, {
            text: 'Image Crop',
            link: '/forms/cropper'
        }]
};
var Charts = {
    text: 'Charts',
    link: '/charts',
    icon: 'icon-graph',
    submenu: [{
            text: 'Flot',
            link: '/charts/flot'
        }, {
            text: 'Radial',
            link: '/charts/radial'
        }, {
            text: 'ChartJS',
            link: '/charts/chartjs'
        }]
};
var Tables = {
    text: 'Tables',
    link: '/tables',
    icon: 'icon-grid',
    submenu: [{
            text: 'Standard',
            link: '/tables/standard'
        }, {
            text: 'Extended',
            link: '/tables/extended'
        }, {
            text: 'Data-Tables',
            link: '/tables/datatable'
        }, {
            text: 'Angular Grid',
            link: '/tables/aggrid'
        }]
};
var Pages = {
    text: 'Pages',
    link: '/pages',
    icon: 'icon-doc',
    submenu: [{
            text: 'Login',
            link: '/login'
        }, {
            text: 'Register',
            link: '/register'
        }, {
            text: 'Recover',
            link: '/recover'
        }, {
            text: 'Lock',
            link: '/lock'
        }, {
            text: '404',
            link: '/404'
        }, {
            text: '500',
            link: '/500'
        }, {
            text: 'Maintenance',
            link: '/maintenance'
        }]
};
var headingMain = {
    text: 'Main Navigation',
    heading: true
};
var headingComponents = {
    text: 'Components',
    heading: true
};
var headingMore = {
    text: 'More',
    heading: true
};
exports.default = [
    headingMain,
    Home,
    References,
    Maps,
    Diagnostics,
];
