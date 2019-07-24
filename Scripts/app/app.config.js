angular.
    module('projectsManagerApp').
    config(['$routeProvider',
        function config($routeProvider) {
            $routeProvider.
                when('/projects', {
                    template: '<project-list></project-list>'
                }).
                when('/projects/:projectId', {
                    template: '<project-detail></project-detail>'
                }).
                otherwise('/projects');
        }
    ]);