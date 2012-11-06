/*global require, define */
define(['files/toolbar', 'files/TextFile', 'ko'], function (toolbar, TextFile, ko) {
    'use strict';
    var vm = {
        toolbar: toolbar,
        items: ko.observableArray(),

        loadFiles: function () {
            vm.items.removeAll();
            vm.items.push(new TextFile('Some text file 1'));
            vm.items.push(new TextFile('Some text file 2'));
        },

        deactivateItem: function (item) {
            vm.items.remove(item);
        }
    };

    vm.loadFiles();

    return vm;
});