(function() {
    var controllerId = 'headerCtrl';
    angular.module('app').controller(controllerId, [
        '$rootScope', '$state', function ($rootScope, $state) {
            var vm = this;

            vm.menu = vtad.nav.menus.MainMenu;
            vm.currentMenuName = $state.current.menu;

            $rootScope.$on('$stateChangeSuccess', function(event, toState, toParams, fromState, fromParams) {
                vm.currentMenuName = toState.menu;
            });
        }
    ]);
})();