/*global require, define */
define(['files/Toolbar', 'files/TextFile', 'files/ImageFile', 'ko', 'durandal/viewModel'], function (Toolbar, TextFile, ImageFile, ko, viewModel) {
    'use strict';
    var vm = {
        items: ko.observableArray(),
        activeItem: viewModel.activator(),

        loadFiles: function () {
            vm.items.removeAll();
            vm.items.push(new TextFile(this, 'Some text file 1', vm.toolbar));
            vm.items.push(new TextFile(this, 'Some text file 2', vm.toolbar));
            vm.items.push(new ImageFile(this, 'An image', vm.toolbar));
        },

        deactivateItem: function (item) {
            vm.items.remove(item);
        },

        activateItem: function (item) {
            if (vm.activeItem() !== item) {
                vm.activeItem(item);
            }
        },

        activate: function () {
            vm.loadFiles();
            vm.activeItem(vm.items[0]);
        }
    };

    vm.toolbar = new Toolbar(vm);

    return vm;
});