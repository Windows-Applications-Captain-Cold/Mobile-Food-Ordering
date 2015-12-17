var express = require('express'),
    app = express(),
    morgan = require('morgan'),
    port = process.env.PORT || 3000,
    mongoose = require('mongoose'),
    config = require('./config/config.js'),
    bodyParser = require('body-parser'),
    cors = require('cors'),
    db = mongoose.connect(config.db.url);

app.use(cors());
app.use(morgan('dev'));
app.use(bodyParser());

var dbRequester = require('./app/dbRequester.js')();
require('./config/routes.js')(app, dbRequester);

app.use("/test", express.static(__dirname + '/test'));
app.listen(port);
console.log('Server is running on port: ' + port);
