/*global require, define */
define(['ko', 'extends', 'files/fileBase', 'files/toolbarButtons/SaveButton'], function (ko, extend, fileBase, SaveButton) {
    'use strict';
    function TextFile(parent, displayName, toolbar) {
        fileBase.call(this, displayName, toolbar);
        this.parent = parent;
        this.buttons = [new SaveButton(this)];
        this.markAsDirty = this.markAsDirty.bind(this);
    }
    extend(TextFile, fileBase);

    TextFile.prototype.markAsDirty = function () {
        this.isDirty(true);
    };

    return TextFile;
});