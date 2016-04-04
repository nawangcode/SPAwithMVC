(function () {
    'use strict';
    var controllerId = 'dashboard';
    angular.module('app').controller(controllerId, ['common', '$scope', '$http','datacontext', dashboard]);

    function dashboard(common, $scope, $http, datacontext) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);

        var vm = this;
        vm.news = {
            title: 'R5 Diag Hot Towel Angular',
            description: 'how to use SPA with MVC '
        };
        vm.messageCount = 0;
        vm.people = [];
        vm.title = 'Dashboard';

        activate();

        function activate() {
            var promises = [getMessageCount(), getPeople()];
            common.activateController(promises, controllerId)
                .then(function () { log('Activated Dashboard View'); });
        }

        function getMessageCount() {
            return datacontext.getMessageCount().then(function (data) {
                return vm.messageCount = data;
            });
        }

        function getPeople() {
            $http.get("/api/vwEvents").success(function (data, status, headers, config) {
                vm.people = data;
                vm.isBusy = false;
            }).error(function (data, status, headers, config) {
                log(error);
                vm.isBusy = false;
            });
        }
    }
})();