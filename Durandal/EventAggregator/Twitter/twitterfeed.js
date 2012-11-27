/*global require, define, $, ko, setTimeout */
define(['twitter/tweet', 'ko', 'durandal/app'], function (Tweet, ko, eventAggregator) {
    'use strict';

    var vm = {
		tweets: ko.observableArray(),
        selectedTweet: ko.observable(),
		isBusy: ko.observable(false),

        changeSelectedTweet: function (tweet) {
            vm.selectedTweet(tweet);
            eventAggregator.trigger('selectedTweetChanged', tweet);
        },

		activate: function () {
			vm.refreshTweets();
		},

		refreshTweets: function () {
			vm.isBusy(true);
            vm.tweets.removeAll();
            setTimeout(function () {
                vm.search().then(vm.mapTweets);
            }, 2000);
	    },

        search: function () {
            return $.ajax({
                url: 'http://search.twitter.com/search.json?q=huddle',
                dataType: 'jsonp',
                success: function (data) { return data; }
            });
        },

	    mapTweets: function (data) {
			var i,
				tweet;

			vm.tweets(
                data.results.map(function (el) {
                    return new Tweet(el.text);
                })
            );

			vm.isBusy(false);
	    }
    };

    return vm;
});