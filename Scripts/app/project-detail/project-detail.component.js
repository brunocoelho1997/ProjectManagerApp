angular.
    module('projectDetailModule').
    component('projectDetail', {
        templateUrl: 'project-detail/project-detail.template.html',
        controller: ['$routeParams',
            function projectDetailController($routeParams) {
                this.projectId = $routeParams.projectId;


                console.log("Goodby world!");
            }
        ]
    });