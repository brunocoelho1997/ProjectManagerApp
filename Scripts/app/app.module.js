
// Define the `phonecatApp` module
var projectsManagerApp = angular.module('projectsManagerApp', [
            // ...which depends on the `projectList` module
    'projectListModule',
    'projectDetailModule',
    'ngRoute'
        ]);

// Define the `PhoneListController` controller on the `phonecatApp` module
/*
projectsManagerApp.controller('ProjectsListController', function ProjectsListController($scope) {
    $scope.projects = [
        {
            id: 1,
            name: 'Nexus S',
            snippet: 'Fast just got faster with Nexus S.'
        }, {
            id: 2,
            name: 'Motorola XOOM™ with Wi-Fi',
            snippet: 'The Next, Next Generation tablet.'
        }, {
            id: 3,
            name: 'MOTOROLA XOOM™',
            snippet: 'The Next, Next Generation tablet.'
        }
    ];
});
*/