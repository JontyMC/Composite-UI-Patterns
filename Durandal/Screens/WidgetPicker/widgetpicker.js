/*global require, define, ko */
define(['whatsnew/whatsnew', 'twitter/twitterfeed'], function (whatsnew, twitterfeed) {
    'use strict';
    var vm = {
		activeItem: ko.observable(),
		switchToWidget1: function () {
			vm.activateItem(twitterfeed);
		},
		switchToWidget2: function () {
			vm.activateItem(whatsnew);
		},
		activateItem: function (item) {
			if (item.onActivate) {
				item.onActivate(item);
			}
			vm.activeItem(item);
		}
    };

    vm.activateItem(twitterfeed);

    return vm;
});