/*global require, define */
define(['ko', 'jquery', 'files/toolbarButtons/DelegateButton'], function (ko, $, DelegateButton) {
    'use strict';
    function Toolbar(fileEditor) {
        this.fileEditor = fileEditor;
        this.buttons = ko.observableArray();
        this.setButtons = this.setButtons.bind(this);
    }

    Toolbar.prototype.setButtons = function (buttons) {
        var that = this,
            resetButton = new DelegateButton('Reset', this, function () {
                that.fileEditor.activate();
            });

        this.buttons.removeAll();
        this.buttons.push(resetButton);
        $.each(buttons, function (i, button) {
            that.buttons.push(button);
        });
    };

    return Toolbar;
});