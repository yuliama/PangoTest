app.controller('calculatorCtrl', function ($scope, $http, $q) {
    $scope.resStyle = "white";
    $scope.postData = function () {

        $scope.queryType = getQueryType();
        
        console.log('result type: ' + $scope.queryType);


        $scope.data = {
            "num1": $scope.num1,
            "num2": $scope.num2,
            "op": $scope.op, 
            "queryType": $scope.queryType
        };
        console.log('input data: ' + JSON.stringify($scope.data));

        $http.post('api/home/CalculateResult', JSON.stringify($scope.data)).then(function (result) {

            let res = JSON.parse(result.data);
            $scope.result = res.result;
            $scope.resStyle = res.style;
            console.log("res: " + $scope.result + " style: " + $scope.resStyle);
        });
    }
    function getQueryType() {

        var hash;
        var hashes = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
        for (var i = 0; i < hashes.length; i++) {
            hash = hashes[i].split('=');
                return hash[1];
        }
        return '';
    }
    $scope.operators = [];
    $scope.GetOperators = function () {
        $http.get('api/home/GetOperators').then(function (result) {
            //console.log("Operators: " + JSON.parse(result.data).operators);
            $scope.operators = JSON.parse(result.data).operators;
        });
    }();

    

});  