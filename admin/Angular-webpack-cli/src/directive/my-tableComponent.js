import { NgTableParams } from 'ng-table';
import template from '../views/myTableComponent.html'


class MyTableController {
    constructor() {
        var data = [
            { name: "Moroni", age: 50 } 
        ];

        this.tableParams = new NgTableParams({}, {
            dataset: data
        });
    }
}

MyTableController.$inject = [];

const myTableComponent = {
    template: template,
    controller: MyTableController
};

export { myTableComponent };