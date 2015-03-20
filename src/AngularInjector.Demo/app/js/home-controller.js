(function() {
    'use strict';

    angular
        .module('app')
        .controller('HomeController', HomeController);

    
    /*inject(HomeController)*/
    function HomeController($log) {

        var vm = this;

        activate(); 

        function activate() {
            $log.info('HomeController Activated');
        }
    }
})();