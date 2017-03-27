(function (angular) {
    var app = angular.module("app", ['ngSanitize', 'ngAnimate']);

    app.controller("MainController", ["$scope", "$http", "$log", "$location", "$sce", function MainController($scope, $http, $log, $location, $sce) {
        $scope.loading = true;

        function CurrentPageUrl() {
            var currentUrl = window.location.pathname;
            $scope.Url = currentUrl;
        };
        CurrentPageUrl();

        //Categories
        function GetAllCategory() {
            $http.post("/Category/GetAllCategory").success(function (data) {
                $scope.AllCategoryList = data;
            }).error(function (ex) {
                console.log(ex);
            });
        };
        if ($scope.Url == "/CategoryList") {
            GetAllCategory();
        }

        //On Add Page
        $scope.GoAddPage = function () {
            if ($("#btnGoAddPage").val() == "Add") {
                $("#update").hide();
                $("#add").show();
            }
        };

        //Add Category
        $scope.AddCategory = function () {
            if ($("#btnAddCategory").val() == "Add") {
                var data = { CategoryName: $scope.AddCategoryName, Order: $scope.AddOrder, IsActive: $scope.AddIsActive };
                $http.post("/Category/AddCategory", data).success(function () {
                    window.location = "/CategoryList";
                }).error(function (ex) {
                    console.log(ex);
                    $scope.singUpMessage = "Mesaj Gönderme İşlemi Sırasında Beklenmedik Bir Hata Oluştu !";
                });
            }
        };

        //Edit Category Get Data 
        $scope.EditCategory = function UpdateForCategory(Id) {
            if ($("#btnEditCategory").val() == "Edit") {
                $("#add").hide();
                $("#update").show();
                var data = { Id: Id };
                $http.post("/Category/GetCategory/", data).success(function (data) {
                    $scope.Id = data.CategoryID;
                    $scope.UptCategoryName = data.CategoryName;
                    $scope.UptOrder = data.Order;
                    $scope.UptIsActive = data.IsActive;
                }).error(function (ex) {
                    $log.info(ex);
                })
            }
        };

        //Update Category
        $scope.UpdateCategory = function UpdateCategory(Id) {
            if ($("#btnUpdateCategory").val() == "Update") {
                var data = {
                    CategoryID: Id, CategoryName: $scope.UptCategoryName, Order: $scope.UptOrder, IsActive: $scope.UptIsActive
                }
                $http.post("/Category/UpdateCategory/", data).success(function (data) {
                    $scope.UptCategoryName = data.CategoryName;
                    $scope.UptOrder = data.Order;
                    $scope.UptIsActive = data.UptIsActive;
                    GetAllCategory();
                }).error(function (ex) {
                    $log.info(ex);
                })
            }
        };

        //Delete Category
        $scope.DeleteCategory = function (Id) {
            var data = { Id: Id };
            $http.post("/Category/DeleteCategory", data).success(function () {
                window.location = "/CategoryList";
            }).error(function (ex) {
                console.log(ex);
            })
        };

        //Products
        function GetAllProduct() {
            $http.post("/Product/GetAllProduct").success(function (data) {
                $scope.AllProductList = data;
            }).error(function (ex) {
                console.log(ex);
            });
        };
        if ($scope.Url == "/ProductList") {
            GetAllProduct();
        }

        //On Add Page
        $scope.OnAddProduct = function () {
            if ($("#btnOnAddProduct").val() == "Add") {
                $("#update").hide();
                $("#add").show();
                GetAllCategory();
            }
        };

        //Add Product
        $scope.AddProduct = function () {
            if ($("#btnAddProduct").val() == "Add") {
                var data = { CategoryID : $scope.categories, ProductName: $scope.AddProductName, UnitInStock: $scope.AddStock, Price: $scope.AddPrice };
                $http.post("/Product/AddProduct", data).success(function () {
                    window.location = "/ProductList";
                }).error(function (ex) {
                    console.log(ex);
                    $scope.singUpMessage = "Mesaj Gönderme İşlemi Sırasında Beklenmedik Bir Hata Oluştu !";
                });
            }
        };

        //Edit Product Get Data 
        $scope.EditProduct = function UpdateForProduct(Id) {
            if ($("#btnEditProduct").val() == "Edit") {
                $("#add").hide();
                $("#update").show();
                GetAllCategory();
                var data = { Id: Id };
                $http.post("/Product/GetProduct/", data).success(function (data) {
                    $scope.UptCategoryID = data.CategoryID;
                    $scope.Id = data.ProductID;
                    $scope.UptProductName = data.ProductName;
                    $scope.UptStock = data.UnitInStock;
                    $scope.UptPrice = data.Price;
                    $scope.PriceVat = data.PriceVat
                }).error(function (ex) {
                    $log.info(ex);
                })
            }
        };

        //Update Product
        $scope.UpdateProduct = function UpdateProduct(Id) {
            if ($("#btnUpdateProduct").val() == "Update") {
                var data = {
                    CategoryID: $scope.UptCategoryID, ProductID: Id, ProductName: $scope.UptProductName, UnitInStock: $scope.UptStock, Price: $scope.UptPrice
                }
                $http.post("/Product/UpdateProduct/", data).success(function (data) {
                    $scope.UptProductName = data.ProductName;
                    $scope.UptStock = data.UnitInStock;
                    $scope.UptPrice = data.Price;
                    $scope.UptPriceVat = data.PriceVat;
                    window.location = "/ProductList";
                }).error(function (ex) {
                    $log.info(ex);
                })
            }
        };

        //Delete Product
        $scope.DeleteProduct = function DeleteForProduct (Id) {
            var data = { Id: Id };
            $http.post("/Product/DeleteProduct", data).success(function () {
                window.location = "/ProductList";
            }).error(function (ex) {
                console.log(ex);
            })
        };

    }]);

})(angular);