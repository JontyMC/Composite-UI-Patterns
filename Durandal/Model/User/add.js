/*global require, define */
define(['ko', 'model/user/UserModel', 'model/user/inMemoryUserRepository'], function (ko, UserModel, userRepository) {
    'use strict';
    function Add() {
        this.id = ko.observable();
        this.firstName = ko.observable();
        this.lastName = ko.observable();
        this.add = this.add.bind(this);
        this.close = this.close.bind(this);
    }

    Add.prototype.add = function () {
        var user = new UserModel(this.id(), this.firstName(), this.lastName());
        userRepository.add(user);
        this.window.close();
    };

    Add.prototype.close = function () {
        this.window.close();
    };

    return Add;
});