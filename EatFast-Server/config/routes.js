var path = require('path'),
    express = require('express');

module.exports = function (app, dbRequester) {
    app.get("/api/locations", function (req, res) {
        dbRequester.locations.all()
            .then(function (locationsResult) {
                res.send(locationsResult);
            });
    });

    app.post("/api/locations", function (req, res) {
        console.log("AASDASDASDASDASd");
        dbRequester.locations.save(req.body)
            .then(function (saved) {
                if (saved) {
                    res.send(req.body);
                }
            });

            res.send(req.body);
    });

    app.get('/api/locations/:id', function (req, res) {
        dbRequester.locations.getById(req.params.id)
            .then(function (result) {
                res.send(result);
            });
    });

    app.get('/api/foods/:type', function(req, res) {
        dbRequester.foods.get(req.params.type)
            .then(function (foodsResult) {
                res.send(foodsResult);
            });
    });

    app.get('/api/foods', function(req, res) {
        dbRequester.foods.all()
            .then(function (foodsResult) {
                res.send(foodsResult);
            });
    });

    app.post('/api/foods/', function(req, res) {
        console.log(req.body);
        dbRequester.foods.add(req.body)
            .then(function (saved) {
                res.send(saved);
            });

            res.send(req.body);
    });
}
