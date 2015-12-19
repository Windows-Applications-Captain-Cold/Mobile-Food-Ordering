var mongoose = require('mongoose'),
    bcrypt = require('bcrypt-nodejs');

var projectSchema = mongoose.Schema({
    Name: String,
    Description: String,
    DueDate: String
});

module.exports = mongoose.model('Project', projectSchema);
