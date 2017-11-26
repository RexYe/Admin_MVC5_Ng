import tpl1 from '../views/DIALOG1TMPL.html'
import dialogCtr from '../controller/dialogController'

export default class pageDController {
    constructor ($interval,httpService,utils) {
        this.httpservice = httpService;
        this.ut = utils;
        this.pswflag = false;//是否显示密码
    };
    submit () {
        //console.log(this.query);
        var myInit = {
            method: 'POST',
            body:"login_name="+this.query.userName+"&password="+this.query.password,
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded'
            },
        };
       fetch('http://localhost:52273/api/values/userlogin2',myInit)
       .then(function(response) {
            return response.json();
        })
       .then(function(data) {
            //console.log('data',data);
            if(data[0] == null){
                console.log('fail');
                $location.path('../views/pageC.html');
            }
            else{
                console.log('success');
            }
        })
       .catch(function(e) {
            console.log("Oops, error");
        });
    };
    //显示密码绑定事件
    toggleActivation () {
        console.log(this);
    };
}
pageDController.$inject = ['$interval','httpService','utils'];