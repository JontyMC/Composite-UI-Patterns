/*global require, define */
define(['files/Toolbar', 'files/TextFile', 'files/ImageFile', 'ko', 'durandal/viewModel'], function (Toolbar, TextFile, ImageFile, ko, viewModel) {
    'use strict';
    var activator = viewModel.activator(),
        vm = {
            items: ko.observableArray(),

            loadFiles: function () {
                vm.items.removeAll();
                vm.items.push(new TextFile(vm, 'Some text file 1', vm.toolbar));
                vm.items.push(new TextFile(vm, 'Some text file 2', vm.toolbar));
                vm.items.push(new ImageFile(vm, 'An image', vm.toolbar));
            },

            closeItem: function (item) {
                var promise = item.canClose();
                if (promise && promise.then) {
                    promise.then(function (result) {
                        if (result === 'Yes') {
                            activator.deactivateItem(item, true);
                        }
                    });
                } else {
                    activator.deactivateItem(item, true);
                }
            },

            activateItem: function (item) {
                activator.activateItem(item);
            },

            activate: function () {
                vm.loadFiles();
                vm.activeItem(vm.items[0]);
            }
        };

    vm.activeItem = activator.for(vm.items);
    vm.toolbar = new Toolbar(vm);

    return vm;
});