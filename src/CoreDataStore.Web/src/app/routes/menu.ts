const Home = {
  text: 'Home',
  link: '/home',
  icon: 'icon-home'
};

const Dashboard = {
  text: 'Dashboard',
  link: '/dashboard',
  icon: 'icon-speedometer',
  submenu: [{
    text: 'Dashbord v1',
    link: '/dashboard/v1'
  }, {
    text: 'Dashbord v2',
    link: '/dashboard/v2'
  }, {
    text: 'Dashbord v3',
    link: '/dashboard/v3'
  }]
};

const Widgets = {
  text: 'Widgets',
  link: '/widgets',
  icon: 'icon-grid'
};

const Elements = {
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

const Forms = {
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

const Charts = {
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

const Tables = {
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

const Maps = {
  text: 'Maps',
  link: '/maps',
  icon: 'icon-map',
  submenu: [{
    text: 'Google',
    link: '/maps/google'
  }, {
    text: 'Vector',
    link: '/maps/vector'
  }]
};

const Pages = {
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

const headingMain = {
  text: 'Main Navigation',
  heading: true
};

const headingComponents = {
  text: 'Components',
  heading: true
};

const headingMore = {
  text: 'More',
  heading: true
};

export default [
  headingMain,
  Home,
  Dashboard,
  Widgets,
  headingComponents,
  Elements,
  Forms,
  Charts,
  Tables,
  Maps,
  headingMore,
  Pages
];
