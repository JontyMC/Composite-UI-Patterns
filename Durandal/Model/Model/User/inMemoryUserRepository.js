/*global require, define */
define(['jquery', 'ko', 'model/user/UserModel', 'durandal/app'], function ($, ko, UserModel, eventAggregator) {
    'use strict';
    var users = [
        new UserModel(1, "Gypsum", "Fantastic"),
        new UserModel(2, "Remedy", "Malahide"),
        new UserModel(3, "Peter", "O'Hanrahanrahan"),
        new UserModel(4, "Ted", "Maul")
    ];

    function get(id) {
        return $.grep(users, function (user) {
            return user.id === id;
        })[0];
    }

    function getAll() {
        return users;
    }

    function add(user) {
        users.push(user);
        eventAggregator.trigger('userAdded', user.id);
    }

    return {
        get: get,
        getAll: getAll,
        add: add
    };
});