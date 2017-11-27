import tpl1 from '../views/DIALOG1TMPL.html'
import dialogCtr from '../controller/dialogController'
export default class pageCController {
  constructor($interval,$mdDialog,httpService,utils) {
    this.httpservice = httpService;
    this.ut = utils;
  }
}
pageCController.$inject = ['$interval','$mdDialog','httpService','utils'];