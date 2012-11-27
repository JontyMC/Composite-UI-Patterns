/*global require, define */
define(function () {
    'use strict';
    function SaveButton(savable) {
        this.title = 'Save';
        this.savable = savable;
        this.execute = this.execute.bind(this);
    }

    SaveButton.prototype.execute = function () {
        this.savable.save();
    };

    return SaveButton;
});