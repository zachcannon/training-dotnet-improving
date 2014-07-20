requirejs.config({
    baseURL: 'Scripts',
    paths: {
        'jquery': 'jquery-2.1.1',
        'noty': 'noty/2.0/jquery.noty',
        'noty.themes.default': 'noty/themes/default',
        'noty.layouts.top': 'noty/layouts/top',
    },

    shim: {
        'noty': ['jquery'],
        'noty.themes.default': {
            deps: ['jquery', 'noty'],
            exports: 'jquery'
        },
        'noty.layouts.top': {
            deps: ['jquery', 'noty'],
            exports: 'jquery'
        }
    }
});

// Start loading the main app file. Put all of
// your application logic in there.
requirejs(['index/index']);