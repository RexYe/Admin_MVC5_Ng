
export default class signupController {
    constructor($interval,httpService,utils) {
        this.httpservice = httpService;
        this.ut = utils;
        this.interval = $interval;
        this.pswflag = false;//是否显示密码
    }
    submit () {

        if (this.codebyuser !== this.code) {
            alert('验证码不正确')
        }
        else if (this.query.userName == null || this.query.password == null) {
            alert('用户名或者密码不正确')
        }
        else {
            var myInit = {
            method: 'POST',
            body:"login_name="+this.query.userName+"&password="+this.query.password,
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded'
            },
        };
        fetch('http://localhost:52273/api/values/usersignup',myInit)
        .then(function(response) {
            return response.json();
        })
        .then(function(data) {
            if(data == 'account add success') {
                alert('注册成功');
                window.location="/pageB?state=signupsuccess";
            }
            else if (data == 'username exist') {
                alert('用户名已存在');
            }
            else {
                console.log('fail');
            }
        });
        }
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
    createCode() {
        const t = this;
        var code = '';
        var codeLength = 4; //验证码的长度
        var checkCode = document.getElementById("code");
        var codeChars = new Array(0, 1, 2, 3, 4, 5, 6, 7, 8, 9)
        for (var i = 0; i < codeLength; i++) {
            var charNum = Math.floor(Math.random() * 10)
            code += codeChars[charNum]
        }
        t.code = code;
        if (checkCode) {
            checkCode.innerHTML = t.code;
        }
    }
}
signupController.$inject = ['$interval','httpService','utils'];