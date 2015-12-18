var express = require('express'),
    morgan = require('morgan'),
    mongoose = require('mongoose'),
    bodyParser = require('body-parser'),
    cors = require('cors'),
    passport = require('passport'),
    session = require('express-session'),
    config = require('./config/config.js'),
    dbRequester = require('./app/dbRequester.js')(),
    db = mongoose.connect(config.db.url),
    app = express(),
    port = process.env.PORT || 3000;

app.use(cors());
app.use(morgan('dev'));
app.use("/test", express.static(__dirname + '/test'));
app.use(bodyParser());
app.use(session({ secret: 'thequickbrownfoxjumpsovertherabbit'}));
app.use(passport.initialize());
app.use(passport.session());

require('./config/passport')(passport);
require('./config/routes.js')(app, dbRequester, passport);

app.listen(port);
console.log('Server is running on port: ' + port);
