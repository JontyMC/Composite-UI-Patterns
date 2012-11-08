/*global require, define */
define(function () {
    'use strict';
    function DelegateButton(title, action) {
        this.title = title;
        this.action = action;
        this.execute = this.execute.bind(this);
    }

    DelegateButton.prototype.execute = function () {
        this.action();
    };

    return DelegateButton;
});