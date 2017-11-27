import tpl1 from '../views/DIALOG1TMPL.html'
import dialogCtr from '../controller/dialogController'

export default class pageDController {
    constructor ($interval,httpService,utils) {
        this.httpservice = httpService;
        this.ut = utils;
        this.pswflag = false;//是否显示密码
        console.log(this);
    };
    submit () {
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
            if(data == 'success') {
                console.log('success');
                window.location="/pageB";
            }
            else {
                console.log('fail');
            }
        });
    };
    //显示密码按钮绑定事件
    toggleActivation () {
        if (this.pswflag === true) {
            $("#psw_input").attr('type','text');
        }
        else {
            $("#psw_input").attr('type','password');
        }
    };
}
pageDController.$inject = ['$interval','httpService','utils','$location'];