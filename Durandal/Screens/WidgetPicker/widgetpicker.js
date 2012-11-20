/*global require, define, ko */
define(['whatsnew/whatsnew', 'twitter/twitterfeed', 'durandal/viewModel'], function (whatsnew, twitterfeed, viewModel) {
    'use strict';
    var vm = {
		activeItem: viewModel.activator(),
		switchToWidget1: function () {
			vm.activeItem(twitterfeed);
		},
		switchToWidget2: function () {
			vm.activeItem(whatsnew);
		},
        activate: function () {
            vm.switchToWidget1();
        }
    };

    return vm;
});