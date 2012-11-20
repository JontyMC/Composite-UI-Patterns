/*global require, define */
define(['files/toolbar', 'files/TextFile', 'ko'], function (toolbar, TextFile, ko) {
    'use strict';
    var vm = {
        toolbar: toolbar,
        items: ko.observableArray(),
        activeItem: ko.observable(),

        loadFiles: function () {
            vm.items.removeAll();
            vm.items.push(new TextFile(this, 'Some text file 1', toolbar));
            vm.items.push(new TextFile(this, 'Some text file 2', toolbar));
        },

        deactivateItem: function (item) {
            vm.items.remove(item);
        },

        activateItem: function (item) {
            if (vm.activeItem() !== item) {
                vm.activeItem(item);
            }
        }
    };

    vm.loadFiles();
    vm.activeItem(vm.items[0]);

    return vm;
});