var app = angular.module('myProductApp', []);

app.config(['$httpProvider', function ($httpProvider) {
    if (!$httpProvider.defaults.headers.get) {
        $httpProvider.defaults.headers.get = {};
    }
    $httpProvider.defaults.headers.get['If-Modified-Since'] = 'Mon, 26 Jul 1997 05:00:00 GMT';
    $httpProvider.defaults.headers.get['Cache-Control'] = 'no-cache';
    $httpProvider.defaults.headers.get['Pragma'] = 'no-cache';
}
]);

app.controller('productCtrl', function ($scope, $http) {

    $scope.showEditProduct = function (data) {
        $scope.edicion = data;
        $("#myModal").modal('toggle');
        $("#myModal").modal('show');
    };

    $scope.editProduct = function () {
        let edit = $scope.edicion;
        let nombre = $scope.newName;
        $.ajax({
            type: "POST",
            url: "/Home/EditarProducto",
            content: "application/json; charset=utf-8",
            dataType: "json",
            data: { edit: edit, nombre: nombre },
            success: function (d) {
                if (d.success == true) {
                    alert("Cambios Guardados");
                    window.location.reload();
                } else {
                    alert("Cambios no guardados");
                }
            },
            error: function (xhr, txtStatus, errorThrown) {
                alert("Error en la petición");
            }
        })
    };

    $scope.deleteProduct = function (data) {
        let deletes = data;
        $.ajax({
            type: "POST",
            url: "/Home/EliminarProducto",
            content: "application/json; charset=utf-8",
            dataType: "json",
            data: { deletes: deletes },
            success: function (d) {
                if (d.success == true) {
                    alert("Producto Eliminado");
                    window.location.reload();
                } else {
                    alert("Producto NO Eliminado");
                }
            },
            error: function (xhr, txtStatus, errorThrown) {
                alert("Error en la petición");
            }
        })
    };

});

