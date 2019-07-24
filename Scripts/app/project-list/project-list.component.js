angular.
    module('projectListModule').
    component('projectList', {  // This name is what AngularJS uses to match to the `<phone-list>` element.
        templateUrl: 'project-list/project-list.template.html',
        controller: function ProjectListController($http) {
            var self = this;
            this.orderProp = 'age';

            /*
            this.projects = [
                {
                    id: 1,
                    name: 'Nexus SS',
                    snippet: 'Fast just got faster with Nexus S.',
                    age: 2
                }, {
                    id: 2,
                    name: 'Motorola XOOM™ with Wi-Fi',
                    snippet: 'The Next, Next Generation tablet.',
                    age: 1
                }, {
                    id: 3,
                    name: 'MOTOROLA XOOM™',
                    snippet: 'The Next, Next Generation tablet.',
                    age: 3
                }
            ];
            */



            $http.get('local-data/projects.json').then(function (response) {
                self.projects = response.data;
            });

            console.log("Hello world!");


        }
    });