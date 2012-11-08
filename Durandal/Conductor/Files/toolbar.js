/*global require, define */
define(['ko', 'jquery', 'files/toolbarButtons/DelegateButton', 'files/fileEditor'], function (ko, $, DelegateButton, fileEditor) {
    'use strict';
    var vm = {
        buttons: ko.observableArray(),

        setButtons: function (buttons) {
            vm.buttons.removeAll();
            vm.buttons.push(new DelegateButton('Reset', function () {
                fileEditor.loadFiles();
            }));
            $.each(buttons, function (i, button) {
                vm.buttons.push(button);
            });
        }
    };

    return vm;
});