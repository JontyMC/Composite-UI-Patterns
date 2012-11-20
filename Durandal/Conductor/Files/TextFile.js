/*global require, define */
define(['ko', 'extends', 'files/fileBase', 'files/toolbarButtons/SaveButton'], function (ko, extend, fileBase, SaveButton) {
    'use strict';
    function TextFile(parent, displayName, toolbar) {
        this.parent = parent;
    }

    TextFile.prototype.markAsDirty = function () {
        this.isDirty(true);
    };

    return TextFile;
});