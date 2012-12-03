/*global require, define */
define(['ko', 'model/user/inMemoryUserRepository'], function (ko, userRepository) {
    'use strict';
    function Edit(userId) {
        this.userId = userId;
        this.activate = this.activate.bind(this);
        this.save = this.save.bind(this);
        this.close = this.close.bind(this);
    }

    Edit.prototype.activate = function () {
        this.user = userRepository.get(this.userId);
        this.firstName = this.user.firstName;
        this.lastName = this.user.lastName;
    };

    Edit.prototype.save = function () {
        this.user.updateDetails(this.firstName, this.lastName);
        this.window.close();
    };

    Edit.prototype.close = function () {
        this.window.close();
    };

    return Edit;
});