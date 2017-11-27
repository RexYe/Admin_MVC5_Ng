import tpl1 from '../views/DIALOG1TMPL.html'
import dialogCtr from '../controller/dialogController'
export default class echartcontroller {
    //构造函数中引入依赖,需加上aaaController.$inject = ['XXX'];
    constructor(httpService,utils) {
        this.httpservice = httpService;
        this.ut = utils;
    }
}
echartcontroller.$inject = ['httpService','utils'];