/*global require, define */
define(function () {
    'use strict';
    function DelegateButton(title, context, action) {
        this.title = title;
        this.context = context;
        this.action = action;
        this.execute = this.execute.bind(this);
    }

    DelegateButton.prototype.execute = function () {
        this.action();
    };

    return DelegateButton;
});