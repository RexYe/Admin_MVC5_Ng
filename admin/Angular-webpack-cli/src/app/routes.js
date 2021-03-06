import pageA from "../views/pageA.html";
import pageB from "../views/pageB.html";
import pageC from "../views/pageC.html";
import login from "../views/login.html";
import signup from "../views/signup.html";
import echartcontroller from "../controller/echartcontroller"
import pageCController from "../controller/pageCController"
import loginController from "../controller/loginController"
import signupController from "../controller/signupController"

function config($routeProvider,$locationProvider){
  $routeProvider
    .when('/',{
       template:pageA,
       controller:'',
       controllerAs:'vm'
    })
    .when('/pageA',{
      template:pageA,
      controller:"",
      controllerAs:'vm'
    })
    .when('/pageB', {
      template:pageB,
      controller:'echartcontroller',
      controllerAs:'ec'
    })
    .when('/pageC',{
      template:pageC,
      controller:"pageCController",
      controllerAs:'pc'
    })
    .when('/login',{
      template:login,
      controller:"loginController",
      controllerAs:'login'
    })
    .when('/signup',{
      template:signup,
      controller:"signupController",
      controllerAs:'signup'
    })
    .otherwise({
    	redirectTo:'/pageA'}
    );
     $locationProvider.html5Mode(true);
}

config.$inject = ['$routeProvider','$locationProvider'];
export default config;