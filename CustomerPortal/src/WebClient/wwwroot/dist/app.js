var app = angular.module("customerPortal", []);

app.constant("_", window._);

app.run(function ($rootScope) {
    $rootScope._ = window._;
});


app.service("CurrentUser", ["$http", "$q", function ($http, $q) {

    var currentUserContext;

    this.fetchCurrent = function() {
        
        var deferred = $q.defer();

        if (currentUserContext) {
            deferred.resolve(currentUserContext);
            return deferred.promise;
        }

        return $http.get("/api/UserContext/").then(function (response) {

            var userContext = response.data;

            currentUserContext = {
                User: userContext.User,
                Customer: userContext.Customer
            };

        }).then(function (context) {
            return currentUserContext;
        });

    };

}]);;var app = angular.module("customerPortal");

app.controller("AdCategoryRulesController", ["$scope", "$http", "_", "CurrentUser", function ($scope, $http, _, CurrentUser) {

    $scope.categories = [];
    $scope.adCategoryConfiguration = {};
    $scope.exceptionCategories = [];

    $scope.remove = function(index) {
        $scope.adCategoryConfiguration.ExceptionCategoryIds.splice(index, 1);
        $scope.exceptionCategories = _.filter($scope.categories, function(category) { return _.find($scope.adCategoryConfiguration.ExceptionCategoryIds, function(id) { return id === category.Id; }) });
    };

    $scope.add = function (category) {

        if (_.contains($scope.exceptionCategories, category)) return;

        $scope.adCategoryConfiguration.ExceptionCategoryIds.push(category.Id);
        $scope.exceptionCategories.push(category);
    };

    $scope.getAvailableCategories = function() {
        return _.filter($scope.categories, function(category) { return !_.contains($scope.exceptionCategories, category); });
    }

    return CurrentUser.fetchCurrent().then(function (currentUser) {

        $http.get("/api/" + currentUser.Customer.Namespace + "/AdCategory").then(function (result) {

            $scope.currentUser = currentUser.User;
            $scope.categories = result.data;
            $scope.adCategoryConfiguration = currentUser.Customer.AdCategoryConfiguration;

            var exceptionCategoryIds = $scope.adCategoryConfiguration.ExceptionCategoryIds;
            $scope.exceptionCategories = _.filter($scope.categories, function(category) { return _.find(exceptionCategoryIds, function(id) { return id === category.Id; }) });
            
        });

    });
        
}]);
