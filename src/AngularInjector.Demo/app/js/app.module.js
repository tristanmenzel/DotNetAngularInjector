(function () {
    'use strict';

    angular
        .module('app', [
            'ui.router'
        ])
        .config(registerRoutes)
    .run(function () {
        console.log('running app.run');
    });
    /*inject(registerRoutes)*/
    function registerRoutes($stateProvider, $urlRouterProvider) {
        $stateProvider
            .state('app', {
                'abstract': true,
                url: '/app',
                controller: 'LayoutController as vm',
                templateUrl: '/app/templates/layout.tpl.html'
            })
            .state('app.home', {
                url: '/home',
                templateUrl: '/app/templates/home.tpl.html',
                controller: 'HomeController as vm'
            });
        $urlRouterProvider.otherwise('/app/home');
    }
})();