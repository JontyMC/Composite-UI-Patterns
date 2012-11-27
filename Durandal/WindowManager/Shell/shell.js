/*global require, define */
define(['files/fileEditor', 'workspaces/myWorkspaces', 'search/search', 'durandal/viewmodel'], function (fileEditor, myWorkspaces, search, viewModel) {
    'use strict';
    var vm = {
        sidebar: myWorkspaces,
        activeItem: viewModel.activator(),
        widget: search,
        activate: function () {
            vm.activeItem(fileEditor);
        }
    };

    return vm;
});