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

}]);