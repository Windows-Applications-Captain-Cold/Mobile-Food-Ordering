var mongoose = require('mongoose'),
    bcrypt = require('bcrypt-nodejs');

var organisationSchema = mongoose.Schema({
    Name: String,
    Owner: String ,
    Project: String,
    Teams: []
});

module.exports = mongoose.model('Organisation', organisationSchema);
