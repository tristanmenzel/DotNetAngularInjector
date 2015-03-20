(function() {
    'use strict';

    angular
        .module('app')
        .controller('LayoutController', LayoutController);

    
    /*inject(LayoutController)*/
    function
        LayoutController
        (
        $log,
                    $state
        ) {
        var vm = this;

        activate(); 

        function activate() {
            $log.info('LayoutController Activated');
            $log.info('The state is: ' + $state.current.name);
        }
    }
})();