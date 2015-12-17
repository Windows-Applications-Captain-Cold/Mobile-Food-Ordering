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

            res.send("done");
    });

    app.get('/api/locations/:id', function (req, res) {
        dbRequester.locations.getById(req.params.id)
            .then(function (result) {
                res.send(result);

            });
    });
}
