angular.
    module('projectDetailModule',[]).
    component('projectDetail', {  // This name is what AngularJS uses to match to the `<phone-list>` element.
        templateUrl: 'project-detail/project-detail.template.html',
        controller: ['$routeParams',
            function ProjectDetailController($routeParams) {
                this.projectId = $routeParams.projectId;


                console.log("Hello world!");
            }
        ]
    });