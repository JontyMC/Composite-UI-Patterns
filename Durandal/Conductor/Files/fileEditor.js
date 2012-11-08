/*global require, define */
define(['files/toolbar', 'files/TextFile', 'ko'], function (toolbar, TextFile, ko) {
    'use strict';
    var vm = {
        toolbar: toolbar,
        items: ko.observableArray(),
        activeItem: ko.observable(false),

        loadFiles: function () {
            vm.items.removeAll();
            vm.items.push(new TextFile('Some text file 1', toolbar));
            vm.items.push(new TextFile('Some text file 2', toolbar));
        },

        deactivateItem: function (item) {
            vm.items.remove(item);
        },

        activateItem: function (item) {
            if (item.onActivate) {
                item.onActivate();
            }

            vm.activeItem(item);
        }
    };

    vm.loadFiles();

    return vm;
});