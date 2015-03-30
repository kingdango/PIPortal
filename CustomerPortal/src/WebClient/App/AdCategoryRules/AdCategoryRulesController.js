var app = angular.module("customerPortal");

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
