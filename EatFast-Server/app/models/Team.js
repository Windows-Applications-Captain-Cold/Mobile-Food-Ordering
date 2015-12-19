var mongoose = require('mongoose'),
    bcrypt = require('bcrypt-nodejs');

var teamSchema = mongoose.Schema({
    Name: String,
    Leader: String,
    Projects: [],
    Members: []
});

module.exports = mongoose.model('Organisation', teamSchema);
