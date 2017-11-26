export default class pageEController {
  constructor($interval,httpService,utils) {
    this.httpservice = httpService;
    this.ut = utils;
    this.interval = $interval;
    this.pswflag = false;//是否显示密码
  }
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
pageEController.$inject = ['$interval','httpService','utils'];